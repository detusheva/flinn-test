using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flin_test.Models;

namespace Flin_test.Repositories
{
    public interface IProductRepository
    {
        Task<ProductModel> AddProduct(ProductModel product);
        Task DeleteProduct(Guid id);
        Task<List<ProductModel>> GetAllProducts(string searchString);
        Task<ProductModel> GetOneProduct(Guid id);
        Task<ProductModel> UpdateProduct(ProductModel product, Guid id);
    }
}