using MediatR;
using ScrumProject.Application.Contract.Products.Commands;
using ScrumProject.Domain.Interfaces;
using ScrumProject.Domain.Products;

namespace ScrumProject.Application.Products.Handlers.Commands;

public class RegisterProductCommandHandler : IRequestHandler<RegisterProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.CreateNew(request.Title, request.CreateDate, request.DeadlineDate);
        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return product.Id;
    }
}