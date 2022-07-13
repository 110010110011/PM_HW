using System.Globalization;
using System.Text.Json;
using Common;

namespace Hw8.Exercise0;

internal class Validation : IValidation
{
    public bool ValidArgs(params string[] args)
    {
        return args is not null &&
               args.Any(x => x is not null) &&
               args.Length == 3 &&
               args[0].Length == 3 &&
               args[1].Length == 3 &&
               decimal.TryParse(args[2], out var sum) &&
               sum >= 0;
    }

    public bool IsValidFile<T>(string filename, out List<Currency>? currencyList)
    {
        var fileSystemProvider = new FileSystemProvider();
        if (!fileSystemProvider.Exists(filename))
        {
            currencyList = default;
            return false;
        }

        using var stream = new StreamReader(new FileSystemProvider().Read(filename));
        var text = stream.ReadToEnd();
        return TryDeserialize(text, out currencyList) && currencyList is not null && IsValidDate(currencyList);
    }

    private static bool IsValidDate(List<Currency> currencyList)
    {
        return currencyList[0].ExchangeDate == DateTime.Today.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
    }

    private static bool TryDeserialize<T>(string text, out T? list)
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
