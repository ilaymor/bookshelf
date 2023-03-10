using Ilaymor.Bookshelf.Services.Catalog.API.Repos;
using Ilaymor.Bookshelf.Services.Catalog.API.Dto;
using Ilaymor.Bookshelf.Services.Catalog.API.Model;
using Ilaymor.Bookshelf.Services.Catalog.API.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly ICatalogItemsRepo _repo;

    public CatalogController(ICatalogItemsRepo repo)
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
        await _repo.CreateCatalogItemAsync(item);
        return CreatedAtAction(nameof(GetCatalogItemById), new { id = item.Id }, item);
    }

    // PUT /[controller]/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCatalogItemAsync(CatalogItemUpdateDto updateDto, Guid id)
    {
        var existingItem = await _repo.GetCatalogItemByIdAsync(id);
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

        await _repo.DeleteCatalogItemAsync(item.Id);

        return NoContent();
    }
}

