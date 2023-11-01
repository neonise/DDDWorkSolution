using MediatR;
using ScrumProject.Application.Contract.Products.Commands;
using ScrumProject.Domain.Products;

namespace ScrumProject.Application.Products.CommandHandlers;

public class RegisterSprintCommandHandler : IRequestHandler<RegisterSprintCommand>
{
    private readonly IProductRepository _productRepository;
    public RegisterSprintCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Unit> Handle(RegisterSprintCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var release = _productRepository.GetReleaseById(request.ReleaseId);
        release.AddNewSprint(request.Title, request.FromDate, request.ToDate);
        return Task.FromResult(Unit.Value);
    }
}
