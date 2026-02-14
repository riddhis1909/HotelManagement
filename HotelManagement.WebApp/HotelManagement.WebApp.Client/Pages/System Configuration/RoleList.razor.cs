using HotelManagement.WebApp.Client.IServices;
using HotelManagement.WebApp.Client.Models.RoleModels;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace HotelManagement.WebApp.Client.Pages.System_Configuration
{
    public partial class RoleList : ComponentBase
    {
        #region Inject Services

        [Inject] private IRoleWebAppService _roleWebAppService { get; set; }

        #endregion

        #region Parameters

        public List<GetRoleWebAppModel> getRoleWebAppModel { get; set; } = new List<GetRoleWebAppModel>();

        #endregion

        #region On Render Method

        protected override async Task OnInitializedAsync()
        {
            await GetRoles();
            StateHasChanged();
        }


        #endregion

        #region API Service Call

        private async Task GetRoles()
        {
            var serviceResponse = await _roleWebAppService.GetRoles();
            if (serviceResponse.IsSuccessStatusCode)
            {
                getRoleWebAppModel = serviceResponse.Content;
            }
            else
            {
                getRoleWebAppModel = new();
            }
        }

        #endregion
    }
}
