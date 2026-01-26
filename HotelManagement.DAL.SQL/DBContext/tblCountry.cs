using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.SQL.DBContext;

public partial class tblCountry
{
    public int CountryID { get; set; }

    public string CountryName { get; set; } = null!;

    public string? ISO2 { get; set; }

    public string? ISO3 { get; set; }

    public string? PhoneCode { get; set; }

    public string? Capital { get; set; }

    public string? Currency { get; set; }

    public bool IsCountryActive { get; set; }

    public bool IsCountryDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<tblState> tblStates { get; set; } = new List<tblState>();
}
