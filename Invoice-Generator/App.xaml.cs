using Invoice_Generator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator;

public partial class App : Microsoft.Maui.Controls.Application
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