using E_BOOK.UI.Service.Interface;
using Microsoft.AspNetCore.Components;
using MODEL.Entity;

namespace E_BOOK.UI.Pages
{
    public partial class Login
    {

        SignInModel user = new SignInModel();
        [Inject]
        IAccountHttpService accountHttpService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }
        
        public string cssStyle { get; set; } = "d-none";
        public string error { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var localstorage = await localStorageService.GetItemAsStringAsync("token");
            if (localstorage == null)
            {
                navigationManager.NavigateTo("/login");
            }
            else
            {
                navigationManager.NavigateTo("/");
            }
        }
        public async void HandleLogin()
            
        {
            try
            {
                var signIn = await accountHttpService.LoginAsyc(user);
                if (signIn != null)
                {
                    navigationManager.NavigateTo("/");
                }
            }
            catch (Exception ex)
            {

                cssStyle = "d-block";
                error = ex.Message;
            }
            
        }
    }
}
