using Ilaymor.Bookshelf.Services.Basket.API.Repositories;
using Ilaymor.Bookshelf.Services.Basket.API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _repo;
    public BasketController(IBasketRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("{id:guid}")]
    public async Task<BasketReadDto> GetBasketByIdAsync(Guid id)
    {
        var basket = await _repo.GetBasketByIdAsync(id);
        var basketReadDto = new BasketReadDto(id, basket.UserId, basket.BasketItems); // change
        return basketReadDto;
    }

    [HttpPost]
    public async Task CreateBasketAsync(BasketCreateDto createDto)
    {
        await _repo.CreateBasketAsync(createDto);
    }

    [HttpPut]
    public async Task UpdateBasketAsync(BasketUpdateDto updateDto)
    {
        await _repo.UpdateBasketAsync(updateDto);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteBasketByIdAsync(Guid id)
    {
        await _repo.DeleteBasketByIdAsync(id);
    }

}
