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
}