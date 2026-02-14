using HotelManagement.WebApp.Client.Models.RoleModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace HotelManagement.WebApp.Client.IServices
{
    public interface IRoleWebAppService
    {
        [Get("/Role/GetRoles")]
        Task<ApiResponse<List<GetRoleWebAppModel>>> GetRoles();

        [Put("/Role/UpdateRole")]
        Task<ApiResponse<Boolean>> UpdateRole(UpdateRoleWebAppModel updateRoleWebAppModel);
    }
}
