using Microsoft.VisualBasic;

namespace Hw4.Exercise0;

public static class PersonValidator
{
    public static PersonValidationResult Validate(Person? person)
    {
        if (person is null)
        {
            return new PersonValidationResult()
            {
                IsValid = false,
                ErrorMessage = "Person can't be null"
            };
        }

        if (string.IsNullOrEmpty(person.Name) || person.Name.All(l => l == ' '))
        {
            return new PersonValidationResult()
            {
                IsValid = false,
                ErrorMessage = "Person Name is required"
            };
        }

        if (person.Age is < 18 or > 200)
        {
            return new PersonValidationResult()
            {
                IsValid = false,
                ErrorMessage = "Person Age is out of range"
            };
        }

        if (person.Weight is <= 0 or > 200)
        {
            return new PersonValidationResult()
            {
                IsValid = false,
                ErrorMessage = "Person Weight is out of range"
            };
        }

        return new PersonValidationResult()
        {
            IsValid = true,
            ErrorMessage = null
        };
    }
}
