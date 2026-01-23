using HotelManagement.WebApp.Client.IServices;
using HotelManagement.WebApp.Client.Models.UserModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace HotelManagement.WebApp.Client.Pages.UserAccount
{
    public partial class UserSignUp : ComponentBase
    {
        #region Inject Services

        [Inject] private IUserWebAppService _userWebAppService { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }

        #endregion


        #region Parameters
        public bool isBusy { get; set; } = false;
        public string duplicateEmailError { get; set; } = string.Empty;
        public UserRegistrationWebAppModel userRegistrationWebAppModel { get; set; } = new();

        #endregion


        #region On Render Method

        public async void OnSignUpClick()
        {
            isBusy = true;
            await UserSignUpApi();
            isBusy = false;
            StateHasChanged();
        }

        public async void OnEmailChange()
        {
            duplicateEmailError = string.Empty;
            StateHasChanged();
        }

        #endregion


        #region API Service Call

        private async Task UserSignUpApi()
        {
            var serviceResponse = await _userWebAppService.UserRegistration(userRegistrationWebAppModel);
            if (serviceResponse.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/");
            }
            else
            {
                if (serviceResponse.StatusCode == HttpStatusCode.Conflict)
                {
                    duplicateEmailError = "This email id is already registered.";
                }
            }
        }

        #endregion
    }
}
