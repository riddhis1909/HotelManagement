using HotelManagement.WebApp.Client.IServices;
using HotelManagement.WebApp.Client.Models.UserModels;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace HotelManagement.WebApp.Client.Pages.UserAccount
{
    public partial class ForgotPassword : ComponentBase
    {
        #region Inject Services

        [Inject] private IUserWebAppService _userWebAppService { get; set; }

        [Inject] private NavigationManager _navigationManager { get; set; }

        #endregion

        #region Parameters

        public string emailID { get; set; }
        public bool isBusy { get; set; } = false;
        public string EmailErrorMessage { get; set; } = string.Empty;
        #endregion

        #region On Render Method

        public async void OnVerifyEmailClick()
        {
            isBusy = true;
            await VerifyEmailApi();
            isBusy = false;
            StateHasChanged();
        }

        public async void OnEmailChange()
        {
            EmailErrorMessage = string.Empty;
            StateHasChanged();
        }
        #endregion

        #region API Service Call

        private async Task VerifyEmailApi()
        {
            var serviceResponse = await _userWebAppService.EmailVerification(emailID);
            if (serviceResponse.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo($"/ResetPassword/{emailID}");
            }
            else
            {
                if (serviceResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    EmailErrorMessage = "This email id does not exist.";
                }
            }
        }

        #endregion
    }
}
