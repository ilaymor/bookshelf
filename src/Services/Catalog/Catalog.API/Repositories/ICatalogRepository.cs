using Ilaymor.Bookshelf.Services.Catalog.API.Models;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Repositories;

public interface ICatalogRepository
{
    Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync();
    Task<CatalogItem> GetCatalogItemByIdAsync(Guid id);
    Task CreateCatalogItemAsync(CatalogItem item);
    Task UpdateCatalogItemAsync(CatalogItem item);
    Task DeleteCatalogItemByIdAsync(Guid id);

}