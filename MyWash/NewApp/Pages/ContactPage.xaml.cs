using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace NewApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            BindingContext = new ContactViewModel();
        }
    }

    public class ContactViewModel
    {
        public Command SmsCommand { get; }
        public Command EmailCommand { get; }
        public Command PhoneCommand { get; }
        public Command NavigateCommand { get; }
        public Models.Contact Contact { get; }

        public ContactViewModel(Models.Contact contact)
        {
            Contact = contact;
        }
        public ContactViewModel()
        {
            Contact = new Models.Contact
            {
                Name = "Bahia Schoonmaakbedrijf",
                Address = "Flamingostraat 28/H",
                City = "Amsterdam",
                State = "North Holland",
                ZipCode = "1022 BH",
                Email = "info@bahiasmb.nl",
                PhoneNumber = "+31 6 33373816"
            };

            SmsCommand = new Command(async () => await ExecuteSmsCommand());
            EmailCommand = new Command(async () => await ExecuteEmailCommand());
            PhoneCommand = new Command(ExecutePhoneCommand);
            NavigateCommand = new Command(async () => await ExecuteNavigateCommand());
        }

        async Task ExecuteSmsCommand()
        {
            try
            {
                await Sms.ComposeAsync(new SmsMessage(string.Empty, Contact.PhoneNumber));
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        async Task ExecuteEmailCommand()
        {
            try
            {
                await Email.ComposeAsync(string.Empty, string.Empty, Contact.Email);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        void ExecutePhoneCommand()
        {
            try
            {
                PhoneDialer.Open(Contact.PhoneNumber);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        async Task ExecuteNavigateCommand()
        {
            try
            {
                await Map.OpenAsync(new Placemark
                {
                    Thoroughfare = Contact.Address,
                    Locality = Contact.City,
                    AdminArea = Contact.State,
                    PostalCode = Contact.ZipCode
                });
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        void ProcessException(Exception ex)
        {
            if (ex != null)
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}