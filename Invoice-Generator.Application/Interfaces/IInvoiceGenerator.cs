using Invoice_Generator.Domain.Entities;

namespace Invoice_Generator.Application.Interfaces;

public interface IInvoiceGenerator
{
    public void GenerateInvoice(Invoice invoice, string outputDirectory);
}