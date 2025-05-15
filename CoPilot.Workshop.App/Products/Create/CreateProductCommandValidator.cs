using CoPilot.Workshop.Domain;
using FluentValidation;

namespace CoPilot.Workshop.App.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(Product.NameMinLength)
                .MaximumLength(Product.NameMaxLength);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(Product.DescriptionMinLength)
                .MaximumLength(Product.DescriptionMaxLength);

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(Product.PriceMinValue);
        }
    }
}
