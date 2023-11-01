using ScrumProject.Domain.Products;
using ScrumProject.Domain.Products.Entities;

namespace ScrumProject.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> Products = new();

    public BackLog GetBackLogById(int backLogId)
    {
        return Products.SelectMany(x => x.Releases.SelectMany(sp => sp.Sprints)
        .SelectMany(bc => bc.BackLogs))
           .SingleOrDefault(x => x.Id == backLogId);
    }

    public Product GetProductById(int productId)
    {
        return Products.SingleOrDefault(x => x.Id == productId);
    }

    public Release GetReleaseById(int releaseId)
    {
        return Products.SelectMany(x => x.Releases)
            .SingleOrDefault(x => x.Id == releaseId);
    }

    public Sprint GetSprintById(int sprintId)
    {
        return Products.SelectMany(x => x.Releases.SelectMany(sp => sp.Sprints))
           .SingleOrDefault(x => x.Id == sprintId);
    }

    public void Insert(Product product)
    {
        Products.Add(product);
    }
}
