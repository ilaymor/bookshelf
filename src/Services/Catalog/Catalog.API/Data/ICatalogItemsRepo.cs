using Ilaymor.Bookshelf.Services.Catalog.API.Model;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Data;

public interface ICatalogItemsRepo
{
    Task<IReadOnlyCollection<CatalogItem>> GetCatalogItemsAsync();
    Task<CatalogItem> GetCatalogItemByIdAsync(Guid id);
    Task CreateCatalogItemAsync(CatalogItem entity);
    Task UpdateCatalogItemAsync(CatalogItem entity);
    Task DeleteCatalogItemAsync(Guid id);

}