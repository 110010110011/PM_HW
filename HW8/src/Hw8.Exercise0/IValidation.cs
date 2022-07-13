namespace Hw8.Exercise0;

public interface IValidation
{
    public bool ValidArgs(params string[] args);
    public bool IsValidFile<T>(string filename, out List<Currency>? currencyList);
}
