using Ilaymor.Bookshelf.Services.Catalog.API.Repositories;
using Ilaymor.Bookshelf.Services.Catalog.API.Dto;
using Ilaymor.Bookshelf.Services.Catalog.API.Models;
using Ilaymor.Bookshelf.Services.Catalog.API.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly ICatalogRepository _repo;

    public CatalogController(ICatalogRepository repo)
    {
        _repo = repo;
    }

    // GET /[controller]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CatalogItemReadDto>>> GetCatalogItemsAsync()
    {
        var items = await _repo.GetCatalogItemsAsync();
        var itemsReadDtos = items.Select(item => item.ToReadDto());
        return Ok(itemsReadDtos);
    }

    // GET /[controller]/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CatalogItemReadDto>> GetCatalogItemById(Guid id)
    {
        var item = await _repo.GetCatalogItemByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        var itemReadDto = item.ToReadDto();
        return Ok(itemReadDto);
    }

    // POST /[controller]
    [HttpPost]
    public async Task<ActionResult<CatalogItemReadDto>> CreateCatalogItem(CatalogItemCreateDto createDto)
    {
        var item = new CatalogItem(createDto.Title, createDto.AuthorName);
        var catalogItem = new CatalogItem(createDto.Title, createDto.AuthorName);
        await _repo.CreateCatalogItemAsync(catalogItem);
        return CreatedAtAction(nameof(GetCatalogItemById), new { id = item.Id }, item);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCatalogItemAsync(CatalogItemUpdateDto updateDto)
    {
        var existingItem = await _repo.GetCatalogItemByIdAsync(updateDto.Id);
        if (existingItem == null)
        {
            return NotFound();
        }

        existingItem.Title = updateDto.Title;
        existingItem.AuthorName = updateDto.AuthorName;
        await _repo.UpdateCatalogItemAsync(existingItem);
        return NoContent();

    }

    // DELETE /[controller]/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCatalogItem(Guid id)
    {
        var item = await _repo.GetCatalogItemByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        await _repo.DeleteCatalogItemByIdAsync(id);

        return NoContent();
    }
}

