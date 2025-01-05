using AutoMapper;
using Final.BL.DTOs.ProductSizeDTOs;
using Final.Core.Entities;

namespace Final.BL.Profiles
{
    public class ProductSizeProfile:Profile
    {
        public ProductSizeProfile()
        {
            CreateMap<ProductSize,ProductSizeCreateDTO>();
            CreateMap<ProductSizeCreateDTO, ProductSize>();
        }
    }
}
