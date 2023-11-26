using Microsoft.AspNetCore.Mvc;
using Catalog.API.Aplication;
using Catalog.API.Entities;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IUseCases _useCases;

        public CatalogController(IUseCases useCases)
        {
            _useCases = useCases;
        }

        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _useCases.GetProducts();
            return Ok(products);
        }
        
        [HttpGet("GetProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            Product product = await _useCases.GetProduct(id);
        
            if (product is null)
                return NotFound();
        
            return Ok(product);
        }
        
        [HttpPost("CreateProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (product is null)
                return BadRequest("Invalid product");
        
            Product productCreated = await _useCases.CreateProduct(product);
        
            if (productCreated != null)
            {
                return Ok($"Product created: {product.Name}");
            }
            else
            {
                return BadRequest("Product cannot be created");
            }
        }
        
        [HttpPut("UpdateProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody]Product product)
        {
            if (product is null)
                return BadRequest("Invalid product");
        
            bool productUpdated = await _useCases.UpdateProduct(product);
        
            return Ok(productUpdated);
        }
        
        [HttpDelete("DeleteProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> DeleteProduct(string id)
        {
            return Ok(await _useCases.DeleteProduct(id));
        }
    }
}
