using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

public partial class PaymentDetailEdit : ContentPage
{
    public PaymentDetailEdit(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new PaymentDetailEditViewModel(repository);
    }

    private void OnEntryLoaded(object sender, EventArgs e)
    {
        NameEntry.Focus();
    }
}