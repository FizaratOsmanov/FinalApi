using AutoMapper;
using Final.BL.DTOs.SizeDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles
{
    public class SizeProfile:Profile
    {
        public SizeProfile()
        {
            CreateMap<Size,SizeCreateDTO>();
            CreateMap<SizeCreateDTO, Size>();
        }
    }
}
