using Ardalis.Result;
using HotelManagement.WebApi.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<Result<List<GetUserModel>>> GetUserDetails();

        Task<Result<GetUserModel>> GetUserDetailsByID(int userID);

        Task<Result> UserRegistration(UserRegistrationModel userRegistrationRequestModel);

        Task<Result<int>> UserLogin(UserLoginModel userLoginRequestModel);

        Task<Result> EmailVerification(string emailID);

        Task<Result> ChangePassword(string emailID, string password);

    }
}
