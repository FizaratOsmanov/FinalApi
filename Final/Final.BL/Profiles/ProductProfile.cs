using AutoMapper;
using Final.BL.DTOs.ProductDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductCreateDTO>();
            CreateMap<ProductCreateDTO, Product>();
        }
    }
}
