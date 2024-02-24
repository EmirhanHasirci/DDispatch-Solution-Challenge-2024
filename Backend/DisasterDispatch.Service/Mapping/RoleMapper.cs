using AutoMapper;
using DisasterDispatch.Core.Dtos.AppRoleDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class RoleMapper:Profile
    {
        public RoleMapper()
        {
            CreateMap<AppRole, AppRoleCreateDto>().ReverseMap();
            CreateMap<AppRole, AppRoleDto>().ReverseMap();
        }
    }
}
