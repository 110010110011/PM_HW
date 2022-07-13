using System.Diagnostics;
using Common;
namespace Hw4.Exercise1;

public sealed class PrimesApplication
{
    private readonly IFileSystemProvider _fileSystemProvider;

    public PrimesApplication(IFileSystemProvider fileSystemProvider)
    {
        _fileSystemProvider = fileSystemProvider;
    }

    /// <summary>
    /// Runs application.
    /// </summary>
    public ReturnCode Run()
    {
        var timer = new Stopwatch();
        timer.Start();
        try
        {
            var inputStrings = Settings.GetText(_fileSystemProvider.Read("app.settings"));

            if (SetFromAndTo(inputStrings, out var from, out var to) == 2)
            {
                var primeNumberList = GetPrimeNumbersList(from, to);
                timer.Stop();
                Result.SuccessesResult(primeNumberList, timer.ToString() ?? "0:00:00", from, to, _fileSystemProvider);
            }
            else
            {
                timer.Stop();
                Result.FailResult("invalid args", timer.ToString() ?? "0:00:00", _fileSystemProvider);
                return ReturnCode.Error;
            }
        }
        catch (Exception e)
        {
            timer.Stop();
            Result.FailResult(e.Message, timer.ToString() ?? "0:00:00", _fileSystemProvider);
            return ReturnCode.Error;
        }

        return ReturnCode.Success;
    }

    private static List<int> GetPrimeNumbersList(int from, int to)
    {
        if (to < from)
            return Array.Empty<int>().ToList();

        var primeNumbers = new List<int>();

        for (var i = from; i <= to; i++)
        {
            if (IsPrime(i))
                primeNumbers.Add(i);

        }

        return primeNumbers;
    }

    private static bool IsPrime(int number)
    {
        for (var i = 2; i < number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    /// <summary>
    /// Returns 2 in case of successes setting from and to
    /// </summary>
    /// <param name="inputStrings"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    private static int SetFromAndTo(List<string?> inputStrings, out int from, out int to)
    {
        var successes = 0;
        from = 0;
        to = 0;

        foreach (var str in inputStrings)
        {
            if (str is not null && str.Contains("primesFrom="))
            {
                if (int.TryParse(str.Replace("primesFrom=", string.Empty), out from))
                    successes++;
            }

            if (str is not null && str.Contains("primesTo="))
            {
                if (int.TryParse(str.Replace("primesTo=", string.Empty), out to))
                    successes++;
            }
        }

        return successes;
    }
}
