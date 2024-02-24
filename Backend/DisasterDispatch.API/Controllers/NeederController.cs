using DisasterDispatch.Core.Dtos.ContactDtos;
using DisasterDispatch.Core.Dtos.NeederDtos;
using DisasterDispatch.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeederController : CustomBaseController
    {
        private readonly INeederService _neederService;
        public NeederController(INeederService neederService)
        {
            _neederService = neederService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNeeder(NeederDto createDto)
        {
            return ActionResultInstance(await _neederService.AddAsync(createDto));
        }

    }
}
