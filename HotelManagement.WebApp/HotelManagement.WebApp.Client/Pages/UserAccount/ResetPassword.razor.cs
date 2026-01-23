using HotelManagement.WebApp.Client.IServices;
using HotelManagement.WebApp.Client.Models.UserModels;
using Microsoft.AspNetCore.Components;

namespace HotelManagement.WebApp.Client.Pages.UserAccount
{
    public partial class ResetPassword : ComponentBase
    {
        #region Inject Services
        [Inject] private IUserWebAppService _userWebAppService { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }

        #endregion

        #region Parameters

        public bool isBusy { get; set; } = false;
        [Parameter] public string emailID { get; set; }
        public ResetPasswordWebAppModel resetPasswordWebAppModel { get; set; } = new();

        #endregion

        #region On Render Method

        public async void OnLoginClick()
        {
            isBusy = true;
            await ChangePasswordApi();
            isBusy = false;
            StateHasChanged();
        }

        #endregion

        #region API Service Call

        private async Task ChangePasswordApi()
        {
            var serviceResponse = await _userWebAppService.ChangePassword(emailID, resetPasswordWebAppModel.NewPassword);
            if (serviceResponse.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/");
            }
            else
            {

            }
        }

        #endregion
    }
}
