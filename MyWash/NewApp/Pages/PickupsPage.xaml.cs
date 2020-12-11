using NewApp.Models;
using NewApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickupsPage : ContentPage
    {
        public ObservableCollection<OrderByUser> OrdersCollection { get; set; }
        public PickupsPage()
        {
            InitializeComponent();
            OrdersCollection = new ObservableCollection<OrderByUser>();
            GetPickups();
        }

        private async void GetPickups()
        {
            var orders = await ApiService.GetOrdersByUserAsync(Preferences.Get("userId", 0));
            orders.ForEach(o => OrdersCollection.Add(o));
            LvPickups.ItemsSource = OrdersCollection;
            var x = 0;

        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}