using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;
using ScrumProject.Domain.Products.ValueObjects;

namespace ScrumProject.Domain.Products;

public class Product : AggregateRoot<Guid>
{
    public ProductTitle Title { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime DeadlineDate { get; private set; }

    private Product()
    {
        //ForEF
    }

    private Product(ProductTitle productTitle, DateTime createDate, DateTime deadlineDate)
    {
        Title = productTitle;
        CreateDate = createDate;
        DeadlineDate = deadlineDate;
        Id = Guid.NewGuid();
    }

    public static Product CreateNew(string title, DateTime createDate, DateTime deadlineDate)
    {
        CheckRule(createDate, deadlineDate);
        return new Product(new ProductTitle(title), createDate, deadlineDate);
    }

    private static void CheckRule(DateTime createDate, DateTime deadlineDate)
    {
        if (createDate.Equals(deadlineDate))
            throw new InvalidIntervalDateException();
    }
}