using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories.GetById;

public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper) 
    : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
{
    public async Task<ServiceResult<CategoryDto>> Handle(
        GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FindAsync(request.Id, cancellationToken);
        if (category is null)
        {
            return ServiceResult<CategoryDto>.Error(
                "Category not found", 
                $"The category id {request.Id} was not found", 
                HttpStatusCode.NotFound);
        }
        
        var categoryDto = mapper.Map<CategoryDto>(category);
        
        return ServiceResult<CategoryDto>.SuccessAsOk(categoryDto);
    }
}