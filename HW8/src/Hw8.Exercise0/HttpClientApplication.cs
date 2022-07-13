using System.Text.Json;
using Common;

namespace Hw8.Exercise0;

public class HttpClientApplication
{
    private List<Currency>? _currencyList;
    private string? _result;
    private readonly IData _data;
    private readonly IValidation _validation;

    public HttpClientApplication(IData data, IValidation validation)
    {
        _data = data;
        _validation = validation;
    }

    /// <summary>
    /// Runs http client app.
    /// </summary>
    /// <param name="args">Command line arguments</param>
    /// <returns>
    /// Returns <see cref="ReturnCode.Success"/> in case of successful exchange calculation.
    /// Returns <see cref="ReturnCode.InvalidArgs"/> in case of invalid <paramref name="args"/>.
    /// Returns <see cref="ReturnCode.Error"/> in case of error <paramref name="args"/>.
    /// </returns>
    public ReturnCode Run(params string[] args)
    {
        if (!_validation.ValidArgs(args))
            return ReturnCode.InvalidArgs;

        if (!_validation.IsValidFile<List<Currency>>("cache.json", out _))
        {
            try
            {
                _data.StorageData("cache.json", _data.GetExchangeInfo(new HttpClient()));
            }
            catch (Exception)
            {
                return ReturnCode.InvalidArgs;
            }

            if (!_validation.IsValidFile<List<Currency>>("cache.json", out _currencyList) ||
                _currencyList is null)
            {
                return ReturnCode.InvalidArgs;
            }

            _result = Exchange(args, _currencyList);
            if (_result is null)
                return ReturnCode.InvalidArgs;

            Console.WriteLine(_result);
            return ReturnCode.Success;
        }

        _currencyList = DesToList("cache.json");

        if (_currencyList is null)
            return ReturnCode.InvalidArgs;

        _result = Exchange(args, _currencyList);
        if (_result is null)
            return ReturnCode.InvalidArgs;

        Console.WriteLine(_result);
        _data.StorageData("cache.json", JsonSerializer.Serialize(_currencyList));
        return ReturnCode.Success;
    }

    private static string? Exchange(string[] args, List<Currency> currencyList)
    {
        var sourceCurrency = args[0].ToLower();
        var targetCurrency = args[1].ToLower();
        var sourceSum = decimal.Parse(args[2]);

        if (currencyList.Any(x => x.CurrencyValue?.ToLower() == sourceCurrency) &&
            currencyList.Any(x => x.CurrencyValue?.ToLower() == targetCurrency))
        {
            var sourcePrice = currencyList.FirstOrDefault(x => x.CurrencyValue?.ToLower() == sourceCurrency)?.Rate;
            var targetPrice = currencyList.FirstOrDefault(x => x.CurrencyValue?.ToLower() == targetCurrency)?.Rate;
            var targetSum = sourcePrice / targetPrice * sourceSum;

            return sourceCurrency + " : " + sourcePrice + "\n" +
                   targetCurrency + " : " + targetPrice + "\n" +
                   "Date: " + currencyList[0].ExchangeDate + "\n" +
                   "Sum: " + targetSum;
        }

        if (sourceCurrency.ToLower() == "uah" &&
            currencyList.Any(x => x.CurrencyValue?.ToLower() == targetCurrency))
        {
            var targetPrice = currencyList.First(x => x.CurrencyValue?.ToLower() == targetCurrency)?.Rate;
            var targetSum = sourceSum / targetPrice;

            return sourceCurrency + " : " + "1" + "\n" +
                   targetCurrency + " : " + targetPrice + "\n" +
                   "Date: " + currencyList[0].ExchangeDate + "\n" +
                   "Sum: " + targetSum;
        }

        if (targetCurrency.ToLower() == "uah" &&
            currencyList.Any(x => x.CurrencyValue?.ToLower() == sourceCurrency))
        {
            var sourcePrice = currencyList.First(x => x.CurrencyValue?.ToLower() == sourceCurrency)?.Rate;
            var targetSum = sourceSum * sourcePrice;

            return sourceCurrency + " : " + sourcePrice + "\n" +
                   targetCurrency + " : " + "1" + "\n" +
                   "Date: " + currencyList[0].ExchangeDate + "\n" +
                   "Sum: " + targetSum;
        }

        return null;
    }

    private static List<Currency>? DesToList(string filename)
    {
        var stream = new StreamReader(new FileSystemProvider().Read(filename));
        var text = stream.ReadToEnd();
        stream.Dispose();
        var list = JsonSerializer.Deserialize<List<Currency>>(text);

        return list;
    }
}

