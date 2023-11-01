﻿using MediatR;
using ScrumProject.Application.Contract.Products.Commands;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Products.ValueObjects;

namespace ScrumProject.Application.Products.CommandHandlers;

public class RegisterProductCommandHandler : IRequestHandler<RegisterProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    public RegisterProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<int> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        var product = new Product(new ProductTitle(request.Title),
                                  request.CreateDate,
                                  request.DeadlineDate);
        _productRepository.Insert(product);
        return Task.FromResult(product.Id);
    }
}