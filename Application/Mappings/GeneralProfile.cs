using Application.DTOs;
using Application.Features.Products.Commands.CreateProductCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
