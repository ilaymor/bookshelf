using Ilaymor.Bookshelf.Services.Catalog.API.Dto;
using Ilaymor.Bookshelf.Services.Catalog.API.Models;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Profiles;

public static class CatalogItemProfile
{
    public static CatalogItemReadDto ToReadDto(this CatalogItem item)
    {
        return new CatalogItemReadDto(item.Id, item.Title, item.AuthorName);
    }
}