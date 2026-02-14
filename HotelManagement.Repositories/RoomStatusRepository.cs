using Ardalis.Result;
using HotelManagement.DAL.SQL.DBContext;
using HotelManagement.Repositories.IRepository;
using HotelManagement.WebApi.Models.RoomStatusModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HotelManagement.Repositories
{
    public class RoomStatusRepository : IRoomStatusRepository
    {
        private readonly HotelManagementContext _dbContext;
        private readonly ILogger _logger;

        public RoomStatusRepository(HotelManagementContext dbContext, ILogger<RoomStatusRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result<List<AddEditRoomStatusModel>>> GetRoomStatuses()
        {
            try
            {
                _logger.LogInformation("Repository : GetRoomStatuses method initiated");

                var dbRoomStatusData = await _dbContext.tblRoomStatuses.ToListAsync();

                List<AddEditRoomStatusModel> roomStatusList = new List<AddEditRoomStatusModel>();

                if (dbRoomStatusData != null)
                {
                    foreach (var roomStatus in dbRoomStatusData)
                    {
                        AddEditRoomStatusModel addEditRoomStatusModel = new AddEditRoomStatusModel
                        {
                            RoomStatusID = roomStatus.RoomStatusID,
                            RoomStatusName = roomStatus.RoomStatusName,
                            RoomStatusIcon = roomStatus.RoomStatusIcon,
                            Description = roomStatus.Description,
                            IsActive = roomStatus.IsActive,
                            IsDeleted = roomStatus.IsDeleted
                        };
                        roomStatusList.Add(addEditRoomStatusModel);
                    }
                    _logger.LogInformation("Repository : GetRoomStatuses method completed");
                    return Result.Success(roomStatusList);
                }
                else
                {
                    _logger.LogInformation("Repository : No Room Status found");
                    return Result.NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository : GetRoomStatuses method encountered error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> AddRoomStatus(AddEditRoomStatusModel addEditRoomStatusRequestModel)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _logger.LogInformation("Repository : AddRoomStatus method initiated");

                    if (addEditRoomStatusRequestModel == null)
                    {
                        _logger.LogInformation("Repository : AddRoomStatus method found null request model");
                        return Result.NoContent();
                    }

                    tblRoomStatus dbRoomStatus = new tblRoomStatus();
                    dbRoomStatus.RoomStatusName = addEditRoomStatusRequestModel.RoomStatusName;
                    dbRoomStatus.RoomStatusIcon = addEditRoomStatusRequestModel.RoomStatusIcon;
                    dbRoomStatus.Description = addEditRoomStatusRequestModel.Description;
                    dbRoomStatus.IsActive = addEditRoomStatusRequestModel.IsActive;
                    dbRoomStatus.CreatedBy = 1;
                    dbRoomStatus.CreatedDate = DateTime.Now;

                    await _dbContext.tblRoomStatuses.AddAsync(dbRoomStatus);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation("Repository : AddRoomStatus method completed");
                    return Result.Success();
                }
                catch (DbException dbEx)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Repository : AddRoomStatus method encountered database error: {dbEx.Message}");
                    return Result.Error(dbEx.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Repository : AddRoomStatus method encountered error: {ex.Message}");
                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result> EditRoomStatus(AddEditRoomStatusModel addEditRoomStatusRequestModel)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _logger.LogInformation("Repository : EditRoomStatus method initiated");

                    if (addEditRoomStatusRequestModel == null)
                    {
                        _logger.LogInformation("Repository : EditRoomStatus method found null request model");
                        return Result.NoContent();
                    }

                    var dbRoomStatusData = await _dbContext.tblRoomStatuses.Where(item => item.RoomStatusID == addEditRoomStatusRequestModel.RoomStatusID).FirstOrDefaultAsync();

                    if (dbRoomStatusData != null)
                    {
                        dbRoomStatusData.RoomStatusName = addEditRoomStatusRequestModel.RoomStatusName;
                        dbRoomStatusData.RoomStatusIcon = addEditRoomStatusRequestModel.RoomStatusIcon;
                        dbRoomStatusData.Description = addEditRoomStatusRequestModel.Description;
                        dbRoomStatusData.IsActive = addEditRoomStatusRequestModel.IsActive;
                        dbRoomStatusData.UpdatedBy = 1;
                        dbRoomStatusData.UpdatedDate = DateTime.Now;

                        _dbContext.tblRoomStatuses.Update(dbRoomStatusData);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                        _logger.LogInformation("Repository : EditRoomStatus method completed");
                        return Result.Success();
                    }
                    else
                    {
                        _logger.LogInformation("Repository : No Room Status found with room status id {0}", addEditRoomStatusRequestModel.RoomStatusID);
                        return Result.NotFound();
                    }
                }
                catch (DbException dbEx)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Repository : EditRoomStatus method encountered database error: {dbEx.Message}");
                    return Result.Error(dbEx.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Repository : EditRoomStatus method encountered error: {ex.Message}");
                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result> DeleteRoomStatus(int roomStatusID)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _logger.LogInformation("Repository : DeleteRoomStatus method initiated");

                    if (roomStatusID <= 0)
                    {
                        _logger.LogInformation("Repository : No room status found with {0}", roomStatusID);
                        return Result.NotFound();
                    }

                    var dbRoomStatusData = await _dbContext.tblRoomStatuses.FindAsync(roomStatusID);

                    if (dbRoomStatusData != null)
                    {
                        dbRoomStatusData.IsDeleted = true;
                        dbRoomStatusData.IsActive = false;
                        dbRoomStatusData.DeletedBy = 1;
                        dbRoomStatusData.DeletedDate = DateTime.Now;

                        _dbContext.tblRoomStatuses.Update(dbRoomStatusData);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                        _logger.LogInformation("Repository : DeleteRoomStatus method completed");
                        return Result.Success();
                    }
                    else
                    {
                        _logger.LogInformation("Repository : No Room Status found with room status id {0}", roomStatusID);
                        return Result.NotFound();
                    }
                }
                catch (DbException dbEx)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Repository : DeleteRoomStatus method encountered database error: {dbEx.Message}");
                    return Result.Error(dbEx.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Repository : DeleteRoomStatus method encountered error: {ex.Message}");
                    return Result.Error(ex.Message);
                }
            }
        }
    }
}
