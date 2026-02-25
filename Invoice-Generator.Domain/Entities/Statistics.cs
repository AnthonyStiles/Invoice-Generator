namespace Invoice_Generator.Domain.Entities;

public class Statistics : BaseEntity
{
    public int TotalInvoicesGenerated { get; set; }
    
    public int IncrementTotalInvoicesGenerated() => TotalInvoicesGenerated++;
}