using Invoice_Generator.Application.Data;

namespace Invoice_Generator.Application.Handlers;

public interface ICreateInvoiceHandler
{
    public void Handle(CreateInvoiceData data);
}