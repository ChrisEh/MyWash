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
    public partial class RequestPickupPage : ContentPage
    {
        public RequestPickupPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var order = new Order()
            {
                Address = EntAddress.Text,
                UserId = Preferences.Get("userId", 0),
                Phone = EntPhone.Text,
                FullName = EntName.Text,
                OrderPlaced = DateTime.Now
            };

            var response = await ApiService.PlaceOrderAsync(order);
            if (response != null)
            {
                await DisplayAlert("", "Your pickup id is " + response.OrderId, "OK");
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("", "Something went wrong.", "Cancel");
            }
        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}