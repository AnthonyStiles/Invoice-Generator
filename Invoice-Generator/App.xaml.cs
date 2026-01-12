using Invoice_Generator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice_Generator;

public partial class App : Application
{
    private readonly AppDBContext _appDBContext;

    public App(AppDBContext appDBContext)
	{
		InitializeComponent();
        _appDBContext = appDBContext;
    }

	protected override Window CreateWindow(IActivationState? activationState)
	{
		_appDBContext.Database.Migrate();
		return new Window(new AppShell());
	}
}