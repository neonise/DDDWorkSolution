using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.Products;

namespace ScrumProject.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DbSet<Product> _products;
    public ProductRepository(ScrumDbContext context)
    {
        _products = context.Products;
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _products.AddAsync(product);
    }

    public Task<Product> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
