namespace Hw8.Exercise0;

public interface IData
{
    string GetExchangeInfo(HttpClient httpClient);
    void StorageData(string filename, string data);
}
