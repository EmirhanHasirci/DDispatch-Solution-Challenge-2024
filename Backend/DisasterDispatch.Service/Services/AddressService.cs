using DisasterDispatch.Core.Dtos.AddressDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
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
    public class AddressService : GenericService<Address, AddressDto>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IUnitOfWork unitOfWork, IGenericRepository<Address> genericRepository, IAddressRepository addressRepository) : base(unitOfWork, genericRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<CustomResponse<AddressCreateDto>> AddAddressAsync(AddressCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<Address>(dto);
            await _addressRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<AddressCreateDto>(mappedDtoToEntity);
            return CustomResponse<AddressCreateDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<AddressDto>>> GetAddressesByUsername(string username)
        {
            var Entities = await _addressRepository.GetAddressesByUsername(username);
            var mappedEntityToDto = ObjectMapper.Mapper.Map<List<AddressDto>>(Entities);
            return CustomResponse<List<AddressDto>>.Success(mappedEntityToDto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<AddressWithUserDto>>> GetAddresssWithUsersAsync()
        {
            return CustomResponse<List<AddressWithUserDto>>.Success(ObjectMapper.Mapper.Map<List<AddressWithUserDto>>(await _addressRepository.GetAddressesWithUserAsync()), StatusCodes.Status200OK);
        }

        
        public async Task<CustomResponse<AddressDto>> UpdateAddressAsync(AddressDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<Address>(updateDto);
            _addressRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            var entityToDto= ObjectMapper.Mapper.Map<AddressDto>(entity);
            return CustomResponse<AddressDto>.Success(entityToDto,StatusCodes.Status200OK);
        }
    }
}
