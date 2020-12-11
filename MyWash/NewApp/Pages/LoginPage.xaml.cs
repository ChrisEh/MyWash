using NewApp.Models;
using NewApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(string email, string password)
        {
            InitializeComponent();
            EntEmail.Text = email;
            EntPassword.Text = password;
            App.UserInfo = new LocalUserInfo()
            {
                Email = email
            };
        }

        private async void TapBackArrow_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var response = await ApiService.LoginAsync(EntEmail.Text, EntPassword.Text);

            if (response)
            {
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("Oops", "Wrong email or password.", "Cancel");
            }
        }
    }
}