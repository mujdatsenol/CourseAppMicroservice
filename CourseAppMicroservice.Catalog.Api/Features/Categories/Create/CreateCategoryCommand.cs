namespace CourseAppMicroservice.Catalog.Api.Features.Categories.Create;

public record CreateCategoryCommand(string Name) : IRequestService<CreateCategoryResponse>;