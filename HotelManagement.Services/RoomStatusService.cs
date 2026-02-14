using Ardalis.Result;
using HotelManagement.DAL.SQL.DBContext;
using HotelManagement.Repositories;
using HotelManagement.Repositories.IRepository;
using HotelManagement.Services.IService;
using HotelManagement.WebApi.Models.RoomStatusModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Services
{
    public class RoomStatusService : IRoomStatusService
    {
        private readonly IRoomStatusRepository _roomStatusRepository;
        private readonly ILogger _logger;
        public RoomStatusService(IRoomStatusRepository roomStatusRepository, ILogger<RoomStatusService> logger)
        {
            _roomStatusRepository = roomStatusRepository;
            _logger = logger;
        }

        public async Task<Result<List<AddEditRoomStatusModel>>> GetRoomStatusesService()
        {
            try
            {
                _logger.LogInformation("Service : GetRoomStatusesService started");

                var serviceResponse = await _roomStatusRepository.GetRoomStatuses();

                _logger.LogInformation("Service : GetRoomStatusesService completed");
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : GetRoomStatusesService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> AddRoomStatusService(AddEditRoomStatusModel addEditRoomStatusRequestModel)
        {
            try
            {
                _logger.LogInformation("Service : AddRoomStatusService started");

                var serviceResponse = await _roomStatusRepository.AddRoomStatus(addEditRoomStatusRequestModel);

                _logger.LogInformation("Service : AddRoomStatusService completed");
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : AddRoomStatusService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> EditRoomStatusService(AddEditRoomStatusModel addEditRoomStatusRequestModel)
        {
            try
            {
                _logger.LogInformation("Service : EditRoomStatusService started");

                var serviceResponse = await _roomStatusRepository.EditRoomStatus(addEditRoomStatusRequestModel);

                _logger.LogInformation("Service : EditRoomStatusService completed");
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : EditRoomStatusService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> DeleteRoomStatusService(int roomStatusID)
        {
            try
            {
                _logger.LogInformation("Service : DeleteRoomStatusService started");

                var serviceResponse = await _roomStatusRepository.DeleteRoomStatus(roomStatusID);

                _logger.LogInformation("Service : DeleteRoomStatusService completed");
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : DeleteRoomStatusService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }
    }
}
