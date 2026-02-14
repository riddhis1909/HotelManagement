using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.WebApi.Models.RoleModel
{
    public class UpdateRoleModel
    {
        public int RoleID { get; set; }

        public string? Description { get; set; }

        public bool IsRoleActive { get; set; }

    }
}
