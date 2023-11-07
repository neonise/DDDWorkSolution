using ScrumProject.Domain.Products.Entities;
using ScrumProject.Domain.Releases;

namespace ScrumProject.Domain.Products;
public interface IProductRepository
{
    void Insert(Product product);
    Product GetProductById(int productId);
    Release GetReleaseById(int releaseId);
    Sprint GetSprintById(int sprintId);
    BackLog GetBackLogById(int backLogId);
}
