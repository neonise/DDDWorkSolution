using MediatR;
using ScrumProject.Application.Contract.Products.Commands;
using ScrumProject.Domain.Products;

namespace ScrumProject.Application.Products.CommandHandlers;
public class RegisterBackLogCommandHandler : IRequestHandler<RegisterBackLogCommand>
{
    private readonly IProductRepository _productRepository;
    public RegisterBackLogCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Unit> Handle(RegisterBackLogCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var release = _productRepository.GetSprintById(request.SprintId);
        release.AddNewBackLog(request.Title, request.Description, request.MemberId);
        return Task.FromResult(Unit.Value);
    }
}
