using CategoryServiceSE1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductModel> AddProduct(ProductModel product);
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> DeleteProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
    }
}
