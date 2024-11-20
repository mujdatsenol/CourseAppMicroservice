namespace CourseAppMicroservice.Catalog.Api.Features.Courses.Delete;

public static class DeleteCourseEndpoint
{
    public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}", 
                async (IMediator mediator, Guid id) => 
                    (await mediator.Send(new DeleteCourseCommand(id))).ToGenericResult())
            .WithName("DeleteCourse")
            .MapToApiVersion(1, 0)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

        return group;
    }
}