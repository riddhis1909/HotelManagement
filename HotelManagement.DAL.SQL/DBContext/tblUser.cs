using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.SQL.DBContext;

public partial class tblUser
{
    public int UserID { get; set; }

    public int RoleID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailID { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public int? StateID { get; set; }

    public string? Password { get; set; }

    public bool IsProfileActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public virtual tblRole Role { get; set; } = null!;
}
