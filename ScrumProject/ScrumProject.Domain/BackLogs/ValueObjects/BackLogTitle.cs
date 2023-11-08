using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;

namespace ScrumProject.Domain.Releases.ValueObjects;
public class BackLogTitle : ValueObject
{
    public string Value { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public BackLogTitle(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidBackLogTitleException();

        Value = value;
    }
}