using Ardalis.Result;
using HotelManagement.WebApi.Models.RoleModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Services.IService
{
    public interface IRoleService
    {
        Task<Result<List<GetRoleModel>>> GetRolesService();

        Task<Result> UpdateRoleService(UpdateRoleModel updateRoleRequestModel);
    }
}
