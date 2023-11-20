using MongoDB.Driver;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}