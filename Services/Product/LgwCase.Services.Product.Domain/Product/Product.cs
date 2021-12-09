using LgwCase.Services.Product.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Domain.Product
{
    public class Product : Entity    {

        public string Title { get; private set; }
        public string Description { get; private set; }
        //public int CategoryId { get; private set; }
        public int StockQuantity { get; private set; }

        public Category Category;

        public Product(int id, string title, string description/*, int categoryId*/, int stockQuantity, Category category)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            //CategoryId = categoryId;
            StockQuantity = stockQuantity;
            Category = category;
        }
    }
}
