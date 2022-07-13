namespace Common;

public class FileSystemProvider : IFileSystemProvider
{
    public bool Exists(string filename)
    {
        return new FileInfo(Path.GetFullPath(filename)).Exists;
    }

    public Stream Read(string filename)
    {
        if (Exists(filename) == false)
            throw new Exception($"{filename} is missing");

        var dest = Path.GetFullPath(filename);
        var stream = new FileStream(dest, FileMode.Open);

        return stream;

    }

    public void Write(string filename, Stream stream)
    {
        var destFileStream = new FileStream(Path.GetFullPath(filename), FileMode.OpenOrCreate);
        stream.CopyTo(destFileStream);

        destFileStream.Dispose();
    }
}
