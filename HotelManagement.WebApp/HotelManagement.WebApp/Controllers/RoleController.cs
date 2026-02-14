using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using HotelManagement.Services.IService;
using HotelManagement.WebApi.Models.RoleModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [TranslateResultToActionResult]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }
        
        [HttpGet("GetRoles")]
        public async Task<Result<List<GetRoleModel>>> GetRoles()
        {
            try
            {
                _logger.LogInformation("Controller : GetRoles method started");

                var result = await _roleService.GetRolesService();

                _logger.LogInformation("Controller : GetRoles method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : GetRoles method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpPut("UpdateRole")]
        public async Task<Result> UpdateRole(UpdateRoleModel updateRoleRequestModel)
        {
            try
            {
                _logger.LogInformation("Controller : UpdateRole method started");

                var result = await _roleService.UpdateRoleService(updateRoleRequestModel);

                _logger.LogInformation("Controller : UpdateRole method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : UpdateRole method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }
    }
}
