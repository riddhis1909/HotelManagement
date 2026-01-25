using Ardalis.Result;
using HotelManagement.Repositories.IRepository;
using HotelManagement.Services.IService;
using HotelManagement.WebApi.Models.UserModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Result<List<GetUserModel>>> GetUserDetailsService()
        {
            try
            {
                _logger.LogInformation("Service : GetUserDetailsService started");

                var result = await _userRepository.GetUserDetails();

                _logger.LogInformation("Service : GetUserDetailsService completed");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : GetUserDetailsService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result<GetUserModel>> GetUserDetailsByIDService(int userID)
        {
            try
            {
                _logger.LogInformation("Service : GetUserDetailsByIDService started");

                var result = await _userRepository.GetUserDetailsByID(userID);

                _logger.LogInformation("Service : GetUserDetailsByIDService completed");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : GetUserDetailsByIDService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> UserRegistrationService(UserRegistrationModel userRegistrationRequestModel)
        {
            try
            {
                _logger.LogInformation("Service : UserRegistrationService started");

                var result = await _userRepository.UserRegistration(userRegistrationRequestModel);

                _logger.LogInformation("Service : UserRegistrationService completed");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : UserRegistrationService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result<string>> UserLoginService(UserLoginModel userLoginRequestModel)
        {
            try
            {
                _logger.LogInformation("Service : UserLoginService started");

                var result = await _userRepository.UserLogin(userLoginRequestModel);

                _logger.LogInformation("Service : UserLoginService completed");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : UserLoginService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> EmailVerificationService(string emailID)
        {
            try
            {
                _logger.LogInformation("Service : EmailVerificationService started");

                var result = await _userRepository.EmailVerification(emailID);

                _logger.LogInformation("Service : EmailVerificationService completed");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : EmailVerificationService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> ChangePasswordService(string emailID, string password)
        {
            try
            {
                _logger.LogInformation("Service : ChangePasswordService started");

                var result = await _userRepository.ChangePassword(emailID, password);

                _logger.LogInformation("Service : ChangePasswordService completed");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : ChangePasswordService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }
    }
}
