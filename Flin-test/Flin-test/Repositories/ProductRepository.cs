using Flin_test.DataContext;
using Flin_test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flin_test.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RepositoryContext repositoryContext;
        public ProductRepository(RepositoryContext context)
        {
            this.repositoryContext = context;
        }

        public async Task<List<ProductModel>> GetAllProducts(string searchString = null)
        {
            var allProducts = new List<ProductModel>();
            foreach (var product in await repositoryContext.Products.Where
                (x => x.Name.Contains(searchString) || x.Currency.Contains(searchString) || searchString == null)
                .ToListAsync())

                allProducts.Add(new ProductModel
                {
                    Name = product.Name,
                    ProductId = product.ProductId,
                    Price = product.Price,
                    ProductGroupId = product.ProductGroupId,
                    Currency = product.Currency,
                });

            return allProducts;
        }
        public async Task<ProductModel> GetOneProduct(Guid id)
        {
            var product = await repositoryContext.Products.SingleOrDefaultAsync(x => x.ProductId == id);
            return new ProductModel
            {
                Name = product.Name,
                ProductId = product.ProductId,
                Price = product.Price,
                Currency = product.Currency,
                ProductGroupId = product.ProductGroupId
            };
        }
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            Product productEntity = new Product
            {
                Name = product.Name,
                ProductId = product.ProductId,
                Price = product.Price,
                ProductGroupId = product.ProductGroupId,
                Currency = product.Currency,
            };

            repositoryContext.Products.Add(productEntity);

            await repositoryContext.SaveChangesAsync();

            return product;
        }
        public async Task DeleteProduct(Guid id)
        {
            var product = await repositoryContext.Products.SingleOrDefaultAsync(x => x.ProductId == id);
            repositoryContext.Products.Remove(product);

            await repositoryContext.SaveChangesAsync();
        }
        public async Task<ProductModel> UpdateProduct(ProductModel product, Guid id)
        {
            var productEntity = await repositoryContext.Products.SingleOrDefaultAsync(x => x.ProductId == id);

            productEntity.Name = product.Name;
            productEntity.ProductId = product.ProductId;
            productEntity.Price = product.Price;
            productEntity.Currency = product.Currency;
            productEntity.ProductGroupId = product.ProductGroupId;

            await repositoryContext.SaveChangesAsync();

            return product;
        }
    }
}
