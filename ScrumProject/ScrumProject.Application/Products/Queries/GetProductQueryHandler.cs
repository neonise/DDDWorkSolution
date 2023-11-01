using MediatR;
using ScrumProject.Application.Contract.Products.Queries;
using ScrumProject.Domain.Products;

namespace ScrumProject.Application.Products.Queries;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var product = _productRepository.GetProductById(request.ProductId);
        return Task.FromResult(product);
    }
}
