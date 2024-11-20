using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}