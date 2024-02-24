using DisasterDispatch.Core.Dtos.AppRoleDtos;
using DisasterDispatch.Core.Dtos.AppUserDtos;
using DisasterDispatch.Core.Dtos.BaseDtos;
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DisasterDispatch.Service.Services
{
    public class RoleService:IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<CustomResponse<AppRoleDto>> AddRoleAsync(AppRoleCreateDto roleDto)
        {
            var role = ObjectMapper.Mapper.Map<AppRole>(roleDto);
           var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return CustomResponse<AppRoleDto>.Fail(errors, StatusCodes.Status400BadRequest);
            }
            return CustomResponse<AppRoleDto>.Success(ObjectMapper.Mapper.Map<AppRoleDto>(role), StatusCodes.Status200OK);

        }

        public async Task<CustomResponse<AppRoleDto>> GetRoleAsync(string roleId)
        {
            var role = await _roleManager.Roles.Where(X => X.Id == roleId).FirstOrDefaultAsync();
            if (role is null)
            {
                return CustomResponse<AppRoleDto>.Fail("Role cannot be found", StatusCodes.Status400BadRequest);
            }
            return CustomResponse<AppRoleDto>.Success(ObjectMapper.Mapper.Map<AppRoleDto>(role), StatusCodes.Status200OK);

        }
    }
}
