using LoginPage.Views;
using Microsoft.Extensions.Logging;
using LoginPage.ViewModels;
using LoginPage.Service;
using LoginPage.Models;

namespace LoginPage
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

            //אד סינגלטון ודברים כאלו
            builder.Services.AddTransient<UserQuestionsPageView>();
            builder.Services.AddTransient<UserAdminPageView>();
            builder.Services.AddTransient<UserQuestionsPageViewModel>();
            builder.Services.AddTransient<UserAdminPageViewModel>();
            

            builder.Services.AddSingleton<QService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<RankService>();
            builder.Services.AddSingleton<StatusQService>();
            builder.Services.AddSingleton<SubjectQService>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}