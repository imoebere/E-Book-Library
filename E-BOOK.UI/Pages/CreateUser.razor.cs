﻿using E_BOOK.UI.Service.Interface;
using E_BOOK.UI.Shared;
using Microsoft.AspNetCore.Components;
using MODEL.DTO;
using MODEL.Entity;

namespace E_BOOK.UI.Pages
{
    public partial class CreateUser
    {


        SignUp user = new SignUp();

        [Inject]
        IAccountHttpService accountHttpService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        public string cssStyle { get; set; } = "d-none";
        public string error { get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }
    
        public async void HandleRegister()
        {
            try
            {
                var signUp = await accountHttpService.SignUpAsync(user);
                if (signUp)
                {
                    navigationManager.NavigateTo("/admin-dashboard");
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
