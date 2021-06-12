using eCartContracts.IRepository;
using eCartDAL.DBContext;
using eCartDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCartRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly eCartDBContext _eCartDBContext;

        public CategoryRepository(eCartDBContext _eCartDBContext)
        {
            this._eCartDBContext = _eCartDBContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _eCartDBContext.Categories.ToListAsync<Category>();
        }

        public async Task<Category> GetCategoryByID(int id)
        {
            return await _eCartDBContext.Categories.SingleOrDefaultAsync<Category>(cat => cat.CategoryId == id);
        }

        public async Task AddCategory(Category category)
        {
            await _eCartDBContext.Categories.AddAsync(category);
        }
    }
}
