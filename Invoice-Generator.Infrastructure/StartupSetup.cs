using Invoice_Generator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice_Generator.Infrastructure;

public static class StartupSetup
{
    //Might not even need this
    public static void AddDbContext(this IServiceCollection services, string path, string password)
    {
        services.AddDbContext<AppDBContext>(options =>
            options.UseSqlite($"Data Source={Path.Combine(path, "data.db")};Password={password};"));
    }

    public static void InitialiseDatabase(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
        dbContext.Database.Migrate();
    }
}