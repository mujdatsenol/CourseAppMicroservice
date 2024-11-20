namespace CourseAppMicroservice.Catalog.Api.Features.Categories.Create;

public class CreateCategoryCommandHandler(AppDbContext context) 
    : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
{
    public async Task<ServiceResult<CreateCategoryResponse>> Handle(
        CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existCategory =
            await context.Categories.AnyAsync(a => a.Name == request.Name, cancellationToken);

        if (existCategory)
        {
            return ServiceResult<CreateCategoryResponse>.Error(
                "Category Name already exists",
                $"The category '{request.Name}' already exists.",
                HttpStatusCode.BadRequest);
        }

        var category = new Category
        {
            Id = NewId.NextSequentialGuid(),
            Name = request.Name
        };
        
        await context.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(
            new CreateCategoryResponse(category.Id), $"/api/categories/{category.Id}");
    }
}