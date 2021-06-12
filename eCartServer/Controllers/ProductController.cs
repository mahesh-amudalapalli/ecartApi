using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCartContracts.IServices;
using eCartDtos;
using eCartContracts.BusinessModels;
using AutoMapper;

namespace eCartServer.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _prodService;
        private readonly IMapper _mapper;

        public ProductController(IProductService prodService,IMapper mapper)
        {
            _prodService = prodService;
            _mapper = mapper;
        }

        #region Product
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            IEnumerable<ProductModel> products = await _prodService.GetAllProducts();

            IEnumerable<ProductDto> productList = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            ProductModel prodModel = await _prodService.GetProductById(id);

            ProductDto product = _mapper.Map<ProductDto>(prodModel);

            return Ok(product);
        }

        [HttpGet]
        [Route("ByCategoryId/{id:int}")]
        public async Task<IActionResult> GetProductByCategoryId(int id)
        {
            IEnumerable<ProductModel> products = await _prodService.GetAllProductsByCatId(id);

            IEnumerable<ProductDto> productList = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productList);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            ProductModel productModel = _mapper.Map<ProductModel>(productDto);
            await _prodService.AddProduct(productModel);

            return Ok("Product Added successfully");
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] ProductDto productDto)
        {
            ProductModel productModel = _mapper.Map<ProductModel>(productDto);
            bool result = await _prodService.UpdateProduct(id,productModel);

            if (result)
                return Ok("Product Updated successfully");
            else
                return NotFound("Product Not Found");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result= await _prodService.DeleteProduct(id);

            if (result)
                return Ok("Product Deleted successfully");
            else
                return NotFound("Product Not Found");
        }

        #endregion


        #region category
        [HttpGet]
        [Route("Category")]
        public async Task<IActionResult> GetAllCategories()
        {
            IEnumerable<CategoryModel> categories = await _prodService.GetAllCategories();

            IEnumerable<CategoryDto> catgList = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(catgList);
        }

        [HttpGet]
        [Route("Category/{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            CategoryModel category = await _prodService.GetCategoryById(id);

            CategoryDto catgDto = _mapper.Map<CategoryDto>(category);

            return Ok(catgDto);
        }

        [HttpPost]
        [Route("Category/Add")]
        public async Task<IActionResult> GetProductByCategoryId([FromBody] CategoryDto categoryDto)
        {
            CategoryModel categoryModel = _mapper.Map<CategoryModel>(categoryDto);
            await _prodService.AddCategory(categoryModel);

            return Ok("Category Added successfully");
        }
        #endregion

    }
}
