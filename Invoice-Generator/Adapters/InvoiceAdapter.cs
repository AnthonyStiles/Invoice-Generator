using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;

namespace Invoice_Generator.Adapters;

internal static class InvoiceAdapter
{
    internal static Invoice ToInvoice(this InvoiceModel invoiceModel)
    {
        return new Invoice
        {
            Invoiced = invoiceModel.Invoiced,
            Work = invoiceModel.Work.ToWork(),
            AddressFromName = invoiceModel.AddressFromName,
            AddressFromLine1 = invoiceModel.AddressFromLine1,
            AddressFromLine2 = invoiceModel.AddressFromLine2,
            AddressFromEmail = invoiceModel.AddressFromEmail,
            AddressFromPhone = invoiceModel.AddressFromPhone,
            AddressFromPostCode = invoiceModel.AddressFromPostCode,
            AddressToLine1 = invoiceModel.AddressToLine1,
            AddressToLine2 = invoiceModel.AddressToLine2,
            AddressToName = invoiceModel.AddressToName,
            AddressToPostCode = invoiceModel.AddressToPostCode
        };
    }

    private static InvoiceModel ToInvoiceModel(this Invoice invoice)
    {
        return new InvoiceModel
        {
            Work = invoice.Work.ToList().ToWorkModels(),
            AddressFromName = invoice.AddressFromName,
            AddressFromLine1 = invoice.AddressFromLine1,
            AddressFromLine2 = invoice.AddressFromLine2,
            AddressFromEmail = invoice.AddressFromEmail,
            AddressFromPhone = invoice.AddressFromPhone,
            AddressFromPostCode = invoice.AddressFromPostCode,
            AddressToLine1 = invoice.AddressToLine1,
            AddressToLine2 = invoice.AddressToLine2,
            AddressToName = invoice.AddressToName,
            AddressToPostCode = invoice.AddressToPostCode,
            Invoiced = invoice.Invoiced,
            Id = invoice.Id
        };
    }

    internal static List<InvoiceModel> ToInvoiceModels(this List<Invoice> invoices)
    {
        return invoices.ConvertAll(invoice => invoice.ToInvoiceModel());
    }
}