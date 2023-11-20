using MongoDB.Driver;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public class CatalogContextSeed
{
    public static void SeedData (IMongoCollection<Product> productCollection)
    {
        bool existProduct = productCollection.Find(p => true).Any();
        if (!existProduct)
        {
            productCollection.InsertManyAsync(GetMyProducts());
        }
    }

    private static IEnumerable<Product> GetMyProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = "dalaDKAka021",
                Name = "Iphone",
                Description = "Wow look at him",
                Image = "image.png",
                Price = 644.00M,
                Category = "Smart Phone"
            }
        };
    }
}