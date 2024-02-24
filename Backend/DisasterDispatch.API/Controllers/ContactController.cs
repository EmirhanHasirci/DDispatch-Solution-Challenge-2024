using DisasterDispatch.Core.Dtos.ContactDtos;
using DisasterDispatch.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : CustomBaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateContact(ContactDto createDto)
        {
            return ActionResultInstance(await _contactService.AddAsync(createDto));
        }
    }
}
