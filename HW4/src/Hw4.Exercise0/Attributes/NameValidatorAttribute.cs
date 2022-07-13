using System.ComponentModel.DataAnnotations;

namespace Hw4.Exercise0.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class NameValidatorAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value != null;
    }
}
