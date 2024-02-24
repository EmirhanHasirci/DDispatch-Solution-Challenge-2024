using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.CertificateDtos;
using DisasterDispatch.Core.Dtos.CertificateDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Core.UnitOfWork;
using DisasterDispatch.Repository.Repositories;
using DisasterDispatch.Service.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Services
{
    public class CertificateService : GenericService<Certificate, CertificateDto>, ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        public CertificateService(IUnitOfWork unitOfWork, IGenericRepository<Certificate> genericRepository, ICertificateRepository certificateRepository) : base(unitOfWork, genericRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<CustomResponse<CertificateDto>> AddCertificateAsync(CertificateCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<Certificate>(dto);
            await _certificateRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<CertificateDto>(mappedDtoToEntity);
            return CustomResponse<CertificateDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<CertificateWithUsersDto>>> GetCertificatesWithUsersAsync()
        {
            return CustomResponse<List<CertificateWithUsersDto>>.Success(ObjectMapper.Mapper.Map<List<CertificateWithUsersDto>>(await _certificateRepository.GetCertificatesWithUserAsync()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NoContentDto>> UpdateCertificateAsync(CertificateUpdateDto updateDto)
        {
            var entity = ObjectMapper.Mapper.Map<Certificate>(updateDto);
            _certificateRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
