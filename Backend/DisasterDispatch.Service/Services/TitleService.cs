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
    public class TitleService : GenericService<Title, TitleDto>, ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        public TitleService(IUnitOfWork unitOfWork, IGenericRepository<Title> genericRepository, ITitleRepository titleRepository) : base(unitOfWork, genericRepository)
        {
            _titleRepository = titleRepository;
        }

        public async Task<CustomResponse<TitleDto>> AddTitle(TitleCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<Title>(dto);
            await _titleRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<TitleDto>(mappedDtoToEntity);
            return CustomResponse<TitleDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<TitleDto>>> GetTitlesWithTypes()
        {
            return CustomResponse<List<TitleDto>>.Success(ObjectMapper.Mapper.Map <List<TitleDto>>(await _titleRepository.GetTitlesWithTypes()),StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<TitleWithUserDto>>> GetTitlesWithUser()
        {
            var titles = await _titleRepository.GetTitlesWithUser();
            var titlesDto = ObjectMapper.Mapper.Map<List<TitleWithUserDto>>(titles);
            return CustomResponse<List<TitleWithUserDto>>.Success(titlesDto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateAsync(TitleUpdateDto dto)
        {
            var entity = ObjectMapper.Mapper.Map<Title>(dto);
            _titleRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
