using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
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
    public class TitleTypeService : GenericService<TitleType, TitleTypeDto>, ITitleTypeService
    {
        private readonly ITitleTypeRepository _titleTypeRepository;
        public TitleTypeService(IUnitOfWork unitOfWork, ITitleTypeRepository titleTypeRepository, IGenericRepository<TitleType> genericRepository) : base(unitOfWork, genericRepository)
        {
            _titleTypeRepository = titleTypeRepository;
        }

        public async Task<CustomResponse<TitleTypeDto>> CreateTitleTypeAsync(TitleTypeCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<TitleType>(dto);
            await _titleTypeRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<TitleTypeDto>(mappedDtoToEntity);
            return CustomResponse<TitleTypeDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<TitleTypeDto>>> GetTitleTypesWithTitles()
        {
            var titles = await _titleTypeRepository.GetTitleTypesWithTitles();
            var titlesDto = ObjectMapper.Mapper.Map<List<TitleTypeDto>>(titles);
            return CustomResponse<List<TitleTypeDto>>.Success(titlesDto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateTitleTypeAsync(TitleTypeUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<TitleType>(updateDto);
            _titleTypeRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);

        }
    }
}
