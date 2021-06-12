using eCartDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCartContracts.IRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();

        Task<Category> GetCategoryByID(int id);

        Task AddCategory(Category category);
    }
}
