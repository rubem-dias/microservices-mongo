using MongoDB.Driver;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;
    
    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.Find(p => true).ToListAsync();
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult =
            await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
        
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProduct(string productId)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, productId);
        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}