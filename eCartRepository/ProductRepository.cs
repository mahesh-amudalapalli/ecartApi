using eCartContracts.IRepository;
using eCartDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using eCartDAL.DBContext;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace eCartRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly eCartDBContext _dBContext;

        public ProductRepository(eCartDBContext _dbContext)
        {
            this._dBContext = _dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _dBContext.Set<Product>().AsNoTracking()
                .ToListAsync<Product>();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(int catID)
        {
            return await _dBContext.Set<Product>().AsNoTracking()
                .Where(p => p.CategoryId == catID).ToListAsync<Product>();
        }

        public async Task<Product> GetProductByID(int id)
        {
            Product product = await _dBContext.Set<Product>().AsNoTracking()
                .SingleOrDefaultAsync<Product>(prod => prod.ProductId == id);

            if (product == null)
            {
                return null;
            }

            await _dBContext.Entry(product).Reference(p => p.Category).LoadAsync();

            return product;
        }

        public async Task<bool> IsProductExists(int id)
        {
            Product product = await _dBContext.Set<Product>().AsNoTracking()
                .SingleOrDefaultAsync<Product>(prod => prod.ProductId == id);

            if (product == null)
            {
                return false;
            }

            return true;
        }

        public void AddProduct(Product product)
        {
            _dBContext.Entry<Product>(product).State = EntityState.Added;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product product = await GetProductByID(id);
            if (product != null)
            {
                _dBContext.Set<Product>().Remove(product);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            bool result = await IsProductExists(id);
            if (result)
            {
                _dBContext.Entry(product).State = EntityState.Modified;
                return true;
            }

            return false;
        }
    }
}
