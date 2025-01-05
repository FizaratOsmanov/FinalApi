using AutoMapper;
using Final.BL.DTOs.AppUserDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserCreateDTO>();
            CreateMap<AppUserCreateDTO, AppUser>();

        }
    }
}
