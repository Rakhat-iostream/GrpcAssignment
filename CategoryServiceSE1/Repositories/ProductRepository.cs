using CategoryServiceSE1.Data;
using CategoryServiceSE1.Models;
using CategoryServiceSE1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private ILogger<ProductRepository> _logger;

        public ProductRepository(DataContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            if (_context.SaveChanges() > 0)
            {
                _logger.LogInformation("Created product with id " + product.Id);
            }
                return product;
        }

        public async Task<ProductModel> DeleteProduct(ProductModel product)
        {
             _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async  Task<ProductModel> GetProductById(int id)
        {
            var product = await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
            if (product == null)
            {
                _logger.LogWarning("Couldn't find product with id " + id);
                return null;
            }
            _logger.LogInformation("Found product with id " + id);
            return product;
        }

        public async  Task<ProductModel> UpdateProduct(ProductModel product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
