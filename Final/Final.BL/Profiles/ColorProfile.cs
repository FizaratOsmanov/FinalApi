using AutoMapper;
using Final.BL.DTOs.ColorDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color,ColorCreateDTO>();
            CreateMap<ColorCreateDTO,Color>();
        }
    }
}
