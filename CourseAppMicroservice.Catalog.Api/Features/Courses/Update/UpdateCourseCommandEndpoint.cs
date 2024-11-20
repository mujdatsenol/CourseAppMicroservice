using CourseAppMicroservice.Shared.Filters;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.Update;

public static class UpdateCourseCommandEndpoint
{
    public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPut("/", 
                async (UpdateCourseCommand command, IMediator mediator) => 
                    (await mediator.Send(command)).ToGenericResult())
            .WithName("UpdateCourse")
            .MapToApiVersion(1, 0)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>();

        return group;
    }
}