using Invoice_Generator.Application.Handlers;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels.Invoice;

namespace Invoice_Generator.Views.Invoice;

public partial class InvoiceDate : ContentPage
{
    public InvoiceDate(IRepository repository, IInvoiceGenerator invoiceGenerator,
        ICreateInvoiceHandler createInvoiceHandler)
    {
        InitializeComponent();
        BindingContext = new InvoiceDateViewModel(repository, invoiceGenerator, createInvoiceHandler);
    }
}