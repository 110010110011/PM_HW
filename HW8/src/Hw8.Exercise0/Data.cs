using Common;

namespace Hw8.Exercise0;

internal class Data : IData
{
    private const string Url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";

    public string GetExchangeInfo(HttpClient httpClient)
    {
        var response = httpClient.GetAsync(Url);
        if (!response.Result.IsSuccessStatusCode)
            throw new Exception("Invalid status code");
        var body = response.Result.Content.ReadAsStringAsync();

        return body.Result;
    }

    public async void StorageData(string filename, string data)
    {
        using var dataStream = GetStreamFromString(data);

        var fileSystemProvider = new FileSystemProvider();

        await fileSystemProvider.WriteAsync(filename, dataStream);
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
