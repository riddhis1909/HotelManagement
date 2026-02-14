using Ardalis.Result;
using HotelManagement.WebApi.Models.RoleModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Repositories.IRepository
{
    public interface IRoleRepository
    {
        Task<Result<List<GetRoleModel>>> GetRoles();

        Task<Result> UpdateRole(UpdateRoleModel updateRoleRequestModel);
    }
}
