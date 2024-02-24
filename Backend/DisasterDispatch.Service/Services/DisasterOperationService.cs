using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.DisasterCategoryDtos;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Core.UnitOfWork;
using DisasterDispatch.Repository.Repositories;
using DisasterDispatch.Service.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Services
{
    public class DisasterOperationService : GenericService<DisasterOperation, DisasterOperationDto>,IDisasterOperationService
    {
        private readonly IDisasterOperationRepository _disasterOperationRepository;
        public DisasterOperationService(IUnitOfWork unitOfWork, IGenericRepository<DisasterOperation> genericRepository, IDisasterOperationRepository disasterOperationRepository) : base(unitOfWork, genericRepository)
        {
            _disasterOperationRepository = disasterOperationRepository;
        }



        public async Task<CustomResponse<DisasterOperationDto>> AddDisasterOperationAsync(DisasterOperationCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<DisasterOperation>(dto);

            await _disasterOperationRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<DisasterOperationDto>(mappedDtoToEntity);
            return CustomResponse<DisasterOperationDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<DisasterOperationDto>>> DisasterOperationAddRangeAsync(List<DisasterOperationCreateDto> disasterOperationCreateDto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<List<DisasterOperation>>(disasterOperationCreateDto);
            await _disasterOperationRepository.AddRangeAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var mappedEntityToDto = ObjectMapper.Mapper.Map<List<DisasterOperationDto>>(mappedDtoToEntity);
            return CustomResponse<List<DisasterOperationDto>>.Success(mappedEntityToDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<DisasterOperationWithAssignerAndCategoryDto>>> GetDisasterOperationWithAssignerAndCategoryAsync()
        {
            return CustomResponse<List<DisasterOperationWithAssignerAndCategoryDto>>.Success(ObjectMapper.Mapper.Map<List<DisasterOperationWithAssignerAndCategoryDto>>(await _disasterOperationRepository.GetDisasterOperationsWithUserAndCategories()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateDisasterOperationAsync(DisasterOperationUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<DisasterOperation>(updateDto);
            _disasterOperationRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
