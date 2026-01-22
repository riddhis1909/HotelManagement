using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.WebApi.Models.UserModels
{
    public class UserLoginModel
    {
        public string EmailID { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
