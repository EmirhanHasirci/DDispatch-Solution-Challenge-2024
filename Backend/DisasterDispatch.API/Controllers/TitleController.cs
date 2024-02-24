using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : CustomBaseController
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTitles()
        {
            return ActionResultInstance(await _titleService.GetTitlesWithTypes());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTitlesWithUser()
        {
            return ActionResultInstance(await _titleService.GetTitlesWithUser());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitleById(string id)
        {
            return ActionResultInstance(await _titleService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddTitle(TitleCreateDto createDto)
        {
            return ActionResultInstance(await _titleService.AddTitle(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTitle(TitleUpdateDto updateDto)
        {
            return ActionResultInstance(await _titleService.UpdateAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTitle(string id)
        {
            return ActionResultInstance(await _titleService.RemoveAsync(id));
        }
    }
}
