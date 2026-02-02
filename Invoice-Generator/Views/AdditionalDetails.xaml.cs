using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

public partial class AdditionalDetails : ContentPage
{
    public AdditionalDetails(IRepository repository, IInvoiceGenerator invoiceGenerator)
    {
        InitializeComponent();
        BindingContext = new AdditionalDetailsViewModel(repository, invoiceGenerator);
    }
}