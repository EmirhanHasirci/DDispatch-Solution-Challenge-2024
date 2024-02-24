using AutoMapper;
using DisasterDispatch.Core.Dtos.AddressDtos;
using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Dtos.CertificateDtos;
using DisasterDispatch.Core.Dtos.ContactDtos;
using DisasterDispatch.Core.Dtos.CustomOperationDtos;
using DisasterDispatch.Core.Dtos.DisasterCategoryDtos;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;
using DisasterDispatch.Core.Dtos.EmergencyReportDtos;
using DisasterDispatch.Core.Dtos.NeederDtos;
using DisasterDispatch.Core.Dtos.OperationEmployeeDtos;
using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
using DisasterDispatch.Core.Dtos.SkillCategoryDtos;
using DisasterDispatch.Core.Dtos.SkillDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Dtos.TitleTypeDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<AppUserDto, AppUser>().ReverseMap();     
            CreateMap<AppUser, AppUserEditDto>().ReverseMap();
            
            CreateMap<Contact, Contact>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Needer, NeederDto>().ReverseMap();
            
            
        }
    }
}
