using Invoice_Generator.ViewModels;

namespace Invoice_Generator;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
	}
}