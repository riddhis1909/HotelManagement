using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.WebApi.Models.RoomStatusModel
{
    public class AddEditRoomStatusModel
    {
        public int RoomStatusID { get; set; }
        public string RoomStatusName { get; set; } = null!;
        public string? RoomStatusIcon { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
