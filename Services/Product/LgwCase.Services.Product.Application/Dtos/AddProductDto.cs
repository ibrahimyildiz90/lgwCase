using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Application.Dtos
{
    public class AddProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int StockQuantity { get; set; }
    }
}
