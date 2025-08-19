using DadJokesApp.Services;
using DadJokesApp.ViewModels;
using DadJokesApp.Views;
using Microsoft.Extensions.Logging;

namespace DadJokesApp
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<DadJokeApiService>();
            builder.Services.AddTransient<DisplayJokesView>();
            builder.Services.AddSingleton<DisplayJokesViewModel>();

            return builder.Build();
        }
    }
}
