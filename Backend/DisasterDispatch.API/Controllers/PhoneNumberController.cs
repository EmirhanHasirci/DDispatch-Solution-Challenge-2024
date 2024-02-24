using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
using DisasterDispatch.Core.Dtos.TitleDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : CustomBaseController
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumberController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneNumbers()
        {
            return ActionResultInstance(await _phoneNumberService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPhoneNumbersWithUsers()
        {
            return ActionResultInstance(await _phoneNumberService.GetPhoneNumbersWithUsersAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneNumberById(string id)
        {
            return ActionResultInstance(await _phoneNumberService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddPhoneNumber(PhoneNumberCreateDto createDto)
        {
            return ActionResultInstance(await _phoneNumberService.AddPhoneNumberAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePhoneNumber(PhoneNumberDto updateDto)
        {
            return ActionResultInstance(await _phoneNumberService.UpdateDto(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePhoneNumber(string id)
        {
            return ActionResultInstance(await _phoneNumberService.RemoveAsync(id));
        }
        [HttpGet("[action]/{username}")]
        public async Task<IActionResult> GetPhoneNumbersByUserName(string username)
        {
            return ActionResultInstance(await _phoneNumberService.GetPhoneNumbersByUser(username));
        }
    }
}
