namespace Common;

public class FileSystemProvider : IFileSystemProvider
{
    public bool Exists(string filename)
    {
        return new FileInfo(Path.GetFullPath(filename)).Exists;
    }

    public Stream Read(string filename)
    {
        if (!Exists(filename))
            throw new Exception($"{filename} is missing");

        var dest = Path.GetFullPath(filename);
        var stream = new FileStream(dest, FileMode.Open);

        return stream;
    }

    public async Task WriteAsync(string filename, Stream stream)
    {
        using var destFileStream = new FileStream(Path.GetFullPath(filename), FileMode.OpenOrCreate);
        await Task.Run(() => stream.CopyTo(destFileStream));

    }


}
