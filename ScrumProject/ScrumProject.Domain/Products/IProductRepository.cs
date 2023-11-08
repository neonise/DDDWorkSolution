namespace ScrumProject.Domain.Products;
public interface IProductRepository
{
    void Insert(Product product);
    Product Get(Guid id);
}
