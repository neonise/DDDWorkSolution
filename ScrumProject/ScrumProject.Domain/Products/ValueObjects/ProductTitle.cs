using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;

namespace ScrumProject.Domain.Products.ValueObjects;
public class ProductTitle : ValueObject
{
    public string Value { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public ProductTitle(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidProductTitleException();

        Value = value;
    }

    //public static implicit operator string(ProductTitle productTitle) => productTitle.Value;
    //public static implicit operator ProductTitle(string productTitle) => new(productTitle);
}
