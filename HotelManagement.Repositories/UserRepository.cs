using Ardalis.Result;
using HotelManagement.DAL.SQL.DBContext;
using HotelManagement.Repositories.IRepository;
using HotelManagement.WebApi.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelManagementContext _dbContext;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public UserRepository(HotelManagementContext dbContext, ILogger<UserRepository> logger, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<Result<List<GetUserModel>>> GetUserDetails()
        {
            try
            {
                _logger.LogInformation("Repository : GetUserDetails method initiated");
                var userData = await _dbContext.tblUsers
                    .Include(r => r.Role)
                    .ToListAsync();
                if (userData != null)
                {
                    List<GetUserModel> userList = new List<GetUserModel>();

                    foreach (var user in userData)
                    {
                        GetUserModel getUser = new GetUserModel();

                        getUser.UserID = user.UserID;
                        getUser.RoleName = user.Role.RoleName;
                        getUser.FirstName = user.FirstName;
                        getUser.LastName = user.LastName;
                        getUser.EmailID = user.EmailID;
                        getUser.MobileNumber = user.MobileNumber;
                        getUser.Address = user.Address;
                        getUser.City = user.City;
                        getUser.ZipCode = user.ZipCode;
                        getUser.StateID = user.StateID;
                        getUser.IsProfileActive = user.IsProfileActive;
                        getUser.LastLoginDate = user.LastLoginDate;

                        userList.Add(getUser);
                    }
                    _logger.LogInformation("Repository : GetUserDetails method completed");
                    return Result.Success(userList);
                }
                else
                {
                    _logger.LogInformation("Repository : No user found");
                    return Result.NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository : GetUserDetails method encountered error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result<GetUserModel>> GetUserDetailsByID(int userID)
        {
            try
            {
                _logger.LogInformation("Repository : GetUserDetailsByID method initiated");

                if (userID <= 0)
                {
                    _logger.LogInformation("Repository : GetUserDetailsByID method found with invalid user id {0}", userID);
                    return Result.NoContent();
                }

                var userData = await _dbContext.tblUsers
                    .Include(r => r.Role)
                    .Where(item => item.UserID == userID)
                    .FirstOrDefaultAsync();

                if (userData != null)
                {
                    GetUserModel getUserModel = new GetUserModel();
                    getUserModel.UserID = userData.UserID;
                    getUserModel.RoleName = userData.Role.RoleName;
                    getUserModel.FirstName = userData.FirstName;
                    getUserModel.LastName = userData.LastName;
                    getUserModel.EmailID = userData.EmailID;
                    getUserModel.MobileNumber = userData.MobileNumber;
                    getUserModel.Address = userData.Address;
                    getUserModel.City = userData.City;
                    getUserModel.ZipCode = userData.ZipCode;
                    getUserModel.StateID = userData.StateID;
                    getUserModel.IsProfileActive = userData.IsProfileActive;
                    getUserModel.LastLoginDate = userData.LastLoginDate;

                    _logger.LogInformation("Repository : GetUserDetailsByID method completed");
                    return Result.Success(getUserModel);
                }
                else
                {
                    _logger.LogInformation("Repository : No user found with user id {0}", userID);
                    return Result.NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository : GetUserDetailsByID method encountered error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> UserRegistration(UserRegistrationModel userRegistrationRequestModel)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _logger.LogInformation("Repository : UserRegistration method initiated");

                    if (userRegistrationRequestModel == null)
                    {
                        _logger.LogInformation("Repository : UserRegistration method found null request model");
                        return Result.NoContent();
                    }

                    var emailVerification = await _dbContext.tblUsers.Where(item => item.EmailID == userRegistrationRequestModel.EmailID).FirstOrDefaultAsync();
                    if (emailVerification != null)
                    {
                        _logger.LogInformation("Repository : UserRegistration method found existing email id {0}", userRegistrationRequestModel.EmailID);
                        return Result.Conflict("Email ID already exists");
                    }

                    tblUser dbUser = new tblUser();
                    dbUser.RoleID = 2;
                    dbUser.FirstName = userRegistrationRequestModel.FirstName;
                    dbUser.LastName = userRegistrationRequestModel.LastName;
                    dbUser.EmailID = userRegistrationRequestModel.EmailID;
                    dbUser.MobileNumber = userRegistrationRequestModel.MobileNumber;
                    dbUser.Address = userRegistrationRequestModel.Address;
                    dbUser.City = userRegistrationRequestModel.City;
                    dbUser.ZipCode = userRegistrationRequestModel.ZipCode;
                    dbUser.StateID = userRegistrationRequestModel.StateID;
                    dbUser.Password = userRegistrationRequestModel.Password;
                    dbUser.IsProfileActive = true;
                    dbUser.CreatedBy = 1;
                    dbUser.CreatedDate = DateTime.Now;
                    _dbContext.tblUsers.Add(dbUser);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation("Repository : UserRegistration method completed");
                    return Result.Success();
                }
                catch (DbException dbEx)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Repository : UserRegistration method encountered database error: {dbEx.Message}");
                    return Result.Error(dbEx.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Repository : UserRegistration method encountered error: {ex.Message}");
                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result<string>> UserLogin(UserLoginModel userLoginRequestModel)
        {
            try
            {
                _logger.LogInformation("Repository : UserLogin method initiated");

                if (userLoginRequestModel == null)
                {
                    _logger.LogInformation("Repository : UserLogin method found null request model");
                    return Result.NoContent();
                }

                var userData = await _dbContext.tblUsers.Where(item => item.EmailID == userLoginRequestModel.EmailID).FirstOrDefaultAsync();
                if (userData != null)
                {
                    if (userData.Password == userLoginRequestModel.Password)
                    {
                        var claim = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, userData.UserID.ToString()),
                            new Claim(ClaimTypes.Email, userData.EmailID),
                            new Claim(ClaimTypes.Role, userData.RoleID.ToString())
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            issuer: _configuration["Jwt:Issuer"],
                            audience: _configuration["Jwt:Audience"],
                            expires: DateTime.UtcNow.AddMinutes(120),
                            claims: claim,
                            signingCredentials: credential
                        );
                        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                        _logger.LogInformation("Repository : UserLogin method completed");
                        return Result.Success(jwt);
                    }
                    else
                    {
                        _logger.LogInformation("Repository : User password is incorrect");
                        return Result.Invalid();
                    }
                }
                else
                {
                    _logger.LogInformation("Repository : User not found with email id {0}", userLoginRequestModel.EmailID);
                    return Result.NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository : UserLogin method encountered error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> EmailVerification(string emailID)
        {
            try
            {
                _logger.LogInformation("Repository : EmailVerification method initiated");

                if (emailID.IsNullOrEmpty())
                {
                    _logger.LogInformation("Repository : EmailVerification method executed with no email");
                    return Result.NoContent();
                }
                var userEmail = await _dbContext.tblUsers.Where(item => item.EmailID == emailID).FirstOrDefaultAsync();
                if (userEmail != null)
                {
                    _logger.LogInformation("Repository : EmailVerification method completed");
                    return Result.Success();
                }
                else
                {
                    _logger.LogInformation("Repository : No user found with email id {0}", emailID);
                    return Result.NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository : EmailVerification method encountered error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> ChangePassword(string emailID, string password)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _logger.LogInformation("Repository : ChangePassword method initiated");

                    if (emailID.IsNullOrEmpty())
                    {
                        _logger.LogInformation("Repository : ChangePassword method executed with no email");
                        return Result.NoContent();
                    }

                    var dbUserData = await _dbContext.tblUsers.Where(item => item.EmailID == emailID).FirstOrDefaultAsync();
                    if (dbUserData != null)
                    {
                        dbUserData.Password = password;
                        dbUserData.UpdatedBy = dbUserData.UserID;
                        dbUserData.UpdatedDate = DateTime.Now;

                        _dbContext.tblUsers.Update(dbUserData);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                        _logger.LogInformation("Repository : ChangePassword method completed");
                        return Result.Success();
                    }
                    else
                    {
                        _logger.LogInformation("Repository : No user found with email id {0}", emailID);
                        return Result.NotFound();
                    }
                }
                catch (DbException dbEx)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Repository : ChangePassword method encountered database error: {dbEx.Message}");
                    return Result.Error(dbEx.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Repository : ChangePassword method encountered error: {ex.Message}");
                    return Result.Error(ex.Message);
                }
            }
        }
    }
}
