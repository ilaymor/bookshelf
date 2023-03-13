namespace Ilaymor.Bookshelf.Services.Basket.API.Models;

public class DbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}