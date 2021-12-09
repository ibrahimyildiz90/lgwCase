using LgwCase.Services.Product.Application.Dtos;
using LgwCase.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Application.Services
{
    public interface IProductService
    {
        public Task<Response<List<ProductDto>>> SearchProductByKey(string key);
        public Task<Response<List<ProductDto>>> GetProductListByQuantity(int min, int max);
        public Task<Response<NoContent>> AddCategory(AddCategoryDto category);
        public Task<Response<NoContent>> AddProduct(AddProductDto product);
    }
}
