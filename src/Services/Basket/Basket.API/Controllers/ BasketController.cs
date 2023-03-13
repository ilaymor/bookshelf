using Ilaymor.Bookshelf.Services.Basket.API.Repositories;
using Ilaymor.Bookshelf.Services.Basket.API.Dto;
using Microsoft.AspNetCore.Mvc;
using Ilaymor.Bookshelf.Services.Basket.API.Models;
using Ilaymor.Bookshelf.Services.Basket.API.Clients;

namespace Basket.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _repo;
    private readonly CatalogClient _catalogClient;
    public BasketController(IBasketRepository repo, CatalogClient catalogClient)
    {
        _repo = repo;
        _catalogClient = catalogClient;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BasketReadDto>> GetBasketByIdAsync(Guid id)
    {
        var basket = await _repo.GetBasketByIdAsync(id);
        if (basket == null)
        {
            return NotFound();
        }
        var basketReadDto = new BasketReadDto(id, basket.UserId, basket.BasketItems);
        return basketReadDto;
    }

    [HttpPost]
    public async Task<ActionResult<BasketReadDto>> CreateBasketAsync(BasketCreateDto createDto)
    {
        // TODO: check if basket with same userid exists and return an error if it is
        var basket = new CostumerBasket(createDto.UserId, createDto.BasketItems);
        await _repo.CreateBasketAsync(basket);
        var basketReadDto = new BasketReadDto(basket.Id, basket.UserId, basket.BasketItems); // TODO: recator to automapper;
        return CreatedAtAction(nameof(GetBasketByIdAsync), new { Id = basket.Id }, basketReadDto); // what does that mean?
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateBasketAsync(Guid id, BasketUpdateDto updateDto)
    {
        if (id != updateDto.Id)
        {
            return BadRequest();
        }
        var basket = await _repo.GetBasketByIdAsync(id);
        if (basket == null)
        {
            return NotFound();
        }
        basket.BasketItems = updateDto.BasketItems;
        await _repo.UpdateBasketAsync(basket);
        return NoContent();


    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteBasketByIdAsync(Guid id)
    {
        var basket = await GetBasketByIdAsync(id);
        if (basket == null)
        {
            return NotFound();
        }
        await _repo.DeleteBasketByIdAsync(id);
        return NoContent();

    }

}
