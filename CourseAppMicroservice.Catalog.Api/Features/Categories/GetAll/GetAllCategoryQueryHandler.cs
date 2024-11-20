using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories.GetAll;

public class GetAllCategoryQueryHandler(AppDbContext context, IMapper mapper) 
    : IRequestHandler<GetAllCategoriesQuery, ServiceResult<List<CategoryDto>>>
{
    public async Task<ServiceResult<List<CategoryDto>>> Handle(
        GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories
            .ToListAsync(cancellationToken: cancellationToken);
        var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);
        
        return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoriesAsDto);
    }
}