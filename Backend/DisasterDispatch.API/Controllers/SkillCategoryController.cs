using DisasterDispatch.Core.Dtos.SkillCategoryDtos;
using DisasterDispatch.Core.Dtos.TitleTypeDtos;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoryController : CustomBaseController
    {
        private readonly ISkillCategoryService _skillCategoryService;

        public SkillCategoryController(ISkillCategoryService skillCategoryService)
        {
            this._skillCategoryService = skillCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkillCategories()
        {
            return ActionResultInstance(await _skillCategoryService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillCategoryById(string id)
        {
            return ActionResultInstance(await _skillCategoryService.GetByIdAsync(id));
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetSkillCategoryWithSkills()
        {
            return ActionResultInstance(await _skillCategoryService.GetSkillCategoryWithSkills());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkillCategory(SkillCategoryCreateDto createDto)
        {
            return ActionResultInstance(await _skillCategoryService.CreateSkillCategoryAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSkillCategory(SkillCategoryUpdateDto updateDto)
        {
            return ActionResultInstance(await _skillCategoryService.UpdateSkillCategoryAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSkillCategory(string id)
        {
            return ActionResultInstance(await _skillCategoryService.RemoveAsync(id));
        }
    }
}
