using DisasterDispatch.Core.Dtos.CustomOperationDtos;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomOperationController : CustomBaseController
    {
        private readonly ICustomOperationService _customOperationService;

        public CustomOperationController(ICustomOperationService customOperationService)
        {
            _customOperationService = customOperationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomOperations()
        {
            return ActionResultInstance(await _customOperationService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomOperationsWithUser()
        {
            return ActionResultInstance(await _customOperationService.GetCustomOperationsWithWorkersAsync());
        }
        [HttpGet("[action]/{status}")]
        public async Task<IActionResult> GetActiveCustomOperations(string status)
        {
            return ActionResultInstance(await _customOperationService.GetActiveOperations(status));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomOperationById(string id)
        {
            return ActionResultInstance(await _customOperationService.GetByIdAsync(id));
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetOperationById(string id)
        {
            return ActionResultInstance(await _customOperationService.GetOperationById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomOperation(CustomOperationCreateDto createDto)
        {
            return ActionResultInstance(await _customOperationService.AddCustomOperationAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomOperation(CustomOperationUpdateDto updateDto)
        {
            return ActionResultInstance(await _customOperationService.UpdateCustomOperationAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCustomOperation(string id)
        {
            return ActionResultInstance(await _customOperationService.RemoveAsync(id));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeStatus(CustomOperationStatusUpdate dto)
        {
            return ActionResultInstance(await _customOperationService.ChangeStatus(dto.Id, dto.Status));
        }
    }
}
