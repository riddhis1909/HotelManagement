using HotelManagement.WebApp.Client.Models.UserModels;
using Refit;

namespace HotelManagement.WebApp.Client.IServices
{
    public interface IUserWebAppService
    {
        [Get("/User/GetUserDetails")]
        Task<ApiResponse<List<GetUserWebAppModel>>> GetUserDetails();

        [Get("/User/GetUserDetailsByID")]
        Task<ApiResponse<GetUserWebAppModel>> GetUserDetailsByID(int userID);

        [Post("/User/UserRegistration")]
        Task<ApiResponse<Boolean>> UserRegistration(UserRegistrationWebAppModel userRegistrationWebAppModel);

        [Post("/User/UserLogin")]
        Task<ApiResponse<string>> UserLogin(UserLoginWebAppModel userLoginWebAppModel);

        [Get("/User/EmailVerification")]
        Task<ApiResponse<Boolean>> EmailVerification(string emailID);

        [Put("/User/ChangePassword")]
        Task<ApiResponse<Boolean>> ChangePassword(string emailID, string password);

    }
}
