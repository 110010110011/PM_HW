namespace Hw4.Exercise1;

internal static class Settings
{
    /// <summary>
    /// Gets text from stream
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    internal static List<string?> GetText(Stream stream)
    {
        if ()
        var strings = new List<string?>();
        var str = new StreamReader(stream);
        while (!str.EndOfStream)
        {
            strings.Add(str.ReadLine());
        }
        str.Close();
        return strings;
    }


}
