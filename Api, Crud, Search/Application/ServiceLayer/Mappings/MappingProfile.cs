using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductListDto>();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
        }
    }
}
