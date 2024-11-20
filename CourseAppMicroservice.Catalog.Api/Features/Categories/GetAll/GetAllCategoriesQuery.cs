using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories.GetAll;

public record GetAllCategoriesQuery : IRequestService<List<CategoryDto>>;