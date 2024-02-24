using AutoMapper;
using DisasterDispatch.Core.Dtos.AddressDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class AddressMapper:Profile
    {
        public AddressMapper()
        {
            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressUpdateDto>().ReverseMap();
            CreateMap<Address, AddressWithUserDto>().ReverseMap();
        }
    }
}
