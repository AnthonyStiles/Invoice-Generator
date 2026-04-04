using CommunityToolkit.Maui;
using Invoice_Generator.Application.Handlers;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Helpers;
using Invoice_Generator.Infrastructure;
using Invoice_Generator.Infrastructure.Data;
using Invoice_Generator.Infrastructure.InvoiceGeneration;
using Microsoft.Extensions.Logging;

namespace Invoice_Generator;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        DatabaseInitialiser.Initialise();
        
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var dbPassword = SecureKeyRetriever.GetKeyAsync("db_key").GetAwaiter().GetResult();
        builder.Services.AddDbContext(FileSystem.AppDataDirectory, dbPassword);
        builder.Services.AddTransient<IRepository, EntityFrameworkRepository>();
        builder.Services.AddTransient<IInvoiceGenerator, MigraDocInvoiceGenerator>();
        builder.Services.AddTransient<ICreateInvoiceHandler, CreateInvoiceHandler>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        return app;
    }
}