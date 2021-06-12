using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eCartContracts.BusinessModels;

namespace eCartContracts.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts();

        Task<ProductModel> GetProductById(int id);

        Task<IEnumerable<CategoryModel>> GetAllCategories();

        Task<CategoryModel> GetCategoryById(int id);

        Task<IEnumerable<ProductModel>> GetAllProductsByCatId(int catId);

        Task AddProduct(ProductModel product);

        Task AddCategory(CategoryModel category);

        Task<bool> DeleteProduct(int id);

        Task<bool> UpdateProduct(int id, ProductModel product);
    }
}
