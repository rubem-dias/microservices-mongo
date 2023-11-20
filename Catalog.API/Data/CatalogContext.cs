using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public class CatalogContext : ICatalogContext
{
    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

        CatalogContextSeed.SeedData(Products);
    }

    public IMongoCollection<Product> Products { get; }
}