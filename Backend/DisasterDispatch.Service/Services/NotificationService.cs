using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.NotificationDtos;
using DisasterDispatch.Core.Dtos.PhoneNumberDtos;
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
    internal class NotificationService : GenericService<Notification, NotificationDto>, INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationService(IUnitOfWork unitOfWork, IGenericRepository<Notification> genericRepository, INotificationRepository notificationRepository) : base(unitOfWork, genericRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<CustomResponse<NotificationDto>> AddNotification(NotificationCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<Notification>(dto);
            await _notificationRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<NotificationDto>(mappedDtoToEntity);
            return CustomResponse<NotificationDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<NotificationDto>>> GetNotifications()
        {
            return CustomResponse<List<NotificationDto>>.Success(ObjectMapper.Mapper.Map<List<NotificationDto>>( _notificationRepository.GetAll()), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<NotificationDto>> UpdateAsync(NotificationUpdateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<Notification>(dto);
             _notificationRepository.Update(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<NotificationDto>(mappedDtoToEntity);
            return CustomResponse<NotificationDto>.Success(responseDto, StatusCodes.Status201Created);
        }
    }
}
