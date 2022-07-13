using System.ComponentModel.DataAnnotations;

namespace Hw4.Exercise0.Attributes;

internal class WeightValidatorAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        return double.TryParse((string)value, out var result) && result > 0;
    }
}
