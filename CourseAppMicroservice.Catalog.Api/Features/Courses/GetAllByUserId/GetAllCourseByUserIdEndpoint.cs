using CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public static class GetAllCourseByUserIdEndpoint
{
    public static RouteGroupBuilder GetAllByUserIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/user/{userId:guid}", 
                async (IMediator mediator, Guid userId) => 
                    (await mediator.Send(new GetAllCourseByUserIdQuery(userId))).ToGenericResult())
            .WithName("GetAllCourseByUserId")
            .MapToApiVersion(1, 0)
            .Produces<List<CourseDto>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        
        return group;
    }
}