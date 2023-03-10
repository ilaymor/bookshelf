namespace Ilaymor.Bookshelf.Services.Catalog.API.Settings;

public record DbSettings(string ConnectionString, string DatabaseName, string CollectionName);