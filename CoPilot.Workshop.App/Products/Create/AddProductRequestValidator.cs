using FluentValidation;

namespace CoPilot.Workshop.App.Products.Create
{
    public class AddProductRequestValidator : AbstractValidator<CreateProductCommand>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);
        }
    }
}
