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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private ILogger<CategoryRepository> _logger;
        public CategoryRepository(DataContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CategoryModel> AddCategory(CategoryModel category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
            
        }

        public async Task<CategoryModel> DeleteCategory(CategoryModel category)
        {
            _context.Categories.Remove(category);
             await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryModel> UpdateCategory(CategoryModel category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }


        public async Task<CategoryModel> GetCategoryById(int id)
        {
            return await _context.Categories.Include(c => c.Product).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<CategoryModel>> GetAll()
        {
            return await _context.Categories.Include(c => c.Product).ToListAsync();
        }

       
    }
}
