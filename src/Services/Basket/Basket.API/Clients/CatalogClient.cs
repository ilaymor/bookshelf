using System.Net.Http;
using Ilaymor.Bookshelf.Services.Basket.API.Dto;

namespace Ilaymor.Bookshelf.Services.Basket.API.Clients;

public class CatalogClient
{
    private readonly HttpClient _httpClient;

    public CatalogClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CatalogItemReadDto>> GetCatalogItemsAsync(IEnumerable<Guid> ids = null!)
    {
        var items = await _httpClient.GetFromJsonAsync<IEnumerable<CatalogItemReadDto>>("/Catalog");
        return items;
    }
}