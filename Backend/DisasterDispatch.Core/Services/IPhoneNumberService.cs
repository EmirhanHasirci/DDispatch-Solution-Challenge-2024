using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IPhoneNumberService:IGenericService<PhoneNumber,PhoneNumberDto>
    {
        Task<CustomResponse<List<PhoneNumberWithUserDto>>> GetPhoneNumbersWithUsersAsync();
        Task<CustomResponse<PhoneNumberDto>> AddPhoneNumberAsync(PhoneNumberCreateDto phoneNumberCreateDto);
        Task<CustomResponse<List<PhoneNumberDto>>> GetPhoneNumbersByUser(string userName);
        Task<CustomResponse<PhoneNumberDto>> UpdateDto(PhoneNumberDto dto);
    }
}
