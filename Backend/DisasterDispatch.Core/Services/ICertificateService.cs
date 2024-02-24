using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.CertificateDtos;
using DisasterDispatch.Core.Dtos.CertificateDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Services
{
    public interface ICertificateService:IGenericService<Certificate,CertificateDto>
    {
        Task<CustomResponse<List<CertificateWithUsersDto>>> GetCertificatesWithUsersAsync();
        Task<CustomResponse<NoContentDto>> UpdateCertificateAsync(CertificateUpdateDto updateDto);
        Task<CustomResponse<CertificateDto>> AddCertificateAsync(CertificateCreateDto dto);
    }
}
