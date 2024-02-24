using DisasterDispatch.Core.Dtos.BaseDtos;
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
    public class SkillService : GenericService<Skill, SkillDto>, ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(IUnitOfWork unitOfWork, IGenericRepository<Skill> genericRepository, ISkillRepository skillRepository) : base(unitOfWork, genericRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<CustomResponse<SkillDto>> AddSkillAsync(SkillCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<Skill>(dto);
            await _skillRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<SkillDto>(mappedDtoToEntity);
            return CustomResponse<SkillDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<SkillDto>>> GetSkillsWithCategoriesAsync()
        {
            return CustomResponse<List<SkillDto>>.Success(ObjectMapper.Mapper.Map<List<SkillDto>>(await _skillRepository.GetSkillsWithCategories()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<SkillWithUsersDto>>> GetSkillsWithUsersAsync()
        {
            return CustomResponse<List<SkillWithUsersDto>>.Success(ObjectMapper.Mapper.Map<List<SkillWithUsersDto>>(await _skillRepository.GetSkillsWithUser()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateSkillAsync(SkillUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<Skill>(updateDto);
            _skillRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
