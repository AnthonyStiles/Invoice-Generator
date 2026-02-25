using Invoice_Generator.Domain.Entities;

namespace Invoice_Generator.Application.Handlers;

public interface ICreateInvoiceHandler
{
    public Invoice Handle(Invoice invoice);
}