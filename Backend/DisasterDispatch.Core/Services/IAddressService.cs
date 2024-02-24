using DisasterDispatch.Core.Dtos.AddressDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.AddressDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IAddressService:IGenericService<Address,AddressDto>
    {
        Task<CustomResponse<AddressDto>> UpdateAddressAsync(AddressDto updateDto);
        Task<CustomResponse<AddressCreateDto>> AddAddressAsync(AddressCreateDto dto);
        Task<CustomResponse<List<AddressWithUserDto>>> GetAddresssWithUsersAsync();
        Task<CustomResponse<List<AddressDto>>>GetAddressesByUsername(string username);
    }
}
