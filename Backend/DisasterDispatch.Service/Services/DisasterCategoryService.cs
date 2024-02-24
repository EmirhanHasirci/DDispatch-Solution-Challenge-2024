using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.DisasterCategoryDtos;
using DisasterDispatch.Core.Dtos.SkillDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
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
    public class DisasterCategoryService : GenericService<DisasterCategory, DisasterCategoryDto>, IDisasterCategoryService
    {
        private readonly IDisasterCategoryRepository _disasterCategoryRepository;

        public DisasterCategoryService(IUnitOfWork unitOfWork, IGenericRepository<DisasterCategory> genericRepository, IDisasterCategoryRepository disasterCategoryRepository) : base(unitOfWork, genericRepository)
        {
            _disasterCategoryRepository = disasterCategoryRepository;
        }

        public async Task<CustomResponse<DisasterCategoryDto>> AddDisasterCategoryAsync(DisasterCategoryCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<DisasterCategory>(dto);
            await _disasterCategoryRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<DisasterCategoryDto>(mappedDtoToEntity);
            return CustomResponse<DisasterCategoryDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<DisasterCategoryWithDisasterOperationsDto>>> GetDisasterCategoryWithDisasterOperations()
        {
            return CustomResponse<List<DisasterCategoryWithDisasterOperationsDto>>.Success(ObjectMapper.Mapper.Map<List<DisasterCategoryWithDisasterOperationsDto>>(await _disasterCategoryRepository.GetDisasterCategoriesWithDisasterOperationsAsync()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateDisasterCategoryAsync(DisasterCategoryUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<DisasterCategory>(updateDto);
            _disasterCategoryRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
