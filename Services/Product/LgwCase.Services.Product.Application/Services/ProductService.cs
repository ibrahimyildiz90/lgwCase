using AutoMapper.Configuration;
using LgwCase.Services.Product.Application.Dtos;
using LgwCase.Services.Product.Application.Mapping;
using LgwCase.Services.Product.Infrastructure;
using LgwCase.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Application.Services
{
    public class ProductService : IProductService
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public ProductService(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<Response<List<ProductDto>>> SearchProductByKey(string key)
        {
            /*return new Response<List<ProductDto>>();*/

            using (var context = new LgwDbContex(Configuration))
            {
                var productList = await context.Products.Where(x => x.Title == key).ToListAsync();

                if (productList == null)
                    return Response<List<ProductDto>>.Fail("Product not found", 404);

                var productDto = ObjectMapper.Mapper.Map<List<ProductDto>>(productList);
                return Response<List<ProductDto>>.Success(productDto, 200);
            }
        }
    }
}
