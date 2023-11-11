using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.Products;

namespace ScrumProject.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ScrumDbContext _context;
    private readonly DbSet<Product> _products;
    public ProductRepository(ScrumDbContext context)
    {
        _context = context;
        _products = context.Products;
    }

    public Task<Product> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public void Insert(Product product)
    {
        _products.Add(product);
        _context.SaveChanges();
    }
}
