using DisasterDispatch.Core.Dtos;
using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using DisasterDispatch.Core.Dtos.AppRoleDtos;
using Microsoft.Extensions.FileProviders;
using System.Web.Providers.Entities;

namespace DisasterDispatch.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IFileProvider _fileProvider;


        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IFileProvider fileProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _fileProvider = fileProvider;
        }

        public async Task<CustomResponse<AppUserDto>> ChangeStatus(StatusChangeDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.userid);
            if (user != null)
            {
                user.CurrentStatus = dto.value;
                await _userManager.UpdateAsync(user);
                var dtoResult = ObjectMapper.Mapper.Map<AppUserDto>(user);
                return CustomResponse<AppUserDto>.Success(dtoResult, StatusCodes.Status200OK);
            }
            return CustomResponse<AppUserDto>.Fail("User cannot be found", StatusCodes.Status200OK);

        }

        public async Task<CustomResponse<AppUserDto>> CreateUserAsync(UserSignUpDto signInDto)
        {
            var user = new AppUser
            {
                Email = signInDto.Email,
                UserName = signInDto.UserName,
                Tc = signInDto.Tc,
                Name = signInDto.Name,
                Surname = signInDto.Surname,
                CurrentStatus = "0"
            };
            var result = await _userManager.CreateAsync(user, signInDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return CustomResponse<AppUserDto>.Fail(errors, StatusCodes.Status400BadRequest);
            }
            var userr = await _userManager.FindByNameAsync(user.UserName);
            await _userManager.AddToRoleAsync(userr, "User");
            return CustomResponse<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<AppUserEditDto>> EditUser(AppUserEditDto p)
        {
            var currentUser = await _userManager.FindByNameAsync(p.UserName);
            currentUser.Name = p.Name;
            currentUser.Surname = p.Surname;
            currentUser.UserName = p.UserName;
            currentUser.BirthDate = p.BirthDate;
            currentUser.City = p.City;
            currentUser.Gender = p.Gender;
            if (p.Picture != null)
            {
                currentUser.Picture = p.Picture;
            }
            var result = await _userManager.UpdateAsync(currentUser);
            if (!result.Succeeded)
            {
                List<string> Errors = new();
                foreach (var item in result.Errors)
                {
                    Errors.Add(item.Description);
                }
                return CustomResponse<AppUserEditDto>.Fail(Errors, StatusCodes.Status400BadRequest);

            }
            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(currentUser, true);
            var userEdit = new AppUserEditDto()
            {
                Email = currentUser.Email,
                UserName = currentUser.UserName,
                BirthDate = currentUser.BirthDate,
                City = currentUser.City,
                Gender = currentUser.Gender
            };
            return CustomResponse<AppUserEditDto>.Success(userEdit, StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<List<string>>> GetRolesByUsername(string username)
        {
            var userResponse = await GetUserByNameAsync(username);
            var user = ObjectMapper.Mapper.Map<AppUser>(userResponse.Data);
            if (user is not null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles is not null)
                {
                    return CustomResponse<List<string>>.Success(userRoles.ToList(), StatusCodes.Status201Created);
                }
                return CustomResponse<List<string>>.Fail("User Roles is empty", StatusCodes.Status404NotFound);
            }
            else
            {

                return CustomResponse<List<string>>.Fail("User cannot be found", StatusCodes.Status404NotFound);
            }
        }

        public async Task<CustomResponse<AppUserDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is null)
            {
                return CustomResponse<AppUserDto>.Fail("Wrong password or username", 404);
            }
            return CustomResponse<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
        }

        public async Task<CustomResponse<AppUserEditDto>> GetUserByNameForEditAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is null)
            {
                return CustomResponse<AppUserEditDto>.Fail("Wrong password or username", 404);
            }
            return CustomResponse<AppUserEditDto>.Success(ObjectMapper.Mapper.Map<AppUserEditDto>(user), 200);
        }

        public async Task<CustomResponse<AppUserDto>> GetUserByTcAsync(string tc)
        {
            var user = await _userManager.Users.Where(x => x.Tc == tc).FirstOrDefaultAsync();
            if (user is null)
            {
                return CustomResponse<AppUserDto>.Fail("Wrong password or TC", 404);

            }
            return CustomResponse<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
        }

        public async Task<CustomResponse<List<AppUserDto>>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return CustomResponse<List<AppUserDto>>.Success(ObjectMapper.Mapper.Map<List<AppUserDto>>(users),200);
        }

        public async Task<CustomResponse<List<AppUserDto>>> GetUsersByCity(string city)
        {
            if (city is not null)
            {
                var usersByCity = await _userManager.Users.Where(x => x.City == city && x.CurrentStatus == "1").ToListAsync();
                var entityToDtoByCity = ObjectMapper.Mapper.Map<List<AppUserDto>>(usersByCity);
                return CustomResponse<List<AppUserDto>>.Success(entityToDtoByCity, StatusCodes.Status200OK);
            }
            var users = _userManager.Users.Where(x => x.CurrentStatus == "1").ToListAsync();
            var entityToDto = ObjectMapper.Mapper.Map<List<AppUserDto>>(users);
            return CustomResponse<List<AppUserDto>>.Success(entityToDto, StatusCodes.Status400BadRequest);

        }

        public async Task<CustomResponse<AppUserDto>> LoginAsycn(UserLoginDto userLoginDto)
        {
            var userResponse = await GetUserByTcAsync(userLoginDto.Tc);
            if (userResponse.Data is not null)
            {

                var userMail = userResponse.Data.Email;
                AppUser user = await _userManager.FindByEmailAsync(userMail);
                if (user is not null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, true, true);
                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        return CustomResponse<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
                    }
                }
            }
            return CustomResponse<AppUserDto>.Fail("Wrong Tc or Password", 403);

        }

        public async Task<CustomResponse<NoContentDto>> Logout()
        {
            await _signInManager.SignOutAsync();
            return CustomResponse<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
