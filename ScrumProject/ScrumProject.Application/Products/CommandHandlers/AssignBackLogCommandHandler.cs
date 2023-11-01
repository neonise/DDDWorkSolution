using MediatR;
using ScrumProject.Application.Contract.Products.Commands;
using ScrumProject.Domain.Products;

namespace ScrumProject.Application.Products.CommandHandlers;

public class AssignBackLogCommandHandler : IRequestHandler<AssignBackLogCommand>
{
    private readonly IProductRepository _productRepository;
    public AssignBackLogCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Unit> Handle(AssignBackLogCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var backLog = _productRepository.GetBackLogById(request.BackLogId);
        backLog.AssignTo(request.MemberId);
        return Task.FromResult(Unit.Value);
    }
}
