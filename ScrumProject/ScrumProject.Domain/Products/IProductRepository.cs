namespace ScrumProject.Domain.Products;
public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
    Task<Product> GetAsync(Guid id, CancellationToken cancellationToken);
}