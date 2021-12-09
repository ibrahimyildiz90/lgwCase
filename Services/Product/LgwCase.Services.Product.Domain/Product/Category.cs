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
        public Category()
        {

        }
        public string Name { get; private set; }
        public int LimitQuantity { get; private set; }

        public Category(string name, int limitQuantity)
        {
            Name = name;
            LimitQuantity = limitQuantity;
        }
    }
}
