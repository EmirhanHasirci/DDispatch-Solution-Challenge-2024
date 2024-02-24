using AutoMapper;
using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.CustomOperationDtos;
using DisasterDispatch.Core.Dtos.CustomOperationDtos;
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
    public class CustomOperationService : GenericService<CustomOperation, CustomOperationDto>, ICustomOperationService
    {
        private readonly ICustomOperationRepository _customOperationRepository;

        public CustomOperationService(IUnitOfWork unitOfWork, IGenericRepository<CustomOperation> genericRepository, ICustomOperationRepository customOperationRepository) : base(unitOfWork, genericRepository)
        {
            _customOperationRepository = customOperationRepository;
        }

        public async Task<CustomResponse<CustomOperationDto>> AddCustomOperationAsync(CustomOperationCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<CustomOperation>(dto);
            mappedDtoToEntity.Status = "Active";
            await _customOperationRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<CustomOperationDto>(mappedDtoToEntity);
            return CustomResponse<CustomOperationDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<CustomOperationDto>>> GetActiveOperations(string status)
        {
            var entities = await _customOperationRepository.GetActiveOperations(status);
            var mappedEntityToDto = ObjectMapper.Mapper.Map<List<CustomOperationDto>>(entities);
            return CustomResponse<List<CustomOperationDto>>.Success(mappedEntityToDto, StatusCodes.Status200OK);
        }
        public async Task<CustomResponse<CustomOperationDto>> GetOperationById(string id)
        {
            var entities = await _customOperationRepository.GetOperationById(id);
            var mappedEntityToDto = ObjectMapper.Mapper.Map<CustomOperationDto>(entities);
            return CustomResponse<CustomOperationDto>.Success(mappedEntityToDto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<CustomOperationWithWorkersDto>>> GetCustomOperationsWithWorkersAsync()
        {

            return CustomResponse<List<CustomOperationWithWorkersDto>>.Success(ObjectMapper.Mapper.Map<List<CustomOperationWithWorkersDto>>(await _customOperationRepository.GetCustomOperationsWithWorkersAsync()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateCustomOperationAsync(CustomOperationUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<CustomOperation>(updateDto);
            _customOperationRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponse<CustomOperationDto>> ChangeStatus(string id, string status)
        {
            var customOperationResponse = await GetByIdAsync(id);
            var customOperationdto = customOperationResponse.Data;
            customOperationdto.Status = status;            
            await UpdateAsync(customOperationdto);
            return CustomResponse<CustomOperationDto>.Success(ObjectMapper.Mapper.Map<CustomOperationDto>(customOperationdto), StatusCodes.Status200OK);
        }
    }
}
