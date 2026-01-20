using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.SQL.DBContext;

public partial class tblRole
{
    public int RoleID { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsRoleActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<tblUser> tblUsers { get; set; } = new List<tblUser>();
}
