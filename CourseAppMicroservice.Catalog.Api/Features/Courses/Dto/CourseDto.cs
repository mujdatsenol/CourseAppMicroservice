using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

public record CourseDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string? ImageUrl,
    CategoryDto Category,
    FeatureDto Feature);