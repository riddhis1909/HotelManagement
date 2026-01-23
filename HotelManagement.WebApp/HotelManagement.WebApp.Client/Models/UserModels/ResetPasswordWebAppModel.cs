using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.WebApp.Client.Models.UserModels
{
    public class ResetPasswordWebAppModel
    {
        [Required]
        public string NewPassword { get; set; }
        
        [Required]
        [Compare("NewPassword", ErrorMessage = "Password does not match.")]
        public string ConfirmPassword { get; set; }
    }
}