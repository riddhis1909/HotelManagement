using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using HotelManagement.Services.IService;
using HotelManagement.WebApi.Models.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebApp.Controllers
{
    [Route("api/[controller]")]
    [TranslateResultToActionResult]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("GetUserDetails")]
        public async Task<Result<List<GetUserModel>>> GetUserDetails()
        {
            try
            {
                _logger.LogInformation("Controller : GetUserDetails method started");

                var result = await _userService.GetUserDetailsService();

                _logger.LogInformation("Controller : GetUserDetails method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : GetUserDetails method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpGet("GetUserDetailsByID")]
        public async Task<Result<GetUserModel>> GetUserDetailsByID(int userID)
        {
            try
            {
                _logger.LogInformation("Controller : GetUserDetails method started");

                var result = await _userService.GetUserDetailsByIDService(userID);

                _logger.LogInformation("Controller : GetUserDetails method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : GetUserDetails method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpPost("UserRegistration")]
        public async Task<Result> UserRegistration(UserRegistrationModel userRegistrationRequestModel)
        {
            try
            {
                _logger.LogInformation("Controller : UserRegistration method started");

                var result = await _userService.UserRegistrationService(userRegistrationRequestModel);

                _logger.LogInformation("Controller : UserRegistration method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : UserRegistration method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpPost("UserLogin")]
        public async Task<Result<int>> UserLogin(UserLoginModel userLoginRequestModel)
        {
            try
            {
                _logger.LogInformation("Controller : UserLogin method started");

                var result = await _userService.UserLoginService(userLoginRequestModel);

                _logger.LogInformation("Controller : UserLogin method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : UserLogin method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpGet("EmailVerification")]
        public async Task<Result> EmailVerification(string emailID)
        {
            try
            {
                _logger.LogInformation("Controller : EmailVerification method started");

                var result = await _userService.EmailVerificationService(emailID);

                _logger.LogInformation("Controller : EmailVerification method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : EmailVerification method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpPut("ChangePassword")]
        public async Task<Result> ChangePassword(string emailID, string password)
        {
            try
            {
                _logger.LogInformation("Controller : ChangePassword method started");

                var result = await _userService.ChangePasswordService(emailID, password);

                _logger.LogInformation("Controller : ChangePassword method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : ChangePassword method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }
    }
}
