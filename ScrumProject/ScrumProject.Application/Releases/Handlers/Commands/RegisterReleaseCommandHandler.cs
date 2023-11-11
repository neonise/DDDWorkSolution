using MediatR;
using ScrumProject.Application.Contract.Releases.Commands;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Releases;
namespace ScrumProject.Application.Releases.Handlers.Commands;

public class RegisterReleaseCommandHandler : IRequestHandler<RegisterReleaseCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IReleaseRepository _releaseRepository;
    public RegisterReleaseCommandHandler(
        IProductRepository productRepository,
        IReleaseRepository releaseRepository)
    {
        _productRepository = productRepository;
        _releaseRepository = releaseRepository;
    }

    public async Task<Guid> Handle(RegisterReleaseCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.ProductId, cancellationToken);
        var release = Release.CreateNew(product.Id, request.Title, DateTime.Now);
        _releaseRepository.Insert(release);
        return release.Id;
    }
}
