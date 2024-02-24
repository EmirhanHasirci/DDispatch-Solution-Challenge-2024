using AutoMapper;
using DisasterDispatch.Core.Dtos.CertificateDtos;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class CertificateMapper:Profile
    {
        public CertificateMapper()
        {
            CreateMap<Certificate, CertificateDto>().ReverseMap();
            CreateMap<Certificate, CertificateCreateDto>().ReverseMap();
            CreateMap<Certificate, CertificateUpdateDto>().ReverseMap();
            CreateMap<Certificate, CertificateWithUsersDto>().ReverseMap();
        }
    }
}
