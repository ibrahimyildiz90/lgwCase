using FluentValidation;
using LgwCase.Services.Product.Application.Dtos;
using LgwCase.Services.Product.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Application.Validations
{
    public class ProductDtoValidator : AbstractValidator<AddProductDto>
    {
        public ProductDtoValidator(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            RuleFor(c => c.Title).NotEmpty().WithMessage("Title cannot be empty");
            RuleFor(c => c.Title).MaximumLength(200).WithMessage("Title can be maximum 200 character");
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("CategoryId cannot be empty");
            RuleFor(c => c.CategoryId)
                .Must((o, category) => { return CheckCategoryId(o.CategoryId.Value, configuration); })
                .WithMessage("Wrong CategoryId");
              
            RuleFor(c => c.CategoryId)
                .Must((o, category) => { return CheckQuantityControl(o.CategoryId.Value, o.StockQuantity, configuration); })
                .WithMessage($"Stock quantity cannot under category quantity stock limit.");

        }

        private bool CheckQuantityControl(int categoryId, int stockQuantity, IConfiguration configuration)
        {
            using (var context = new LgwDbContex(configuration))
            {
                var category = context.Categories.SingleOrDefault(x => x.Id == categoryId);
                if (category == null)
                    return false;

                var categoryMinStockQuantity = category.LimitQuantity;

                if (stockQuantity <= categoryMinStockQuantity)
                {
                    return false;
                }

                return true;
            }
        }

        private bool CheckCategoryId(int? categoryId, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            using (var context = new LgwDbContex(configuration))
            {
                var category = context.Categories.SingleOrDefault(x => x.Id == categoryId);
                if (category == null)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
