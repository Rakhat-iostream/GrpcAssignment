using CategoryServiceSE1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServiceSE1.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<CategoryModel> AddCategory(CategoryModel category );
        Task<CategoryModel> GetCategoryById(int id);
        Task<CategoryModel> DeleteCategory(CategoryModel category);
        Task<CategoryModel> UpdateCategory(CategoryModel category);
        Task<IList<CategoryModel>> GetAll();
    }
}
