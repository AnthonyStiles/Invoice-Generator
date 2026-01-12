using Microsoft.Extensions.Logging;
using Invoice_Generator.Infrastructure;
using Invoice_Generator.Infrastructure.Data;
using Invoice_Generator.Domain.Interfaces;

namespace Invoice_Generator;

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

		builder.Services.AddDbContext(FileSystem.AppDataDirectory);
		builder.Services.AddTransient<IRepository, EntityFrameworkRepository>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		var app = builder.Build();

		return app;
	}
}
