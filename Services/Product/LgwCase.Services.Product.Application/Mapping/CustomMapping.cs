using AutoMapper;
using LgwCase.Services.Product.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgwCase.Services.Product.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.Product.Category, CategoryDto>().ReverseMap(); ;
            CreateMap<CategoryDto, Domain.Product.Category>().ReverseMap(); ;
            CreateMap<AddCategoryDto, Domain.Product.Category>().ReverseMap();  
        }

    }
}
