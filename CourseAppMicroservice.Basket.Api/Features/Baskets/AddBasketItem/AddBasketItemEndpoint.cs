using CourseAppMicroservice.Shared.Extensions;
using CourseAppMicroservice.Shared.Filters;
using MediatR;

namespace CourseAppMicroservice.Basket.Api.Features.Baskets.AddBasketItem;

public static class AddBasketItemEndpoint
{
    public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/item", 
                async (AddBasketItemCommand command, IMediator mediator) => 
                    (await mediator.Send(command)).ToGenericResult())
            .WithName("AddBasketItem")
            .MapToApiVersion(1, 0)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status500InternalServerError)
            .AddEndpointFilter<ValidationFilter<AddBasketItemCommand>>();
        
        return group;
    }
}