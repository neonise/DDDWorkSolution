using ScrumProject.Domain.Products;
using ScrumProject.Domain.Products.ValueObjects;

namespace ScrumProject.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> Products = new()
    {
        new Product(new ProductTitle("OMS"),DateTime.Now,DateTime.Now.AddDays(21)),
        new Product(new ProductTitle("TBS"),DateTime.Now,DateTime.Now.AddDays(40)),
        new Product(new ProductTitle("BankingSolution"),DateTime.Now,DateTime.Now.AddDays(60))
    };

    public Product Get(Guid id)
    {
        return Products.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(Product product)
    {
        Products.Add(product);
    }
}
