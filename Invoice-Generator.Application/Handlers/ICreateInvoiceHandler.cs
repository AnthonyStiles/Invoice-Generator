using Invoice_Generator.Domain.Entities;

namespace Invoice_Generator.Application.Handlers;

public interface ICreateInvoiceHandler
{
    public void Handle(Invoice invoice);
}