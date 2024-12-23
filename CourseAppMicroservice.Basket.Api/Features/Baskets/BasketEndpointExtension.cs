using Asp.Versioning.Builder;
using CourseAppMicroservice.Basket.Api.Features.Baskets.AddBasketItem;

namespace CourseAppMicroservice.Basket.Api.Features.Baskets;

public static class BasketEndpointExtension
{
    public static void MapBasketGroupEndpoint(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/baskets")
            .WithTags("Basket")
            .WithApiVersionSet(apiVersionSet)
            .AddBasketItemGroupItemEndpoint();
    }
}