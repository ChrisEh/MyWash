using NewApp.Models;
using NewApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckDetailsPage : ContentPage
    {
        public CheckDetailsPage(User user)
        {
            InitializeComponent();
            EntStreet.Text = user.StreetName;
            EntPhone.Text = user.PhoneNumber;
            EntHouseNumber.Text = user.HouseNumber;
            EntPostCode.Text = user.PostCode;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var order = new Order()
            //{
            //    User = new User() {Id = new Guid(Preferences.Get("userId", 0).ToString()),
            //    Phone = EntPhone.Text,
            //    OrderPlaced = DateTime.Now
            //};

            //var response = await ApiService.PlaceOrderAsync(order);
            //if (response != null)
            //{
            //    await DisplayAlert("", "Your pickup id is " + response.OrderId, "OK");
            //    Application.Current.MainPage = new NavigationPage(new HomePage());
            //}
            //else
            //{
            //    await DisplayAlert("", "Something went wrong.", "Cancel");
            //}
        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void BtnConfirm_Clicked(object sender, EventArgs e)
        {
            await ApiService.UpdateUserDetailsAsync(Preferences.Get("userId", "0"), EntStreet.Text,
                EntHouseNumber.Text, EntPostCode.Text, EntPlace.Text, EntPhone.Text);
        }
    }
}