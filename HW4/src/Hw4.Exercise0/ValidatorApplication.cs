using Common;

namespace Hw4.Exercise0;

public sealed class ValidatorApplication
{
    /// <summary>
    /// Runs application.
    /// </summary>
    public ReturnCode Run(string[] args)
    {
        // TODO: create a person object from passed `args`
        try
        {
            var person = new Person
            {
                Name = args[0],
                Age = int.Parse(args[1]),
                Weight = double.Parse(args[2])
            };

            // validate
            var validationResult = PersonValidator.Validate(person);

            // and log validation result
            Console.WriteLine("Person {0} validation result is: {1}", person, validationResult);

            return validationResult.IsValid ? ReturnCode.Success : ReturnCode.InvalidArgs;
        }
        catch (Exception)
        {
            return ReturnCode.InvalidArgs;
        }


    }
}
