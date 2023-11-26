using Catalog.API.Entities;
using Catalog.API.Repository;

namespace Catalog.API.Aplication;

public class UseCases : IUseCases
{
    private readonly IProductRepository _productRepository;

    public UseCases(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productRepository.GetProducts();
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _productRepository.GetProduct(id);
    }

    public async Task<Product> CreateProduct(Product product)
    { 
        return await _productRepository.CreateProduct(product);
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        return await _productRepository.UpdateProduct(product);
    }

    public async Task<bool> DeleteProduct(string productId)
    {
        return await _productRepository.DeleteProduct(productId);
    }
}