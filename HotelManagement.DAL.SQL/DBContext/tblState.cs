using System;
using System.Collections.Generic;

namespace HotelManagement.DAL.SQL.DBContext;

public partial class tblState
{
    public int StateID { get; set; }

    public int CountryID { get; set; }

    public string StateName { get; set; } = null!;

    public bool IsStateActive { get; set; }

    public bool IsStateDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual tblCountry Country { get; set; } = null!;
}
