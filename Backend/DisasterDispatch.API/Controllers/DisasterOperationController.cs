using DisasterDispatch.Core.Dtos.DisasterCategoryDtos;
using DisasterDispatch.Core.Dtos.DisasterOperationDtos;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisasterOperationController : CustomBaseController
    {
        private readonly IDisasterOperationService _disasterOperationService;

        public DisasterOperationController(IDisasterOperationService disasterOperationService)
        {
            _disasterOperationService = disasterOperationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDisasterOperations()
        {
            return ActionResultInstance(await _disasterOperationService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetDisasterOperationWithAssignerAndCategory()
        {
            return ActionResultInstance(await _disasterOperationService.GetDisasterOperationWithAssignerAndCategoryAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisasterOperationById(string id)
        {
            return ActionResultInstance(await _disasterOperationService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddDisasterOperation(DisasterOperationCreateDto createDto)
        {
            return ActionResultInstance(await _disasterOperationService.AddDisasterOperationAsync(createDto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DisasterOperationAddRangeAsync(List<DisasterOperationCreateDto> disasterOperationCreateDtos)
        {
            return ActionResultInstance(await _disasterOperationService.DisasterOperationAddRangeAsync(disasterOperationCreateDtos));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDisasterOperation(DisasterOperationUpdateDto updateDto)
        {
            return ActionResultInstance(await _disasterOperationService.UpdateDisasterOperationAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDisasterOperation(string id)
        {
            return ActionResultInstance(await _disasterOperationService.RemoveAsync(id));
        }
    }
}
