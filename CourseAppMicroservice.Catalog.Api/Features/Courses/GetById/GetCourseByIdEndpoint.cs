using CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.GetById;

public static class GetCourseByIdEndpoint
{
    public static RouteGroupBuilder GetByIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", 
                async (IMediator mediator, Guid id) => 
                    (await mediator.Send(new GetCourseByIdQuery(id))).ToGenericResult())
            .WithName("GetCourseById")
            .MapToApiVersion(1, 0)
            .Produces<CourseDto>(StatusCodes.Status200OK);
        
        return group;
    }
}