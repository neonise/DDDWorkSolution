using MediatR;
using ScrumProject.Domain.Products;

namespace ScrumProject.Application.Contract.Products.Queries;
public class GetProductQuery : IRequest<Product>
{
    public int ProductId { get; set; }
}
