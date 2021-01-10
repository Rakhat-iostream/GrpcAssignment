using CategoryServiceSE1.Data;
using CategoryServiceSE1.Models;
using CategoryServiceSE1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(CategoryCreate category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
