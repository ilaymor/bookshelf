using Ilaymor.Bookshelf.Services.Catalog.API.Model;
using MongoDB.Driver;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Repos;

public class CatalogItemsRepo : ICatalogItemsRepo
{
    private readonly IMongoCollection<CatalogItem> _dbCollection;
    private readonly FilterDefinitionBuilder<CatalogItem> _filterBuilder = Builders<CatalogItem>.Filter;

    public CatalogItemsRepo(IMongoDatabase database)
    {
        _dbCollection = database.GetCollection<CatalogItem>("Items");
    }

    public async Task<IReadOnlyCollection<CatalogItem>> GetCatalogItemsAsync()
    {
        return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
    }

    public async Task<CatalogItem> GetCatalogItemByIdAsync(Guid id)
    {
        FilterDefinition<CatalogItem> filter = _filterBuilder.Eq(entity => entity.Id, id);
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateCatalogItemAsync(CatalogItem entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _dbCollection.InsertOneAsync(entity);
    }

    public async Task UpdateCatalogItemAsync(CatalogItem entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        FilterDefinition<CatalogItem> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
        await _dbCollection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteCatalogItemAsync(Guid id)
    {
        FilterDefinition<CatalogItem> filter = _filterBuilder.Eq(entity => entity.Id, id);
        await _dbCollection.DeleteOneAsync(filter);
    }


}