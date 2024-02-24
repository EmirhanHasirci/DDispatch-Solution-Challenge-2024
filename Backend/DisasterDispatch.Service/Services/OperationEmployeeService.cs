using DisasterDispatch.Core.Dtos.OperationEmployeeDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.OperationEmployeeDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Core.UnitOfWork;
using DisasterDispatch.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisasterDispatch.Service.Mapping;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;

namespace DisasterDispatch.Service.Services
{
    public class OperationEmployeeService : GenericService<OperationEmployee, OperationEmployeeDto>, IOperationEmployeeService
    {
        private readonly IOperationEmployeeRepository _operationEmployeeRepository;
        public OperationEmployeeService(IUnitOfWork unitOfWork, IGenericRepository<OperationEmployee> genericRepository, IOperationEmployeeRepository operationEmployeeRepository) : base(unitOfWork, genericRepository)
        {
            _operationEmployeeRepository = operationEmployeeRepository;
        }

        public async Task<CustomResponse<OperationEmployeeDto>> ActiveOperation(string userid)
        {
            var entites= await _operationEmployeeRepository.GetOperationByEmployeeId(userid);
            var mappedEntityToDto= ObjectMapper.Mapper.Map<OperationEmployeeDto>(entites);
            return CustomResponse<OperationEmployeeDto>.Success(mappedEntityToDto, StatusCodes.Status200OK);

        }

        public async Task<CustomResponse<OperationEmployeeDto>> AddOperationEmployeeAsync(OperationEmployeeCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<OperationEmployee>(dto);
            await _operationEmployeeRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<OperationEmployeeDto>(mappedDtoToEntity);
            return CustomResponse<OperationEmployeeDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<OperationEmployeeDto>>> AddRange(List<OperationEmployeeCreateDto> operations)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<List<OperationEmployee>>(operations);
            await _operationEmployeeRepository.AddRangeAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var mappedEntityToDto = ObjectMapper.Mapper.Map<List<OperationEmployeeDto>>(mappedDtoToEntity);
            return CustomResponse<List<OperationEmployeeDto>>.Success(mappedEntityToDto,StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<OperationEmployeeWithCustomOperationAndUser>>> GetOperationEmployeesWithCustomOperationAndUserAsync()
        {
            return CustomResponse<List<OperationEmployeeWithCustomOperationAndUser>>.Success(ObjectMapper.Mapper.Map<List<OperationEmployeeWithCustomOperationAndUser>>(await _operationEmployeeRepository.GetOperationEmployeesWithCustomOperationAndUserAsync()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<OperationEmployeeDto>>> GetOperationsByUser(string id)
        {
            var entity = await _operationEmployeeRepository.GetOperationEmployeesWithCustomOperationAndUserAsync();
            var mappedEntityToDto = ObjectMapper.Mapper.Map<List<OperationEmployeeDto>>(entity.Where(x=>x.AppUserId==id));
            return CustomResponse<List<OperationEmployeeDto>>.Success(mappedEntityToDto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<OperationEmployeeDto>>> OnMissionUsers(string id)
        {
            var entity =await _operationEmployeeRepository.GetOperationEmployeesWithCustomOperationAndUserAsync();
            var entityList = entity.Where(x => x.CustomOperationId == Guid.Parse(id)).ToList();
            var mappedEntityToDto = ObjectMapper.Mapper.Map<List<OperationEmployeeDto>>(entityList);
            return CustomResponse<List<OperationEmployeeDto>>.Success(mappedEntityToDto, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateOperationEmployeeAsync(OperationEmployeeUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<OperationEmployee>(updateDto);
            _operationEmployeeRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
