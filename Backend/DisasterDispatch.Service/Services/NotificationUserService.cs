using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Dtos.NotificationDtos;
using DisasterDispatch.Core.Dtos.NotificationUserDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Core.UnitOfWork;
using DisasterDispatch.Repository.Repositories;
using DisasterDispatch.Service.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Services
{
    public class NotificationUserService : GenericService<NotificationUser, NotificationUserDto>, INotificationUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationUserRepository _notificationUserRepository;
        public NotificationUserService(IUnitOfWork unitOfWork, IGenericRepository<NotificationUser> genericRepository, INotificationUserRepository notificationUserRepository, UserManager<AppUser> userManager) : base(unitOfWork, genericRepository)
        {
            _notificationUserRepository = notificationUserRepository;
            _userManager = userManager;
        }

        public async Task<CustomResponse<NotificationUserDto>> AddNotificationUser(NotificationUserCreateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<NotificationUser>(dto);
            await _notificationUserRepository.AddAsync(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<NotificationUserDto>(mappedDtoToEntity);
            return CustomResponse<NotificationUserDto>.Success(responseDto, StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<NotificationUserDto>>> GetNotificationsByUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var notificationsByUser = _notificationUserRepository.Where(x => x.Id == Guid.Parse(user.Id)).ToList();
            var responseDto=ObjectMapper.Mapper.Map<List<NotificationUserDto>>(notificationsByUser);
            return CustomResponse<List<NotificationUserDto>>.Success(responseDto, StatusCodes.Status200OK);
        }

        public Task<CustomResponse<List<NotificationUserDto>>> GetNotificationUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponse<NotificationUserDto>> UpdateAsync(NotificationUserUpdateDto dto)
        {
            var mappedDtoToEntity = ObjectMapper.Mapper.Map<NotificationUser>(dto);
            _notificationUserRepository.Update(mappedDtoToEntity);
            await _unitOfWork.CommitAsync();
            var responseDto = ObjectMapper.Mapper.Map<NotificationUserDto>(mappedDtoToEntity);
            return CustomResponse<NotificationUserDto>.Success(responseDto, StatusCodes.Status201Created);
        }
    }
}
