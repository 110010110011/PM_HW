using System.ComponentModel.DataAnnotations;

namespace Hw4.Exercise0.Attributes;

internal class AgeValidatorAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
            return false;

        return int.TryParse((string)value, out var result) && result > 0;
    }
}
