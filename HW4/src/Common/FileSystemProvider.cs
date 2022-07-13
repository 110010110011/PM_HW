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
        
        using var stream = File.OpenRead(Path.GetFullPath(filename));
        return stream;
    }

    public void Write(string filename, Stream stream)
    {
        var writer = new StreamWriter(stream);
        stream.CopyTo(new FileSystemProvider().Read(Path.GetFullPath(filename)));
    }
}
