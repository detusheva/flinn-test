using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flin_test.Attributes;
using Flin_test.Models;
using Flin_test.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Flin_test.Controllers
{
    [ServiceFilter(typeof(ValidateModelAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("/api/products")]
        public async Task<List<ProductModel>> GetAllProducts(string searchString)
        {
            List<ProductModel> products = await productRepository.GetAllProducts(searchString);

            return products;
        }

        [HttpGet("/api/products/{id}")]
        [ValidateProductExists]
        public async Task<ActionResult<ProductModel>> GetProductById(Guid id)
        {
            var product = await productRepository.GetOneProduct(id);
            return product;
        }

        [HttpPost("/api/products")]
        public async Task<ActionResult<ProductModel>> AddProduct([FromBody] ProductModel product)
        {
            return await productRepository.AddProduct(product);
        }

        [HttpDelete("/api/products/{id}")]
        [ValidateProductExists]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await productRepository.DeleteProduct(id);
            return NoContent();
        }

        [HttpPut("/api/products/{id}")]
        [ValidateProductExists]
        public async Task<ActionResult<ProductModel>> UpdateProduct (ProductModel product, Guid id)
        {
            return await productRepository.UpdateProduct(product, id);
        }
    }
}