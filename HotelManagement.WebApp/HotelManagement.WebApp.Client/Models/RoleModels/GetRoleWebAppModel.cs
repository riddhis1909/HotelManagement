namespace HotelManagement.WebApp.Client.Models.RoleModels
{
    public class GetRoleWebAppModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsRoleActive { get; set; }
    }
}
