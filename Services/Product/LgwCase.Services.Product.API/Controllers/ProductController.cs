using LgwCase.Services.Product.Application.Services;
using LgwCase.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> SearchProduct(string key)
        {
            var response = await _productService.SearchProductByKey(key);
            
            return CreateActionResultInstance(response);
        }
    }
}
