using MediatR;
using ScrumProject.Application.Contract.Releases.Commands;
using ScrumProject.Domain.Interfaces;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Releases;
namespace ScrumProject.Application.Releases.Handlers.Commands;

public class RegisterReleaseCommandHandler : IRequestHandler<RegisterReleaseCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IReleaseRepository _releaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterReleaseCommandHandler(
        IProductRepository productRepository,
        IReleaseRepository releaseRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _releaseRepository = releaseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RegisterReleaseCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.ProductId, cancellationToken);
        var release = Release.CreateNew(product.Id, request.Title, DateTime.Now);
        await _releaseRepository.AddAsync(release, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return release.Id;
    }
}
