using HotelManagement.WebApp.Client.IServices;
using HotelManagement.WebApp.Client.Models.UserModels;
using Microsoft.AspNetCore.Components;

namespace HotelManagement.WebApp.Client.Pages.UserAccount
{
    public partial class UserLogin : ComponentBase
    {
        #region Inject Services

        [Inject] private IUserWebAppService _userWebAppService { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }

        #endregion

        #region Parameters

        public bool isBusy { get; set; } = false;
        public UserLoginWebAppModel userLoginWebAppModel { get; set; } = new();

        #endregion

        #region On Render Method

        public async void OnLoginClick()
        {
            isBusy = true;
            await UserLoginApi();
            isBusy = false;
            StateHasChanged();
        }

        #endregion

        #region API Service Call

        private async Task UserLoginApi()
        {
            var serviceResponse = await _userWebAppService.UserLogin(userLoginWebAppModel);
            if (serviceResponse.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/Home");
            }
            else
            {

            }
        }

        #endregion
    }
}
