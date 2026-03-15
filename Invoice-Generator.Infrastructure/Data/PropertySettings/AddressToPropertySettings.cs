using Invoice_Generator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator.Infrastructure.Data.PropertySettings;

public static class AddressToPropertySettings
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressTo>()
            .Property(addressTo => addressTo.Name)
            .HasMaxLength(50);
        
        modelBuilder.Entity<AddressTo>()
            .Property(addressTo => addressTo.Line1)
            .HasMaxLength(50);
        
        modelBuilder.Entity<AddressTo>()
            .Property(addressTo => addressTo.Line2)
            .HasMaxLength(50);
        
        modelBuilder.Entity<AddressTo>()
            .Property(addressTo => addressTo.PostCode)
            .HasMaxLength(8);
    }
}
