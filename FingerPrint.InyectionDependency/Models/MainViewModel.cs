using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FingerPrint.InyectionDependency.Models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IFingerprint _fingerprint;

        private ICommand _fingerprintCommand;

        public MainViewModel(IFingerprint fingerprint)
        {
            _fingerprint = fingerprint;
        }

        public ICommand FingerprintCommand => _fingerprintCommand ??= new Command(async () => await FingerprintLoginAsync());

        async Task FingerprintLoginAsync()
        {
            var isAvailable = await _fingerprint.IsAvailableAsync();

            if (isAvailable)
            {
                //var request = new AuthenticationRequestConfiguration
                //("Login using biometrics", "Confirm login with your biometrics");

                var request = new AuthenticationRequestConfiguration
                ("Login using biometrics", "Confirm login with your biometrics")
                {
                    FallbackTitle = "Use PIN",
                    AllowAlternativeAuthentication = true,
                }; ;

                var result = await _fingerprint.AuthenticateAsync(request);

                if (result.Authenticated)
                {
                    Task.Run(async () =>
                    {
                        await Task.Delay(2000);
                        App.AlertSvc.ShowAlert("Authenticated!", "Access granted", "OK");
                        //App.AlertSvc.ShowConfirmation("Authenticated!", "Access granted", (result =>
                        //{
                        //    App.AlertSvc.ShowAlert("Result", $"{result}");
                        //}));
                    });
                    //await DisplayAlert("Authenticated!", "Access granted", "OK");
                }
                else
                {
                    Task.Run(async () =>
                    {
                        await Task.Delay(2000);
                        App.AlertSvc.ShowAlert("Not Authenticated", "Access denied", "OK");
                        //App.AlertSvc.ShowConfirmation("Not Authenticated", "Access denied", (result =>
                        //{
                        //    App.AlertSvc.ShowAlert("Result", $"{result}");
                        //}));
                    });
                    //await DisplayAlert("Not authenticated!", "Access denied", "OK");
                }
            }
        }

        async Task ValidateFingerDevice()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
