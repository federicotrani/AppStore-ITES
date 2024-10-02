using AppStore.mvvm.ViewModels;
using AppStore.mvvm.Views;
using Microsoft.Extensions.Logging;

namespace AppStore
{
    public static class MauiProgram
    {
        private const string BaseAddress = "https://localhost:7028/";

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

#if DEBUG
    		builder.Logging.AddDebug();
#endif        
            
            

            return builder.Build();
        }
    }
}
