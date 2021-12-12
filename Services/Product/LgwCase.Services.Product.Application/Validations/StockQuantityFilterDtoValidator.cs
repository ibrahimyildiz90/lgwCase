using FluentValidation;
using LgwCase.Services.Product.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Application.Validations
{
    public class StockQuantityFilterDtoValidator : AbstractValidator<StockQuantityFilterDto>
    {
        public StockQuantityFilterDtoValidator()
        {
            RuleFor(c => c.QuantityMax).GreaterThanOrEqualTo(x => x.QuantityMin).WithMessage("Max stock quantity must be greater than min stock quantity");
        }
    }
}
