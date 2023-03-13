using Ilaymor.Bookshelf.Services.Basket.API.Models;
using Ilaymor.Bookshelf.Services.Basket.API.Dto;

namespace Ilaymor.Bookshelf.Services.Basket.API.Repositories;

public interface IBasketRepository
{
    Task<CostumerBasket?> GetBasketByIdAsync(Guid id);
    Task<CostumerBasket?> GetBasketByUserIdAsync(Guid userId);
    Task CreateBasketAsync(CostumerBasket basket);
    Task UpdateBasketAsync(CostumerBasket basket);
    Task DeleteBasketByIdAsync(Guid id);

}