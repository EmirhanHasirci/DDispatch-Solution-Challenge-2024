using DisasterDispatch.Core.Dtos.EmergencyReportDtos;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyReportController : CustomBaseController
    {
        private readonly IEmergencyReportService _emergencyReportService;

        public EmergencyReportController(IEmergencyReportService emergencyReportService)
        {
            _emergencyReportService = emergencyReportService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmergencyReports()
        {
            return ActionResultInstance(await _emergencyReportService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmergencyReportsWithCustomOperations()
        {
            return ActionResultInstance(await _emergencyReportService.GetEmergencyReportsWithCustomOperationsAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmergencyReportById(string id)
        {
            return ActionResultInstance(await _emergencyReportService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddEmergencyReport(EmergencyReportCreateDto createDto)
        {
            return ActionResultInstance(await _emergencyReportService.AddEmergencyReportAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDisasterCategory(EmergencyReportUpdateDto updateDto)
        {
            return ActionResultInstance(await _emergencyReportService.UpdateEmergencyReportAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDisasterCategory(string id)
        {
            return ActionResultInstance(await _emergencyReportService.RemoveAsync(id));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeStatus(EmergencyReportStatusUpdate dto)
        {
            return ActionResultInstance(await _emergencyReportService.ChangeStatus(dto.Id, dto.Status));
        }

    }
}
