using System.ComponentModel.DataAnnotations;

namespace HotelManagement.WebApp.Client.Models.UserModels
{
    public class UserRegistrationWebAppModel
    {
        public int RoleID { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; } = null!;

        [Required]
        public string MobileNumber { get; set; } = null!;

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? ZipCode { get; set; }

        public int? StateID { get; set; }

        [Required]
        public string? Password { get; set; }

    }
}
