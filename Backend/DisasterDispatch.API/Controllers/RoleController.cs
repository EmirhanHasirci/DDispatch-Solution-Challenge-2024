using DisasterDispatch.Core.Dtos.AppRoleDtos;
using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : CustomBaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(AppRoleCreateDto CreateDto)
        {
            return ActionResultInstance(await _roleService.AddRoleAsync(CreateDto));

        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            return ActionResultInstance(await _roleService.GetRoleAsync(id));
        }
    }
}
