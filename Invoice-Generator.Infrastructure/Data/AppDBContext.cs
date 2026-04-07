using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Infrastructure.Data.PropertySettings;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator.Infrastructure.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public DbSet<AddressFrom> FromAddresses { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    public DbSet<AddressTo> ToAddresses { get; set; }
    public DbSet<Work> Work { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AddressFromPropertySettings.Configure(modelBuilder);
        AddressToPropertySettings.Configure(modelBuilder);
        WorkPropertySettings.Configure(modelBuilder);
        PaymentDetailPropertySettings.Configure(modelBuilder);
        InvoicePropertySettings.Configure(modelBuilder);
    }
}