using Invoice_Generator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator.Infrastructure.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public DbSet<AddressFrom> FromAddresses { get; set; }
    public DbSet<AddressTo> ToAddresses { get; set; }
    public DbSet<Work> Work { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
}
