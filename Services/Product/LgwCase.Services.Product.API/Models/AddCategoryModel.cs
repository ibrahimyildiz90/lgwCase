using LgwCase.Services.Product.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.API.Models
{
    public class AddCategoryModel
    {
        public string Name { get; set; }
        public int LimitQuantity { get; set; }
        //public AddCategoryDto category { get; set; }
    }
}
