using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Dtos.TitleTypeDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleTypeController : CustomBaseController
    {
        private readonly ITitleTypeService _titleTypeService;

        public TitleTypeController(ITitleTypeService titleTypeService)
        {
            _titleTypeService = titleTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTitleTypes()
        {
            return ActionResultInstance(await _titleTypeService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTitleTypesWithTitles()
        {
            return ActionResultInstance(await _titleTypeService.GetTitleTypesWithTitles());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitleById(string id)
        {
            return ActionResultInstance(await _titleTypeService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddTitleType(TitleTypeCreateDto createDto)
        {
            return ActionResultInstance(await _titleTypeService.CreateTitleTypeAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTitleType(TitleTypeUpdateDto updateDto)
        {
            return ActionResultInstance(await _titleTypeService.UpdateTitleTypeAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTitleType(string id)
        {
            return ActionResultInstance(await _titleTypeService.RemoveAsync(id));
        }

    }
}
