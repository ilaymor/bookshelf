using Ilaymor.Bookshelf.Services.Basket.API.Models;
using Ilaymor.Bookshelf.Services.Basket.API.Dto;

namespace Ilaymor.Bookshelf.Services.Basket.API.Repositories;

public interface IBasketRepository
{
    Task<CostumerBasket> GetBasketByIdAsync(Guid id);
    Task CreateBasketAsync(BasketCreateDto createDto);
    Task UpdateBasketAsync(BasketUpdateDto updateDto);
    Task DeleteBasketByIdAsync(Guid id);

}