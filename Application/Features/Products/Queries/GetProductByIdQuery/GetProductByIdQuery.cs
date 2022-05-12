using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetProductByIdQuery
{
    public class GetProductByIdQuery: IRequest<Response<ProductDTO>>
    {
        public int ProductId { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductDTO>>
        {
            private readonly IRepositoryAsync<Product> _repository;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IRepositoryAsync<Product> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Response<ProductDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _repository.GetByIdAsync(request.ProductId);

                if (product == null)
                    throw new KeyNotFoundException($"Product { request.ProductId } not found");

                var productDto = _mapper.Map<ProductDTO>(product);
                return new Response<ProductDTO>(productDto);
            }
        }
    }
}
