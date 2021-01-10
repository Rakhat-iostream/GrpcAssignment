using CategoryServiceSE1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(CategoryCreate category);
        Task<Category> GetCategoryById(int id);
    }
}
