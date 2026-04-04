using Invoice_Generator.ViewModels.Settings;

namespace Invoice_Generator.Views.Settings;

public partial class Licenses : ContentPage
{
	public Licenses()
	{
		InitializeComponent();
		BindingContext = new LicensesViewModel();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is LicensesViewModel viewModel)
		{
			viewModel.LoadLicensesCommand.Execute(null);
		}
	}
}
