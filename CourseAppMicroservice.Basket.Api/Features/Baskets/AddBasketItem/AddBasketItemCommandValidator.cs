using FluentValidation;

namespace CourseAppMicroservice.Basket.Api.Features.Baskets.AddBasketItem;

public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
{
    public AddBasketItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");
            
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .Length(4, 100).WithMessage("{PropertyName} must be between 4 and 100 characters");
        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
    }
}