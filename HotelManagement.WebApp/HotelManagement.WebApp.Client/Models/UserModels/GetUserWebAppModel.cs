namespace HotelManagement.WebApp.Client.Models.UserModels
{
    public class GetUserWebAppModel
    {
        public int UserID { get; set; }

        public string RoleName { get; set; }

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

        public DateTime? LastLoginDate { get; set; }

    }
}
