using Fav.FinancialManager.Repositories;
using Fav.FinancialManager.Views;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace Fav.FinancialManager
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
                })
                .Register();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        #region Records
        public static MauiAppBuilder Register(this MauiAppBuilder app)
        {
            RegisterDataBase(app);
            RegisterRepositories(app);
            RegisterViews(app);

            return app;
        }

        private static void RegisterViews(MauiAppBuilder app)
        {
            app.Services.AddTransient<TransactionAdd>();
            app.Services.AddTransient<TransactionEdit>();
            app.Services.AddTransient<TransactionList>();
        }

        public static void RegisterDataBase(this MauiAppBuilder app)
        {
            app.Services.AddSingleton<LiteDatabase>(
                options => new LiteDatabase(AppSettings.DataBasePath));
        }

        public static void RegisterRepositories(this MauiAppBuilder app)
        {
            app.Services.AddTransient<ITransactionRepository, TransactionRepository>();
        }

        #endregion

    }
}
