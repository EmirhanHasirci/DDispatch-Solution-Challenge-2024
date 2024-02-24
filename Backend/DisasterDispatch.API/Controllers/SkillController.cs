using DisasterDispatch.Core.Dtos.SkillDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : CustomBaseController
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            return ActionResultInstance(await _skillService.GetSkillsWithCategoriesAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSkillsWithUser()
        {
            return ActionResultInstance(await _skillService.GetSkillsWithUsersAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(string id)
        {
            return ActionResultInstance(await _skillService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddSkill(SkillCreateDto createDto)
        {
            return ActionResultInstance(await _skillService.AddSkillAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSkill(SkillUpdateDto updateDto)
        {
            return ActionResultInstance(await _skillService.UpdateSkillAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSkill(string id)
        {
            return ActionResultInstance(await _skillService.RemoveAsync(id));
        }
    }
}
