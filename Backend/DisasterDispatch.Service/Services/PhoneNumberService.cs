using DisasterDispatch.Core.Dtos.AddressDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
using DisasterDispatch.Core.Dtos.SkillDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Core.UnitOfWork;
using DisasterDispatch.Repository.Repositories;
using DisasterDispatch.Service.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Services
{
    public class PhoneNumberService : GenericService<PhoneNumber, PhoneNumberDto>, IPhoneNumberService
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        public PhoneNumberService(IUnitOfWork unitOfWork, IGenericRepository<PhoneNumber> genericRepository, IPhoneNumberRepository phoneNumberRepository) : base(unitOfWork, genericRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        public async Task<CustomResponse<PhoneNumberDto>> AddPhoneNumberAsync(PhoneNumberCreateDto phoneNumberCreateDto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<PhoneNumber>(phoneNumberCreateDto);
            await _phoneNumberRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<PhoneNumberDto>(mappedDtoToEntity);
            return CustomResponse<PhoneNumberDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<PhoneNumberDto>>> GetPhoneNumbersByUser(string userName)
        {
            var Entities = await _phoneNumberRepository.GetPhoneNumbersByUser(userName);
            var mappedEntityToDto = ObjectMapper.Mapper.Map<List<PhoneNumberDto>>(Entities);
            return CustomResponse<List<PhoneNumberDto>>.Success(mappedEntityToDto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<PhoneNumberWithUserDto>>> GetPhoneNumbersWithUsersAsync()
        {
            return CustomResponse<List<PhoneNumberWithUserDto>>.Success(ObjectMapper.Mapper.Map<List<PhoneNumberWithUserDto>>(await _phoneNumberRepository.GetPhoneNumberWithUsersAsync()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<PhoneNumberDto>> UpdateDto(PhoneNumberDto dto)
        {
            var entity = ObjectMapper.Mapper.Map<PhoneNumber>(dto);
            _phoneNumberRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            var entityToDto = ObjectMapper.Mapper.Map<PhoneNumberDto>(entity);
            return CustomResponse<PhoneNumberDto>.Success(entityToDto, StatusCodes.Status200OK);
        }
    }
}
