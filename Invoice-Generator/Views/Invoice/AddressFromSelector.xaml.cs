using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels.Invoice;

namespace Invoice_Generator.Views.Invoice;

public partial class AddressFromSelector : ContentPage
{
    public AddressFromSelector(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new AddressFromSelectorViewModel(repository);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is AddressFromSelectorViewModel viewModel)
        {
            viewModel.LoadAddressesCommand.Execute(null);
        }
    }
}