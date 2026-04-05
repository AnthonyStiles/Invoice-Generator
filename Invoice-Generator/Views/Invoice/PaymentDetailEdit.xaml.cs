using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels.Invoice;

namespace Invoice_Generator.Views.Invoice;

public partial class PaymentDetailEdit : ContentPage
{
    public PaymentDetailEdit(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new PaymentDetailEditViewModel(repository);
    }
}