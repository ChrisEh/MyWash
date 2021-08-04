using NewApp.Services;
using System;
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
                var response = await ApiService.RegisterUserAsync(EntName.Text, EntEmail.Text, EntPassword.Text, EntPlace.Text, 
                    EntPostCode.Text, EntPhoneNumber.Text, EntStreetName.Text, EntHouseNumber.Text);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Hi", "Your account has been created.", "Alright");
                    await Navigation.PushModalAsync(new LoginPage(EntEmail.Text, EntPassword.Text));
                }
                else
                {
                    await DisplayAlert("Oops", await response.Content.ReadAsStringAsync(), "OK");
                }
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}