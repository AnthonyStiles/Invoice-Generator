using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator;

public partial class MainPage : ContentPage
{
	public MainPage(IRepository repository, IInvoiceGenerator invoiceGenerator)
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel(repository, invoiceGenerator);
	}
	
	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is MainPageViewModel viewModel)
		{
			viewModel.LoadInvoicesCommand.Execute(null);
		}
	}
}