using MediatR;
using ScrumProject.Application.Contract.Products.Commands;
using ScrumProject.Domain.Products;

namespace ScrumProject.Application.Products.CommandHandlers;

public class RegisterReleaseCommandHandler : IRequestHandler<RegisterReleaseCommand>
{
    private readonly IProductRepository _productRepository;
    public RegisterReleaseCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Unit> Handle(RegisterReleaseCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var product = _productRepository.GetProductById(request.ProductId);
        product.AddNewRelease(request.Title);
        return Task.FromResult(Unit.Value);
    }
}
