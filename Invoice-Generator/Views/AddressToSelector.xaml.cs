using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

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