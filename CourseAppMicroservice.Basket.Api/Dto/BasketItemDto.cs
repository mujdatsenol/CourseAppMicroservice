namespace CourseAppMicroservice.Basket.Api.Dto;

public record BasketItemDto(
    Guid Id,
    string Name,
    decimal Price,
    decimal? PriceByApplyDiscountRate,
    string? ImageUrl);