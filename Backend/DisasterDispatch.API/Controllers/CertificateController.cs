using DisasterDispatch.Core.Dtos.CertificateDtos;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : CustomBaseController
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCertificates()
        {
            return ActionResultInstance(await _certificateService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCertificatesWithUser()
        {
            return ActionResultInstance(await _certificateService.GetCertificatesWithUsersAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificateById(string id)
        {
            return ActionResultInstance(await _certificateService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCertificate(CertificateCreateDto createDto)
        {
            return ActionResultInstance(await _certificateService.AddCertificateAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCertificate(CertificateUpdateDto updateDto)
        {
            return ActionResultInstance(await _certificateService.UpdateCertificateAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCertificate(string id)
        {
            return ActionResultInstance(await _certificateService.RemoveAsync(id));
        }
    }
}
