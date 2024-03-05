using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using FingerPrint.InyectionDependency.Models;

namespace FingerPrint.InyectionDependency
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
              .UseMauiApp<App>()
              .ConfigureFonts(fonts =>
              {
                  fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                  fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
              });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<IAlertService, AlertService>();
            builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);

            return builder.Build();
        }
    }
}