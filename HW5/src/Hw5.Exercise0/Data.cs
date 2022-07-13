using Common;

namespace Hw5.Exercise0;

internal static class Data
{
    private const string Url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";


    /// <summary>
    /// Get body response data from API 
    /// </summary>
    /// <param name="httpClient"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static string GetExchangeInfo(HttpClient httpClient)
    {
        var response = httpClient.GetAsync(Url);
        if (!response.Result.IsSuccessStatusCode)
            throw new Exception("Invalid status code");
        var body = response.Result.Content.ReadAsStringAsync();

        return body.Result;
    }

    /// <summary>
    /// Set data to file using File System Provider
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="data"></param>
    /// <param name="fileSystemProvider"></param>
    public static void StorageData(string filename, string data, IFileSystemProvider _fileSystemProvider)
    {
        var dataStream = GetStreamFromString(data);

        var fileSystemProvider = new FileSystemProvider();

        fileSystemProvider.Write(filename, dataStream);

        dataStream.Dispose();
    }

    private static Stream GetStreamFromString(string data)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(data);
        writer.Flush();
        stream.Position = 0;

        return stream;
    }
}
