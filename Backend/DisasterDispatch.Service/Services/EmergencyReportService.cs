using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;
using DisasterDispatch.Core.Dtos.EmergencyReportDtos;
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
    public class EmergencyReportService : GenericService<EmergencyReport, EmergencyReportDto>,IEmergencyReportService
    {
        private readonly IEmergencyReportRepository _emergencyReportRepository;
        public EmergencyReportService(IUnitOfWork unitOfWork, IGenericRepository<EmergencyReport> genericRepository, IEmergencyReportRepository emergencyReportRepository) : base(unitOfWork, genericRepository)
        {
            _emergencyReportRepository = emergencyReportRepository;
        }

        public async Task<CustomResponse<EmergencyReportDto>> AddEmergencyReportAsync(EmergencyReportCreateDto dto)
        {
            var entity = ObjectMapper.Mapper.Map<EmergencyReport>(dto);
            entity.Status = "Active";
            await _emergencyReportRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            var resultEntity = ObjectMapper.Mapper.Map<EmergencyReportDto>(entity);
            return CustomResponse<EmergencyReportDto>.Success(resultEntity, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<EmergencyReportDto>> ChangeStatus(string id, string status)
        {
           var emergencyReportResponse=await GetByIdAsync(id);
            var emergencyReportdto = emergencyReportResponse.Data;
            emergencyReportdto.Status = status;
            var emergencyReport = ObjectMapper.Mapper.Map<EmergencyReport>(emergencyReportdto);
            await UpdateAsync(emergencyReportdto);
            return CustomResponse<EmergencyReportDto>.Success(ObjectMapper.Mapper.Map<EmergencyReportDto>(emergencyReport), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<EmergencyReportWithCustomOperationsDto>>> GetEmergencyReportsWithCustomOperationsAsync()
        {
            return CustomResponse<List<EmergencyReportWithCustomOperationsDto>>.Success(ObjectMapper.Mapper.Map<List<EmergencyReportWithCustomOperationsDto>>(await _emergencyReportRepository.GetEmergencyReportsWithCustomOperationsAsync()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateEmergencyReportAsync(EmergencyReportUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<EmergencyReport>(updateDto);
            _emergencyReportRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
