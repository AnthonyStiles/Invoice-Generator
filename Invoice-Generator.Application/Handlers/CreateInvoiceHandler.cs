using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Domain;
using Invoice_Generator.Domain.Entities;

namespace Invoice_Generator.Application.Handlers;

public class CreateInvoiceHandler(IRepository repository) : ICreateInvoiceHandler
{
    public void Handle(Invoice invoice)
    {
        var statistics = repository.GetAll<Statistics>().FirstOrDefault();

        if (statistics == null)
        {
            statistics = new Statistics();
            statistics.IncrementTotalInvoicesGenerated();
            repository.Add(statistics);
        }
        else
        {
            statistics.IncrementTotalInvoicesGenerated();
            repository.Update(statistics);
        }

        invoice.Number = InvoiceNumberFormatter.Format(statistics.TotalInvoicesGenerated, invoice.Invoiced);
        repository.Add(invoice);
    }
}