using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories.GetById;

public record GetCategoryByIdQuery(Guid Id) : IRequestService<CategoryDto>;