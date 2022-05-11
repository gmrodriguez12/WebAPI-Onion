using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<Response<int>>
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string ProductNumber { get; set; } = null!;
        public bool? MakeFlag { get; set; }
        public bool? FinishedGoodsFlag { get; set; }
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string? Size { get; set; }
        public string? SizeUnitMeasureCode { get; set; }
        public string? WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string? ProductLine { get; set; }
        public string? Class { get; set; }
        public string? Style { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Product> _repository;

        public UpdateProductCommandHandler(IRepositoryAsync<Product> repository)
        {
            this._repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if(product == null)
            {
                throw new KeyNotFoundException($"Product {request.ProductId} not found");
            }

            product.Name = request.Name;
            product.ProductNumber = request.ProductNumber;
            product.MakeFlag = request.MakeFlag;
            product.FinishedGoodsFlag = request.FinishedGoodsFlag;
            product.Color = request.Color;
            product.SafetyStockLevel = request.SafetyStockLevel;
            product.ReorderPoint = request.ReorderPoint;
            product.StandardCost = request.StandardCost;
            product.ListPrice = request.ListPrice;
            product.Size = request.Size;
            product.SizeUnitMeasureCode = request.SizeUnitMeasureCode;
            product.WeightUnitMeasureCode = request.WeightUnitMeasureCode;
            product.Weight = request.Weight;
            product.DaysToManufacture = request.DaysToManufacture;
            product.Class = request.Class;
            product.Style = request.Style;
            product.ProductSubcategoryId = request.ProductSubcategoryId;
            product.ProductModelId = request.ProductModelId;
            product.SellStartDate = request.SellStartDate;

            await _repository.UpdateAsync(product);
            return new Response<int>(request.ProductId);
        }
    }
}
