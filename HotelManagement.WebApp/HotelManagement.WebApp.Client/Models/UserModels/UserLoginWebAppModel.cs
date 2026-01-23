using System.ComponentModel.DataAnnotations;

namespace HotelManagement.WebApp.Client.Models.UserModels
{
    public class UserLoginWebAppModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;
    }
}
