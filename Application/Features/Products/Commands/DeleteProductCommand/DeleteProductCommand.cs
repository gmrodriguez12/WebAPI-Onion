using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<Response<int>>
    {
        public int ProductId { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Product> _repository;

        public UpdateProductCommandHandler(IRepositoryAsync<Product> repository)
        {
            this._repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product {request.ProductId} not found");
            }

            await _repository.DeleteAsync(product);
            return new Response<int>(request.ProductId);
        }
    }
}
