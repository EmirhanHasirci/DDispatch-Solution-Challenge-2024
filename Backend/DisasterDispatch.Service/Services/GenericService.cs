using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DisasterDispatch.Core.Repositories;
using System.Threading.Tasks;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Core.UnitOfWork;
using System.Linq.Expressions;
using DisasterDispatch.Service.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DisasterDispatch.Core.Entities.Common;
using DisasterDispatch.Core.Dtos.BaseDtos;

namespace DisasterDispatch.Service.Services
{
    public class GenericService<TEntity,TDto>:IGenericService<TEntity,TDto> where TEntity : BaseEntity where TDto : class
    {
        public IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<CustomResponse<TDto>> AddAsync(TDto dto)
        {
            var entity = ObjectMapper.Mapper.Map<TEntity>(dto);
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            var dtoResponse = ObjectMapper.Mapper.Map<TDto>(entity);
            return CustomResponse<TDto>.Success(dtoResponse, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> dtos)
        {
            var entities = ObjectMapper.Mapper.Map<IEnumerable<TEntity>>(dtos);
            await _genericRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            var dtoResponse = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(entities);
            return CustomResponse<IEnumerable<TDto>>.Success(dtoResponse, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<bool>> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            var anyEntity = await _genericRepository.AnyAsync(expression);
            return CustomResponse<bool>.Success(anyEntity, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = await _genericRepository.GetAll().ToListAsync();
            var dtoResponse = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(entities);
            return CustomResponse<IEnumerable<TDto>>.Success(dtoResponse, StatusCodes.Status200OK);
                
        }

        public async Task<CustomResponse<TDto>> GetByIdAsync(string id)
        {
            var entity = await _genericRepository.Where(x=>x.Id==Guid.Parse(id)).FirstOrDefaultAsync(); 
            var dto = ObjectMapper.Mapper.Map<TDto>(entity);
            return CustomResponse<TDto>.Success(dto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> RemoveAsync(string id)
        {
            var entity = await _genericRepository.Where(x => x.Id == Guid.Parse(id)).FirstOrDefaultAsync();
            if (entity is null)
                return CustomResponse<NoContentDto>.Fail("Id not found", 404);

            _genericRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);            
        }

        public async Task<CustomResponse<NoContentDto>> RemoveRangeAsync(IEnumerable<string> ids)
        {
            var idsParse = ids.Select(x=>Guid.Parse(x)).ToList();
            var entities = await _genericRepository.Where(x => idsParse.Contains(x.Id)).ToListAsync();
            _genericRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateAsync(TDto dto)
        {
            var entity = ObjectMapper.Mapper.Map<TEntity>(dto);
            _genericRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponse<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression)
        {
            var entites = await _genericRepository.Where(expression).ToListAsync();
            var dtos = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(entites);
            return CustomResponse<IEnumerable<TDto>>.Success(dtos, StatusCodes.Status200OK);

        }
    }
}
