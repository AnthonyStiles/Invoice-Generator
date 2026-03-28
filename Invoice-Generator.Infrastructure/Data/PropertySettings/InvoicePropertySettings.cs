using Invoice_Generator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator.Infrastructure.Data.PropertySettings;

public static class InvoicePropertySettings
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressFromName)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressFromLine1)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressFromLine2)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressFromPostCode)
            .HasMaxLength(8);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressFromEmail)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressFromPhone)
            .HasMaxLength(11);


        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressToName)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressToLine1)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressToLine2)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AddressToPostCode)
            .HasMaxLength(8);


        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.Bank)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AccountHolder)
            .HasMaxLength(50);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.SortCode)
            .HasMaxLength(8);

        modelBuilder.Entity<Invoice>()
            .Property(invoice => invoice.AccountNumber)
            .HasMaxLength(8);
    }
}