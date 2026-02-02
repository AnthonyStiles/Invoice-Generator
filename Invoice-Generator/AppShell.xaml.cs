using Invoice_Generator.Views;

namespace Invoice_Generator;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddressFromSelector), typeof(AddressFromSelector));
		Routing.RegisterRoute(nameof(AddressFromEdit), typeof(AddressFromEdit));
		Routing.RegisterRoute(nameof(AddressToSelector), typeof(AddressToSelector));
		Routing.RegisterRoute(nameof(AddressToEdit), typeof(AddressToEdit));
		Routing.RegisterRoute(nameof(WorkEdit), typeof(WorkEdit));
		Routing.RegisterRoute(nameof(AdditionalDetails), typeof(AdditionalDetails));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
	}
}