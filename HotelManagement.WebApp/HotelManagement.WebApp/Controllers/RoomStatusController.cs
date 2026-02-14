using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using HotelManagement.Services;
using HotelManagement.Services.IService;
using HotelManagement.WebApi.Models.RoomStatusModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [TranslateResultToActionResult]
    [ApiController]
    public class RoomStatusController : ControllerBase
    {
        private readonly IRoomStatusService _roomStatusService;
        private readonly ILogger _logger;

        public RoomStatusController(IRoomStatusService roomStatusService, ILogger<RoomStatusController> logger)
        {
            _roomStatusService = roomStatusService;
            _logger = logger;
        }

        [HttpGet("GetRoomStatuses")]
        public async Task<Result<List<AddEditRoomStatusModel>>> GetRoomStatuses()
        {
            try
            {
                _logger.LogInformation("Controller : GetRoomStatuses method started");

                var result = await _roomStatusService.GetRoomStatusesService();

                _logger.LogInformation("Controller : GetRoomStatuses method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : GetRoomStatuses method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpPost("AddRoomStatus")]
        public async Task<Result> AddRoomStatus(AddEditRoomStatusModel addEditRoomStatusRequestModel)
        {
            try
            {
                _logger.LogInformation("Controller : AddRoomStatus method started");

                var result = await _roomStatusService.AddRoomStatusService(addEditRoomStatusRequestModel);

                _logger.LogInformation("Controller : AddRoomStatus method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : AddRoomStatus method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpPut("EditRoomStatus")]
        public async Task<Result> EditRoomStatus(AddEditRoomStatusModel addEditRoomStatusRequestModel)
        {
            try
            {
                _logger.LogInformation("Controller : EditRoomStatus method started");

                var result = await _roomStatusService.EditRoomStatusService(addEditRoomStatusRequestModel);

                _logger.LogInformation("Controller : EditRoomStatus method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : EditRoomStatus method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpPut("DeleteRoomStatus")]
        public async Task<Result> DeleteRoomStatus(int roomStatusID)
        {
            try
            {
                _logger.LogInformation("Controller : DeleteRoomStatus method started");

                var result = await _roomStatusService.DeleteRoomStatusService(roomStatusID);

                _logger.LogInformation("Controller : DeleteRoomStatus method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : DeleteRoomStatus method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }
    }
}
