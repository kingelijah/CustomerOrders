using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductDtoValidator : AbstractValidator<CreateProductDTO>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.");
                
        }
    }
}
