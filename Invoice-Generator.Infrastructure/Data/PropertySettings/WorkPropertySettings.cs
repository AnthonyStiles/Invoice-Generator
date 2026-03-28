using Invoice_Generator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator.Infrastructure.Data.PropertySettings;

public static class WorkPropertySettings
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Work>()
            .Property(work => work.Description)
            .HasMaxLength(200);
    }
}