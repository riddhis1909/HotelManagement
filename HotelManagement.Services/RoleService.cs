using Ardalis.Result;
using HotelManagement.Repositories.IRepository;
using HotelManagement.Services.IService;
using HotelManagement.WebApi.Models.RoleModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger _logger;

        public RoleService(IRoleRepository roleRepository ,ILogger<RoleService> logger)
        {
            _roleRepository = roleRepository;
            _logger = logger;
        }
        
        public async Task<Result<List<GetRoleModel>>> GetRolesService()
        {
            try
            {
                _logger.LogInformation("Service : GetRolesService started");

                var serviceResponse = await _roleRepository.GetRoles();

                _logger.LogInformation("Service : GetRolesService completed");
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : GetRolesService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> UpdateRoleService(UpdateRoleModel updateRoleRequestModel)
        {
            try
            {
                _logger.LogInformation("Service : UpdateRoleService started");

                var serviceResponse = await _roleRepository.UpdateRole(updateRoleRequestModel);

                _logger.LogInformation("Service : UpdateRoleService completed");
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : UpdateRoleService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }
    }
}
