using MediatR;
using ScrumProject.Application.Contract.Releases.Commands;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Releases.ValueObjects;
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

    public Task<Guid> Handle(RegisterReleaseCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var product = _productRepository.Get(request.ProductId);
        var release = Release.CreateNew(product.Id, new ReleaseTitle(request.Title), DateTime.Now);
        _releaseRepository.Insert(release);
        return Task.FromResult(release.Id);
    }
}
