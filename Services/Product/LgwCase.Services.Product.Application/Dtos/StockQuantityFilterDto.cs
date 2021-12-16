using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Application.Dtos
{
    public class StockQuantityFilterDto
    {
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }
    }
}
