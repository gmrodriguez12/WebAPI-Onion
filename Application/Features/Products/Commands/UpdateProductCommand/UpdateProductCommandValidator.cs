using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required")
                    .MaximumLength(50).WithMessage("{PropertyName} maximum length is {MaxLength}");

            RuleFor(p => p.ProductNumber).NotEmpty().WithMessage("{PropertyName} is required")
                               .MaximumLength(25).WithMessage("{PropertyName} maximum length is {MaxLength}");

            RuleFor(p => p.ProductNumber)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .Matches(@"^\s{2}-\d{4}$").WithMessage("{PropertyName} expected format CC-NNNN")
             .MaximumLength(9).WithMessage("{PropertyName} maximun lenght is {MaxLength}");

            RuleFor(p => p.SafetyStockLevel).NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ReorderPoint).NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ListPrice).NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.DaysToManufacture).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
