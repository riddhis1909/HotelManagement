using Ardalis.Result;
using HotelManagement.WebApi.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Services.IService
{
    public interface IUserService
    {
        Task<Result<List<GetUserModel>>> GetUserDetailsService();

        Task<Result<GetUserModel>> GetUserDetailsByIDService(int userID);

        Task<Result> UserRegistrationService(UserRegistrationModel userRegistrationRequestModel);

        Task<Result<int>> UserLoginService(UserLoginModel userLoginRequestModel);

        Task<Result> EmailVerificationService(string emailID);

        Task<Result> ChangePasswordService(string emailID, string password);
    }
}
