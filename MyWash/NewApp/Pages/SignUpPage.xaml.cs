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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
            {
                await DisplayAlert("Password missmatch", "Please check your password.", "OK");
            }
            else
            {
                var response = await ApiService.RegisterUserAsync(EntName.Text, EntEmail.Text, EntPassword.Text, EntPlace.Text, EntPostCode.Text, EntPhoneNumber.Text, EntStreetName.Text);

                if (response)
                {
                    await DisplayAlert("Hi", "Your account has been created.", "Alright");
                    await Navigation.PushModalAsync(new LoginPage(EntEmail.Text, EntPassword.Text));
                }
                else
                {
                    await DisplayAlert("Oops", "Username or password entered is wrong.", "OK");
                }
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}