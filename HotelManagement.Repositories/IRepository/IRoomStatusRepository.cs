using Ardalis.Result;
using HotelManagement.WebApi.Models.RoomStatusModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Repositories.IRepository
{
    public interface IRoomStatusRepository
    {
        Task<Result<List<AddEditRoomStatusModel>>> GetRoomStatuses();

        Task<Result> AddRoomStatus(AddEditRoomStatusModel addEditRoomStatusRequestModel);

        Task<Result> EditRoomStatus(AddEditRoomStatusModel addEditRoomStatusRequestModel);

        Task<Result> DeleteRoomStatus(int roomStatusID);
    }
}
