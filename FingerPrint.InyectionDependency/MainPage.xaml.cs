using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using FingerPrint.InyectionDependency.Models;

namespace FingerPrint.InyectionDependency
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainView)
        {
            InitializeComponent();
            BindingContext = mainView;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            //var isAvailable = await CrossFingerprint.Current.IsAvailableAsync();

            //if (isAvailable)
            //{
            //    var request = new AuthenticationRequestConfiguration
            //    ("Login using biometrics", "Confirm login with your biometrics");

            //    var result = await CrossFingerprint.Current.AuthenticateAsync(request);

            //    if (result.Authenticated)
            //    {
            //        await DisplayAlert("Authenticated!", "Access granted", "OK");
            //    }
            //    else
            //    {
            //        await DisplayAlert("Not authenticated!", "Access denied", "OK");
            //    }
            //}
        }
    }
}