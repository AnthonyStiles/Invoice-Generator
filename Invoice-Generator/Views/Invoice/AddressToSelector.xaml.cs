using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels.Invoice;

namespace Invoice_Generator.Views.Invoice;

public partial class AddressToSelector : ContentPage
{
    public AddressToSelector(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new AddressToSelectorViewModel(repository);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is AddressToSelectorViewModel viewModel)
        {
            viewModel.LoadAddressesCommand.Execute(null);
        }
    }
}