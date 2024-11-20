namespace CourseAppMicroservice.Catalog.Api.Features.Courses.Update;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .Length(4, 100).WithMessage("{PropertyName} must be between 4 and 100 characters");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .Length(4, 1000).WithMessage("{PropertyName} must be between 4 and 100 characters");
        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");
    }
}