using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;
using ScrumProject.Domain.Products.ValueObjects;

namespace ScrumProject.Domain.Products;

public class Product : AggregateRoot<Guid>
{
    public ProductTitle ProductTitle { get; init; }
    public DateTime CreateDate { get; init; }
    public DateTime DeadlineDate { get; init; }
    public Product(ProductTitle productTitle, DateTime createDate, DateTime deadlineDate)
    {
        CheckRule(createDate, deadlineDate);
        ProductTitle = productTitle;
        CreateDate = createDate;
        DeadlineDate = deadlineDate;
        Id = Guid.NewGuid();
    }

    private static void CheckRule(DateTime createDate, DateTime deadlineDate)
    {
        if (createDate.Equals(deadlineDate))
            throw new InvalidIntervalDateException();
    }
}