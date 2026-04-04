using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
		BindingContext = new SettingsViewModel();
	}
}
