using Hw4.Exercise0.Attributes;

namespace Hw4.Exercise0;

public sealed class Person
{
    // define Name
    // Age
    // and Weight properties

    // create a validation attribute for properties
    [NameValidator]
    public string? Name { get; set; }

    [AgeValidator]
    public int Age { get; set; }

    [WeightValidator]
    public double Weight { get; set; }


}
