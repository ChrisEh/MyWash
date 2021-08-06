using NewApp.Models;
using NewApp.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckDetailsPage : ContentPage
    {
        private User _user;

        public CheckDetailsPage(User user)
        {
            InitializeComponent();
            EntStreet.Text = user.StreetName;
            EntPhone.Text = user.PhoneNumber;
            EntHouseNumber.Text = user.HouseNumber;
            EntPostCode.Text = user.PostCode;
            EntPlace.Text = user.Place;

            _user = user;
        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void BtnConfirm_Clicked(object sender, EventArgs e)
        {
            await ApiService.UpdateUserDetailsAsync(Preferences.Get("userId", "0"), EntStreet.Text,
                EntHouseNumber.Text, EntPostCode.Text, EntPlace.Text, EntPhone.Text);

            // Send pickup.
            var pickup = new Pickup()
            {
                Id = new Guid().ToString(),
                UserId = _user.Id,
                PickupPlaced = DateTime.Now,
                IsPickupCompleted = false
            };

            var response = await ApiService.PlacePickupAsync(pickup);
            if (response != null)
            {
                await DisplayAlert("", "Your request got accepted. A driver is on his way.", "OK");
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("", "There is already an active pickup. You cannot order more than one.", "Cancel");
            }
        }
    }
}