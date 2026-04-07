using Invoice_Generator.Application.Data;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Domain;

namespace Invoice_Generator.Application.Handlers;

public class CreateInvoiceHandler(IRepository repository) : ICreateInvoiceHandler
{
    public void Handle(CreateInvoiceData data)
    {
        if (data.Invoice != null)
        {
            data.Invoice.Number = InvoiceNumberFormatter.Format(data.InvoiceNumber, data.Invoice.Invoiced);
            repository.Add(data.Invoice);
        }
    }
}