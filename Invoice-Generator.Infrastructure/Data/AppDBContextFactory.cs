using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Invoice_Generator.Infrastructure.Data;

public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
{
    public AppDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
        
        optionsBuilder.UseSqlite("Data Source=designTime.db");

        return new AppDBContext(optionsBuilder.Options);
    }
}
