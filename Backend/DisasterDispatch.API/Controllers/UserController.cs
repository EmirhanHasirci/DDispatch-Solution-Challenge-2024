using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ActionResultInstance(await _userService.GetUsers());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserSignUpDto signInDto)
        {
            return ActionResultInstance(await _userService.CreateUserAsync(signInDto));

        }
        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {            
            return ActionResultInstance(await _userService.GetUserByNameAsync(name));
        }
        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> GetUserByNameForEdit(string name)
        {
            return ActionResultInstance(await _userService.GetUserByNameForEditAsync(name));
        }
        [HttpGet("[action]/{tc}")]
        public async Task<IActionResult>GetUserByTc(string tc)
        {
            return ActionResultInstance(await _userService.GetUserByTcAsync(tc));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync(UserLoginDto userLoginDto)
        {
            return ActionResultInstance(await _userService.LoginAsycn(userLoginDto));
        }
        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> GetRolesByUser(string name)
        {
            return ActionResultInstance(await _userService.GetRolesByUsername(name));
        }
        [HttpPut]
        public async Task<IActionResult> Edit(AppUserEditDto editDto)
        {
            return ActionResultInstance(await _userService.EditUser(editDto));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Logout()
        {
            return ActionResultInstance(await _userService.Logout());
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeStatus(StatusChangeDto dto)
        {
            return ActionResultInstance(await _userService.ChangeStatus(dto));
        }
        [HttpGet("[action]/{city}")]
        public async Task<IActionResult>GetUsersByCity(string city)
        {
            return ActionResultInstance(await _userService.GetUsersByCity(city));
        }
    }
}
