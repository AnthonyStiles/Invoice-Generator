using Invoice_Generator.ViewModels.Settings;

namespace Invoice_Generator.Views.Settings;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
		BindingContext = new SettingsViewModel();
	}
}
