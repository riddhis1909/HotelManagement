using Ardalis.Result;
using HotelManagement.DAL.SQL.DBContext;
using HotelManagement.Repositories.IRepository;
using HotelManagement.WebApi.Models.RoleModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HotelManagement.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HotelManagementContext _dbContext;
        private readonly ILogger _logger;

        public RoleRepository(HotelManagementContext dbContext, ILogger<RoleRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result<List<GetRoleModel>>> GetRoles()
        {
            try
            {
                _logger.LogInformation("Repository : GetRoles method initiated");

                var dbRoleData = await _dbContext.tblRoles.ToListAsync();

                if (dbRoleData != null)
                {
                    List<GetRoleModel> roleList = new List<GetRoleModel>();

                    foreach (var role in dbRoleData)
                    {
                        GetRoleModel roleModel = new GetRoleModel();
                        roleModel.RoleID = role.RoleID;
                        roleModel.RoleName = role.RoleName;
                        roleModel.Description = role.Description;
                        roleModel.IsRoleActive = role.IsRoleActive;

                        roleList.Add(roleModel);
                    }

                    _logger.LogInformation("Repository : GetRoles method completed");
                    return Result.Success(roleList);
                }
                else
                {
                    _logger.LogInformation("Repository : No role found");
                    return Result.NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository : GetRoles method encountered error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> UpdateRole(UpdateRoleModel updateRoleRequestModel)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _logger.LogInformation("Repository : UpdateRole method initiated");

                    if (updateRoleRequestModel == null)
                    {
                        _logger.LogInformation("Repository : UpdateRole method called with a null updateRoleRequestModel");
                        return Result.NoContent();
                    }
                    var dbRoleData = await _dbContext.tblRoles.Where(item => item.RoleID == updateRoleRequestModel.RoleID).FirstOrDefaultAsync();

                    if (dbRoleData != null)
                    {
                        dbRoleData.Description = updateRoleRequestModel.Description;
                        dbRoleData.IsRoleActive = updateRoleRequestModel.IsRoleActive;
                        dbRoleData.UpdatedBy = 1;
                        dbRoleData.UpdatedDate = DateTime.Now;

                        _dbContext.tblRoles.Update(dbRoleData);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                        _logger.LogInformation("Repository : UpdateRole method completed");
                        return Result.Success();
                    }
                    else
                    {
                        _logger.LogInformation("Repository : No role found");
                        return Result.NotFound();
                    }
                }
                catch (DbException dbEx)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Repository : UpdateRole method encountered error: {dbEx.Message}");
                    return Result.Error(dbEx.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Repository : UpdateRole method encountered error: {ex.Message}");
                    return Result.Error(ex.Message);
                }
            }
        }
    }
}

