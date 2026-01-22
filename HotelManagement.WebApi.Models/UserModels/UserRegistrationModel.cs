using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.WebApi.Models.UserModels
{
    public class UserRegistrationModel
    {
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

    }
}
