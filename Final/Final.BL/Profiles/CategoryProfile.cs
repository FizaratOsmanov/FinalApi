using AutoMapper;
using Final.BL.DTOs.CategoryDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryCreateDTO>();
            CreateMap<CategoryCreateDTO, Category>();
        }
    }
}
