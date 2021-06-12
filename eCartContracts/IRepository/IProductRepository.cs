using eCartDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCartContracts.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();

        Task<Product> GetProductByID(int id);

        Task<IEnumerable<Product>> GetProductByCategory(int catID);

        void AddProduct(Product product);

        Task<bool> DeleteProduct(int id);

        Task<bool> UpdateProduct(int id, Product product);

        Task<bool> IsProductExists(int id);
    }
}
