using Ilaymor.Bookshelf.Services.Catalog.API.Repositories;
using Ilaymor.Bookshelf.Services.Catalog.API.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("Database"));
builder.Services.AddSingleton<ICatalogRepository, CatalogMongoRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline
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