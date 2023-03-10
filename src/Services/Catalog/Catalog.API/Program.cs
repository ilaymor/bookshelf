using Ilaymor.Bookshelf.Services.Catalog.API.Repos;
using Ilaymor.Bookshelf.Services.Catalog.API.Settings;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
var dbSettings = configuration.GetSection(nameof(DbSettings)).Get<DbSettings>();

configureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void configureServices()
{
    configureDb();
    configureSwagger();
    services.AddSingleton<ICatalogItemsRepo, CatalogItemsRepo>();
}

void configureDb()
{
    var mongoClient = new MongoClient(dbSettings.ConnectionString);
    var mongoDatabase = mongoClient.GetDatabase(dbSettings.DatabaseName);
    services.AddSingleton<IMongoDatabase>(mongoDatabase);
}

void configureSwagger()
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}