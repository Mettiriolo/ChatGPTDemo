using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ChatGPTDemo;

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
        builder.Configuration.AddUserSecrets<App>();
        Constants.ApiUri = builder.Configuration["OpenAI:ApiUri"];
        Constants.ApiKey = builder.Configuration["OpenAI:ApiKey"];

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
