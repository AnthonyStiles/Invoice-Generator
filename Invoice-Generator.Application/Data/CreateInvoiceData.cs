using Invoice_Generator.Domain.Entities;

namespace Invoice_Generator.Application.Data;

public class CreateInvoiceData
{
    public Invoice? Invoice { get; set; }
    public int InvoiceNumber { get; set; }
}