using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories.GetById;

public static class GetCategoryByIdEndpoint
{
    public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", 
            async (IMediator mediator, Guid id) => 
                (await mediator.Send(new GetCategoryByIdQuery(id))).ToGenericResult())
            .WithName("GetCategoryById")
            .MapToApiVersion(1, 0)
            .Produces<CategoryDto>(StatusCodes.Status200OK);
        
        return group;
    }
}