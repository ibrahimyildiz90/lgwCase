using AutoMapper.Configuration;
using LgwCase.Services.Product.Application.Dtos;
using LgwCase.Services.Product.Application.Mapping;
using LgwCase.Services.Product.Domain.Product;
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
            try
            {
                using (var context = new LgwDbContex(Configuration))
                {
                    var productList = await context.Products.Include(x => x.Category)
                                .Where(x => x.Title.ToUpper().Contains(key.ToUpper()) ||
                                            x.Description.ToUpper().Contains(key.ToUpper()) ||
                                            x.Category.Name.ToUpper().Contains(key.ToUpper()))
                                .ToListAsync();

                    if (productList.Count == 0)
                        return Response<List<ProductDto>>.Fail("Product not found", 404);

                    var productDto = ObjectMapper.Mapper.Map<List<ProductDto>>(productList);
                    return Response<List<ProductDto>>.Success(productDto, 200);
                }
            }
            catch (Exception ex)
            {

                return Response<List<ProductDto>>.Fail("unexpected error occurred ", 500);
            }
        }
        public async Task<Response<List<ProductDto>>> GetProductListByQuantity(int min, int max)
        {
            try
            {
                if (min >= max)
                    return Response<List<ProductDto>>.Fail("Max stock quantity must be greater than min stock quantity", 500);

                using (var context = new LgwDbContex(Configuration))
                {

                    var productList = await context.Products.Include(x => x.Category)
                                .Where(x => x.StockQuantity >= min && x.StockQuantity <= max)
                                .ToListAsync();

                    if (productList.Count == 0)
                        return Response<List<ProductDto>>.Fail("Product not found", 404);

                    var productDto = ObjectMapper.Mapper.Map<List<ProductDto>>(productList);
                    return Response<List<ProductDto>>.Success(productDto, 200);
                }
            }
            catch (Exception ex)
            {

                return Response<List<ProductDto>>.Fail("unexpected error occurred ", 500);
            }

        }

        public async Task<Response<NoContent>> AddCategory(AddCategoryDto categoryDto)
        {
            try
            {
                if (String.IsNullOrEmpty(categoryDto.Name) || categoryDto.LimitQuantity <= 0)
                {
                    return Response<NoContent>.Fail("Check category name or limit quantity", 500);
                }

                var category = ObjectMapper.Mapper.Map<Category>(categoryDto);

                using (var context = new LgwDbContex(Configuration))
                {
                    context.Add(category);
                    await context.SaveChangesAsync();

                    return Response<NoContent>.Success(200);
                }
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail("unexpected error occurred ", 500);
            }
        }

        public async Task<Response<NoContent>> AddProduct(AddProductDto productDto)
        {
            try
            {
                if (String.IsNullOrEmpty(productDto.Title))
                {
                    return Response<NoContent>.Fail("Title cannot be emty", 500);
                }
                if (productDto.Title.Length > 200)
                {
                    return Response<NoContent>.Fail("Title must be maxium 200 character", 500);
                }

                if (productDto.CategoryId == null)
                {
                    return Response<NoContent>.Fail("Category cannot be emty", 500);
                }

                int categoryMinStockQuantity = 0;

                using (var context = new LgwDbContex(Configuration))
                {
                    var category = await context.Categories.SingleAsync(x => x.Id == productDto.CategoryId);
                    categoryMinStockQuantity = category.LimitQuantity;

                    if (productDto.StockQuantity <= categoryMinStockQuantity)
                    {
                        return Response<NoContent>.Fail($"StockQuantity cannot under {categoryMinStockQuantity}", 500);
                    }

                    var product = ObjectMapper.Mapper.Map<Domain.Product.Product>(productDto);

                    context.Add(product);
                    await context.SaveChangesAsync();

                    return Response<NoContent>.Success(200);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
