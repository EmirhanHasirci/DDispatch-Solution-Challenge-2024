using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.EmergencyReportDtos;
using DisasterDispatch.Core.Dtos.SkillDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface IEmergencyReportService:IGenericService<EmergencyReport,EmergencyReportDto>
    {
        Task<CustomResponse<NoContentDto>> UpdateEmergencyReportAsync(EmergencyReportUpdateDto updateDto);
        Task<CustomResponse<EmergencyReportDto>> AddEmergencyReportAsync(EmergencyReportCreateDto dto);
        Task<CustomResponse<List<EmergencyReportWithCustomOperationsDto>>> GetEmergencyReportsWithCustomOperationsAsync();
        Task<CustomResponse<EmergencyReportDto>> ChangeStatus(string id,string status);
    }
}
