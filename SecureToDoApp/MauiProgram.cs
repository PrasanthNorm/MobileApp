using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SecureToDoApp.Helper;
using SecureToDoApp.Repositories;
using SecureToDoApp.ViewModel;
using TodoSecureApp.Data;


namespace SecureToDoApp
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
                });

            // Configure MySQL Database with EF Core
            builder.Services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseMySql(Config.ConnectionString, ServerVersion.AutoDetect(Config.ConnectionString));
            });
            // Register services
            builder.Services.AddSingleton<ITodoRepository, TodoRepository>(); // Register your repository
            builder.Services.AddSingleton<TodoViewModel>(); // Register your ViewModel

            builder.Services.AddTransient<MainPage>(); // Ensure MainPage uses DI
            return builder.Build();
        }


       
    }
}
