using DisasterDispatch.Core.Dtos.AddressDtos;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : CustomBaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            return ActionResultInstance(await _addressService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAddressesWithUser()
        {
            return ActionResultInstance(await _addressService.GetAddresssWithUsersAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(string id)
        {
            return ActionResultInstance(await _addressService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(AddressCreateDto createDto)
        {
            return ActionResultInstance(await _addressService.AddAddressAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(AddressDto updateDto)
        {
            return ActionResultInstance(await _addressService.UpdateAddressAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAddress(string id)
        {
            return ActionResultInstance(await _addressService.RemoveAsync(id));
        }
        [HttpGet("[action]/{username}")]
        public async Task<IActionResult> GetAddressesByUsername(string username)
        {
            return ActionResultInstance(await _addressService.GetAddressesByUsername(username));
        }
    }
}
