using Library.Domain;

namespace ScrumProject.Domain.Products;

public class Product : AggregateRoot<int>
{
    public HashSet<Release> Releases { get; private set; }
    public Product()
    {
    }
}