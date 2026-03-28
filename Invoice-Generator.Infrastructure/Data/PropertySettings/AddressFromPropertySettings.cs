using Invoice_Generator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator.Infrastructure.Data.PropertySettings;

public static class AddressFromPropertySettings
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressFrom>()
            .Property(addressFrom => addressFrom.Name)
            .HasMaxLength(50);

        modelBuilder.Entity<AddressFrom>()
            .Property(addressFrom => addressFrom.Line1)
            .HasMaxLength(50);

        modelBuilder.Entity<AddressFrom>()
            .Property(addressFrom => addressFrom.Line2)
            .HasMaxLength(50);

        modelBuilder.Entity<AddressFrom>()
            .Property(addressFrom => addressFrom.PostCode)
            .HasMaxLength(8);

        modelBuilder.Entity<AddressFrom>()
            .Property(addressFrom => addressFrom.Email)
            .HasMaxLength(50);

        modelBuilder.Entity<AddressFrom>()
            .Property(addressFrom => addressFrom.Phone)
            .HasMaxLength(11);
    }
}