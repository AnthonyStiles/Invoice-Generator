using Invoice_Generator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator.Infrastructure.Data.PropertySettings;

public static class PaymentDetailPropertySettings
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaymentDetail>()
            .Property(paymentDetail => paymentDetail.Bank)
            .HasMaxLength(50);

        modelBuilder.Entity<PaymentDetail>()
            .Property(paymentDetail => paymentDetail.AccountHolder)
            .HasMaxLength(50);

        modelBuilder.Entity<PaymentDetail>()
            .Property(paymentDetail => paymentDetail.SortCode)
            .HasMaxLength(8);

        modelBuilder.Entity<PaymentDetail>()
            .Property(paymentDetail => paymentDetail.AccountNumber)
            .HasMaxLength(8);
    }
}