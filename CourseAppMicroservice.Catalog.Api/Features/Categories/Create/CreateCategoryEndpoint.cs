using CourseAppMicroservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories.Create;

public static class CreateCategoryEndpoint
{
    public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", 
            async (CreateCategoryCommand command, IMediator mediator) => 
                (await mediator.Send(command)).ToGenericResult())
            .WithName("CreateCategory")
            .MapToApiVersion(1, 0)
            .Produces<CreateCategoryResponse>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
            .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

        return group;
    }
}