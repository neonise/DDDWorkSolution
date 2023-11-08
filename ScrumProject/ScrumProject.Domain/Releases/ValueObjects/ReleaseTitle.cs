using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;

namespace ScrumProject.Domain.Releases.ValueObjects;
public class ReleaseTitle : ValueObject
{
    public string Value { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public ReleaseTitle(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidReleaseTitleException();

        Value = value;
    }
}