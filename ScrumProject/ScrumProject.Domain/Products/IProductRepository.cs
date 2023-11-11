namespace ScrumProject.Domain.Products;
public interface IProductRepository
{
    void Insert(Product product);
    Task<Product> GetAsync(Guid id,CancellationToken cancellationToken);
}
