using Ilaymor.Bookshelf.Services.Catalog.API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private static readonly List<CatalogItemReadDto> _catalogItems = new()
    {
        new CatalogItemReadDto(Guid.NewGuid(), "harry potter", "jk rowling"),
        new CatalogItemReadDto(Guid.NewGuid(), "inifinite jest", "david foster wallace"),
        new CatalogItemReadDto(Guid.NewGuid(), "clean code", "robert c martin"),
    };

    // GET /[controller]
    [HttpGet]
    public IEnumerable<CatalogItemReadDto> GetCatalogItems()
    {
        return _catalogItems;
    }

    // GET /[controller]/{id}
    [HttpGet("{id}")]
    public CatalogItemReadDto GetCatalogItemById(Guid id)
    {
        var item = _catalogItems.Where(item => item.Id == id).SingleOrDefault();
        return item;
    }

    // POST /[controller]
    [HttpPost]
    public ActionResult CreateCatalogItem(CatalogItemCreateDto createDto)
    {
        var item = new CatalogItemReadDto(Guid.NewGuid(), createDto.Title, createDto.AuthorName);
        _catalogItems.Add(item);
        return CreatedAtAction(nameof(GetCatalogItemById), new { id = item.Id }, item);
    }

    // PUT /[controller]/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateCatalogItem(CatalogItemUpdateDto updateDto)
    {
        return NoContent();
    }

    // DELETE /[controller]/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteCatalogItem()
    {
        return NoContent();
    }
}

