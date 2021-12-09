using LgwCase.Services.Product.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Domain.Product
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int LimitQuantity { get; set; }

    }
}
