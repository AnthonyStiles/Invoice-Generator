using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels.Invoice;

namespace Invoice_Generator.Views.Invoice;

public partial class PaymentDetailSelector : ContentPage
{
    public PaymentDetailSelector(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new PaymentDetailSelectorViewModel(repository);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is PaymentDetailSelectorViewModel viewModel)
            viewModel.LoadPaymentDetailsCommand.Execute(null);
    }
}