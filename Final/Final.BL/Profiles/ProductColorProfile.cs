using AutoMapper;
using Final.BL.DTOs.ProductColorDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles
{
    public class ProductColorProfile:Profile
    {
        public ProductColorProfile()
        {
            CreateMap<ProductColor, ProductColorCreateDTO>();
            CreateMap<ProductColorCreateDTO, ProductColor>();
        }
    }
}
