using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<PagedResponse<List<ProductDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int SubCategoryId { get; set; }

        public class GetAllProductsHandlerQuery : IRequestHandler<GetAllProductsQuery, PagedResponse<List<ProductDTO>>>
        {
            private readonly IRepositoryAsync<Product> _repository;
            private readonly IMapper _mapper;

            public GetAllProductsHandlerQuery(IRepositoryAsync<Product> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<ProductDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _repository.ListAsync(new PagedProductSpecification(request.PageSize, request.PageNumber, request.SubCategoryId));
                var productsDTO = _mapper.Map<List<ProductDTO>>(products);

                return new PagedResponse<List<ProductDTO>>(productsDTO, request.PageNumber, request.PageSize);
            }
        }
    }
}
