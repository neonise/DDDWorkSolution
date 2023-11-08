using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;

namespace ScrumProject.Domain.Releases.ValueObjects;
public class SprintTitle : ValueObject
{
    public string Value { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public SprintTitle(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidSprintTitleException();

        Value = value;
    }
}