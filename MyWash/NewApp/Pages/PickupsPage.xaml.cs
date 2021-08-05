using NewApp.Models;
using NewApp.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickupsPage : ContentPage
    {
        public ObservableCollection<PickupByUser> PickupsCollection { get; set; }
        public PickupsPage()
        {
            InitializeComponent();
            PickupsCollection = new ObservableCollection<PickupByUser>();
            GetPickups();
        }

        private async void GetPickups()
        {
            var pickups = await ApiService.GetPickupsByUserAsync(Preferences.Get("userId", "0"));
            pickups.ForEach(o => PickupsCollection.Add(o));
            LvPickups.ItemsSource = PickupsCollection;
            var x = 0;
        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}