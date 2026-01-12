using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

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