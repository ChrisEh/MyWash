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
    public partial class MyDataPage : ContentPage
    {
        public MyDataPage()
        {
            InitializeComponent();

        }

        private void CheckForExistingData()
        {

        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {

        }

        private void BtnPlaceOrder_Clicked(object sender, EventArgs e)
        {

        }

        private void EntName_Completed(object sender, EventArgs e)
        {
            LblName.IsVisible = true;
        }

        private void EntPhone_Completed(object sender, EventArgs e)
        {
            LblPhone.IsVisible = true;
        }

        private void EntPostCode_Completed(object sender, EventArgs e)
        {
            LblPostCode.IsVisible = true;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {

        }
    }
}