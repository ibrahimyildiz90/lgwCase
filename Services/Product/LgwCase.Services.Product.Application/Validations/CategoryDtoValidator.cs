using FluentValidation;
using LgwCase.Services.Product.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Application.Validations
{
    public class CategoryDtoValidator : AbstractValidator<AddCategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Category Name cannot be empty");
            RuleFor(c => c.LimitQuantity).GreaterThan(0).WithMessage("Limit Quantity must greater than 0");
        }
    }
}
