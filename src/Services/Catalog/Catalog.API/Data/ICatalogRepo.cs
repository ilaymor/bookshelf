using Ilaymor.Bookshelf.Services.Catalog.API.Model;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Data;

public interface ICatalogRepo
{
    Task<IReadOnlyCollection<CatalogItem>> GetCatalogItemsAsync();
    Task<CatalogItem> GetCatalogItemByIdAsync(Guid id);
    Task UpdateCatalogItemAsync(CatalogItem entity);
    Task DeleteCatalogItemAsync(Guid id);

}