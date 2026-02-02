namespace Invoice_Generator.Domain.Entities;

public class Work : BaseEntity
{
    public DateTime Completed { get; set; }
    public string? Description { get; set; }
    public decimal Hours { get; set; }
    public decimal Amount { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
}