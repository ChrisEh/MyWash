using NewApp.Models;
using NewApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<PopularProduct> ProductsCollection { get; set; }

        public HomePage()
        {
            InitializeComponent();

            ProductsCollection = new ObservableCollection<PopularProduct>();
            GetPopularProducts();
        }

        private async void GetPopularProducts()
        {
            var products = await ApiService.GetPopularProductsAsync();

            products.ForEach(p => ProductsCollection.Add(p));
        }

        private async void ImgMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        }

        private void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            CloseSideMenu();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CloseSideMenu();
        }

        private async void CloseSideMenu()
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RequestPickupPage());
        }

        private void TapPickups_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PickupsPage());
        }

        private void TapMyData_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyDataPage());
        }
    }
}