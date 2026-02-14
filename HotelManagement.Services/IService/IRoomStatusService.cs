using Ardalis.Result;
using HotelManagement.WebApi.Models.RoomStatusModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Services.IService
{
    public interface IRoomStatusService
    {
        Task<Result<List<AddEditRoomStatusModel>>> GetRoomStatusesService();

        Task<Result> AddRoomStatusService(AddEditRoomStatusModel addEditRoomStatusRequestModel);

        Task<Result> EditRoomStatusService(AddEditRoomStatusModel addEditRoomStatusRequestModel);

        Task<Result> DeleteRoomStatusService(int roomStatusID);
    }
}
