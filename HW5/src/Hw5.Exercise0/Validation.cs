using System.Globalization;
using System.Text.Json;
using Common;

namespace Hw5.Exercise0;

internal static class Validation
{
    /// <summary>
    /// Validate arguments to be two first 3 letters and the third one non negative sum
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static bool ValidArgs(params string[] args)
    {
        return args is not null &&
               args.Any(x => x is not null) &&
               args.Length == 3 &&
               args[0].ToCharArray().Length == 3 &&
               args[1].ToCharArray().Length == 3 &&
               decimal.TryParse(args[2], out var sum) &&
               sum >= 0;
    }

    /// <summary>
    /// Validate file exists, could be deserialized and has today date
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filename"></param>
    /// <param name="fileSystemProvider"></param>
    /// <param name="currencyList"></param>
    /// <returns></returns>
    public static bool IsValidFile<T>(string filename, IFileSystemProvider _fileSystemProvider, out List<Currency>? currencyList)
    {
        var fileSystemProvider = new FileSystemProvider();
        if (!fileSystemProvider.Exists(filename))
        {
            currencyList = default;
            return false;
        }

        var stream = new StreamReader(new FileSystemProvider().Read(filename));
        var text = stream.ReadToEnd();
        stream.Dispose();

        return IsValidJson(text, out currencyList) && currencyList is not null && IsValidDate(currencyList);
    }

    private static bool IsValidDate(List<Currency> currencyList)
    {
        return currencyList[0].ExchangeDate == DateTime.Today.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
    }


    private static bool IsValidJson<T>(string text, out T? list)
    {
        try
        {
            list = JsonSerializer.Deserialize<T>(text);
        }
        catch (Exception)
        {
            list = default;
            return false;
        }

        return true;
    }

}

