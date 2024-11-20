using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories.GetAll;

public static class GetAllCategoryEndpoint
{
    public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/", 
            async (IMediator mediator) => 
                (await mediator.Send(new GetAllCategoriesQuery())).ToGenericResult())
            .WithName("GetAllCategory")
            .MapToApiVersion(1, 0)
            .Produces<List<CategoryDto>>(StatusCodes.Status200OK);
        
        return group;
    }
}