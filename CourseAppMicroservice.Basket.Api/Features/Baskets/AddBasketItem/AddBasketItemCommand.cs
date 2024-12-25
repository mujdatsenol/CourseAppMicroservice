using CourseAppMicroservice.Shared;

namespace CourseAppMicroservice.Basket.Api.Features.Baskets.AddBasketItem;

public record AddBasketItemCommand(
    Guid Id,
    string Name,
    decimal Price,
    string? ImageUrl)
    : IRequestService;