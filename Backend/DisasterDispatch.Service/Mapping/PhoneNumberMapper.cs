using AutoMapper;
using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class PhoneNumberMapper:Profile
    {
        public PhoneNumberMapper()
        {
            CreateMap<PhoneNumber, PhoneNumberCreateDto>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumberDto>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumberWithUserDto>().ReverseMap();
        }
    }
}
