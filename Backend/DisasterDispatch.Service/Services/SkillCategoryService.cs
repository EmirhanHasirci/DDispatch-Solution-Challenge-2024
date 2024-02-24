using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.SkillCategoryDtos;
using DisasterDispatch.Core.Dtos.TitleTypeDtos;
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
    public class SkillCategoryService : GenericService<SkillCategory, SkillCategoryDto>, ISkillCategoryService
    {
        private readonly ISkillCategoryRepository _skillCategoryRepository;
        public SkillCategoryService(IUnitOfWork unitOfWork, IGenericRepository<SkillCategory> genericRepository, ISkillCategoryRepository skillCategoryRepository) : base(unitOfWork, genericRepository)
        {
            _skillCategoryRepository = skillCategoryRepository;
        }

        public async Task<CustomResponse<SkillCategoryDto>> CreateSkillCategoryAsync(SkillCategoryCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<SkillCategory>(dto);
            await _skillCategoryRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<SkillCategoryDto>(mappedDtoToEntity);
            return CustomResponse<SkillCategoryDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<SkillCategoryDto>>> GetSkillCategoryWithSkills()
        {
            var titles = await _skillCategoryRepository.GetSkillCategoryWithSkills();
            var titlesDto = ObjectMapper.Mapper.Map<List<SkillCategoryDto>>(titles);
            return CustomResponse<List<SkillCategoryDto>>.Success(titlesDto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateSkillCategoryAsync(SkillCategoryUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<SkillCategory>(updateDto);
            _skillCategoryRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
