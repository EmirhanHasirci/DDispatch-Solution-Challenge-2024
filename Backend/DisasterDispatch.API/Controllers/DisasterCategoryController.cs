using DisasterDispatch.Core.Dtos.DisasterCategoryDtos;
using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisasterCategoryController : CustomBaseController
    {
        private readonly IDisasterCategoryService _disasterCategoryService;

        public DisasterCategoryController(IDisasterCategoryService disasterCategoryService)
        {
            _disasterCategoryService = disasterCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDisasterCategories()
        {
            return ActionResultInstance(await _disasterCategoryService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetDisasterCategoryWithDisasterOperation()
        {
            return ActionResultInstance(await _disasterCategoryService.GetDisasterCategoryWithDisasterOperations());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisasterCategoryById(string id)
        {
            return ActionResultInstance(await _disasterCategoryService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddDisasterCategory(DisasterCategoryCreateDto createDto)
        {
            return ActionResultInstance(await _disasterCategoryService.AddDisasterCategoryAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDisasterCategory(DisasterCategoryUpdateDto updateDto)
        {
            return ActionResultInstance(await _disasterCategoryService.UpdateDisasterCategoryAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDisasterCategory(string id)
        {
            return ActionResultInstance(await _disasterCategoryService.RemoveAsync(id));
        }
    }
}
