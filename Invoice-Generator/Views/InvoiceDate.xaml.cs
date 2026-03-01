using Invoice_Generator.Application.Handlers;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

public partial class InvoiceDate : ContentPage
{
    public InvoiceDate(IRepository repository, IInvoiceGenerator invoiceGenerator,
        ICreateInvoiceHandler createInvoiceHandler)
    {
        InitializeComponent();
        BindingContext = new InvoiceDateViewModel(repository, invoiceGenerator, createInvoiceHandler);
    }
}