using CourseAppMicroservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.Create;

public static class CreateCourseCommandEndpoint
{
    public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", 
                async (CreateCourseCommand command, IMediator mediator) => 
                    (await mediator.Send(command)).ToGenericResult())
            .WithName("CreateCourse")
            .MapToApiVersion(1, 0)
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();

        return group;
    }
}