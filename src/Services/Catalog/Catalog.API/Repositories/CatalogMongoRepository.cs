using Ilaymor.Bookshelf.Services.Catalog.API.Models;
using MongoDB.Driver;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Repositories;

public class CatalogMongoRepository : ICatalogRepository
{
    private readonly IMongoCollection<CatalogItem> _dbCollection;
    private readonly FilterDefinitionBuilder<CatalogItem> _filterBuilder = Builders<CatalogItem>.Filter;

    public CatalogMongoRepository(IMongoDatabase database, string collectionName)
    {
        _dbCollection = database.GetCollection<CatalogItem>(collectionName);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync()
    {
        return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
    }

    public async Task<CatalogItem> GetCatalogItemByIdAsync(Guid id)
    {
        FilterDefinition<CatalogItem> filter = _filterBuilder.Eq(entity => entity.Id, id);
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateCatalogItemAsync(CatalogItem catalogItem)
    {
        if (catalogItem == null)
        {
            throw new ArgumentNullException(nameof(catalogItem));
        }
        // Todo : add validation
        await _dbCollection.InsertOneAsync(catalogItem);
    }

    public async Task UpdateCatalogItemAsync(CatalogItem catalogItem)
    {
        if (catalogItem == null)
        {
            throw new ArgumentNullException(nameof(catalogItem));
        }
        // Todo : add validation

        FilterDefinition<CatalogItem> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, catalogItem.Id);
        await _dbCollection.ReplaceOneAsync(filter, catalogItem);
    }

    public async Task DeleteCatalogItemByIdAsync(Guid id)
    {
        FilterDefinition<CatalogItem> filter = _filterBuilder.Eq(entity => entity.Id, id);
        await _dbCollection.DeleteOneAsync(filter);
    }
}