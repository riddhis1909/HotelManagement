using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.SQL.DBContext;

public partial class tblRoomStatus
{
    public int RoomStatusID { get; set; }

    public string RoomStatusName { get; set; } = null!;

    public string? Description { get; set; }

    public string? RoomStatusIcon { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }
}
