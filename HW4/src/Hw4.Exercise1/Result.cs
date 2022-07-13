using System.Text;
using Common;

namespace Hw4.Exercise1;

internal class Result
{
    public static void SuccessesResult(List<int> resultList, string duration, int from, int to, IFileSystemProvider fileSystemProvider)
    {
        var stringArray = "[";
        for (var i = 0; i < resultList.Count; i++)
        {
            stringArray += $"{resultList[i]}";
            if (i != resultList.Count - 1)
                stringArray += ", ";

        }
        stringArray += "]";

        var resultString = "{\n";
        resultString += "\t\"successes\": true,\n";
        resultString += "\t\"error\": null,\n";
        resultString += $"\t\"range\": \"{from}-{to}\",\n";
        resultString += $"\t\"duration\": \"{duration}\",\n";
        resultString += $"\t\"primes\": {stringArray}\n";
        resultString += "}";

        WriteResultToFile(resultString, fileSystemProvider);
    }


    public static void FailResult(string mess, string duration, IFileSystemProvider fileSystemProvider)
    {
        var resultString = "{\n";
        resultString += "\t\"successes\": false,\n";
        resultString += $"\t\"error\": {mess},\n";
        resultString += $"\t\"duration\": \"{duration}\",\n";
        resultString += $"\t\"primes\": null\n";
        resultString += "}";

        WriteResultToFile(resultString, fileSystemProvider);

    }

    private static void WriteResultToFile(string result, IFileSystemProvider fileSystemProvider)
    {
        var byteArray = Encoding.UTF8.GetBytes(result);
        using var stream = new MemoryStream();
        stream.Write(byteArray, 0, byteArray.Length);

        fileSystemProvider.Write("result.json", stream);
    }
}

