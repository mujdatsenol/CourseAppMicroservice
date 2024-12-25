using System.Text.Json;
using CourseAppMicroservice.Basket.Api.Const;
using CourseAppMicroservice.Basket.Api.Dto;
using CourseAppMicroservice.Shared;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace CourseAppMicroservice.Basket.Api.Features.Baskets.AddBasketItem;

public class AddBasketItemCommandHandler(IDistributedCache distributedCache)
    : IRequestHandler<AddBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(
        AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        BasketDto? currentBasket;
        // TODO: UserId dışarıdan gelecek! Burası değişecek!
        Guid userId = Guid.NewGuid();
        var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);
        
        var newBasketItem = new BasketItemDto(
            request.Id,
            request.Name,
            request.Price,
            null,
            request.ImageUrl);
        
        var basketAsString = await distributedCache.GetStringAsync(cacheKey, cancellationToken);
        if (string.IsNullOrEmpty(basketAsString))
        {
            currentBasket = new BasketDto(userId, [newBasketItem]);
            await CreateCacheAsync(cacheKey, currentBasket, cancellationToken);
        
            return ServiceResult.SuccessAsNoContent();
        }
        
        currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);
            
        var existingBasketItem = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.Id);
        if (existingBasketItem is not null)
        {
            currentBasket!.BasketItems.Remove(existingBasketItem);
        }
            
        currentBasket!.BasketItems.Add(newBasketItem);
        await CreateCacheAsync(cacheKey, currentBasket, cancellationToken);
        
        return ServiceResult.SuccessAsNoContent();
    }

    private async Task CreateCacheAsync(string cacheKey, BasketDto? basket, CancellationToken cancellationToken)
    {
        if (basket is not null)
            await distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(basket), cancellationToken);
    }
}