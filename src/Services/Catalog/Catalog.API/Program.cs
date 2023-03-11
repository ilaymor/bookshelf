using Ilaymor.Bookshelf.Services.Catalog.API.Repositories;
using Ilaymor.Bookshelf.Services.Catalog.API.Settings;
using Ilaymor.Bookshelf.Services.Catalog.API.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


// Configure settings
var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
var dbSettings = configuration.GetSection(nameof(DbSettings)).Get<DbSettings>();

// Configure services
services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

var mongoClient = new MongoClient(dbSettings.ConnectionString);
var mongoDatabase = mongoClient.GetDatabase(dbSettings.DatabaseName);
services.AddSingleton<IMongoDatabase>(mongoDatabase);
services.AddSingleton<IRepository<CatalogItem>>(new MongoRepository<CatalogItem>(mongoDatabase, dbSettings.CollectionName));
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Configure HTTP request pipeline
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();