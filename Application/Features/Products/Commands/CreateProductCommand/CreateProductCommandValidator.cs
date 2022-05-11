using FluentValidation;

namespace Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required")
                                .MaximumLength(50).WithMessage("{PropertyName} maximum length is {MaxLength}");

            RuleFor(p => p.ProductNumber).NotEmpty().WithMessage("{PropertyName} is required")
                               .MaximumLength(25).WithMessage("{PropertyName} maximum length is {MaxLength}");

            RuleFor(p => p.SafetyStockLevel).NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ReorderPoint).NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ListPrice).NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.IdVendor).NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.IdSubCategory).NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.IdCategory).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
