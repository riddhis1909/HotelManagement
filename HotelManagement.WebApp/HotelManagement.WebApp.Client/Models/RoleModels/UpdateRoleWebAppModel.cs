namespace HotelManagement.WebApp.Client.Models.RoleModels
{
    public class UpdateRoleWebAppModel
    {
        public int RoleID { get; set; }

        public string? Description { get; set; }

        public bool IsRoleActive { get; set; }
    }
}
