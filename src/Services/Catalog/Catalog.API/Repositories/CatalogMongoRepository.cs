using Ilaymor.Bookshelf.Services.Catalog.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Repositories;

public class CatalogMongoRepository : ICatalogRepository
{
    private readonly IMongoCollection<CatalogItem> _dbCollection;

    public CatalogMongoRepository(IOptions<DbSettings> dbSettings)
    {
        var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
        _dbCollection = mongoDatabase.GetCollection<CatalogItem>(dbSettings.Value.CollectionName);
    }

    public async Task<IEnumerable<CatalogItem?>> GetCatalogItemsAsync()
    {
        return await _dbCollection.Find(_ => true).ToListAsync();
    }

    public async Task<CatalogItem?> GetCatalogItemByIdAsync(Guid id)
    {
        return await _dbCollection.Find(item => item.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateCatalogItemAsync(CatalogItem catalogItem)
    {
        if (catalogItem == null)
        {
            throw new ArgumentNullException(nameof(catalogItem));
        }
        await _dbCollection.InsertOneAsync(catalogItem);
    }

    public async Task UpdateCatalogItemAsync(CatalogItem catalogItem)
    {
        if (catalogItem == null)
        {
            throw new ArgumentNullException(nameof(catalogItem));
        }
        // Todo : add validation

        await _dbCollection.ReplaceOneAsync(item => item.Id == catalogItem.Id, catalogItem);
    }

    public async Task DeleteCatalogItemByIdAsync(Guid id)
    {
        await _dbCollection.DeleteOneAsync(item => item.Id == id);
    }
}