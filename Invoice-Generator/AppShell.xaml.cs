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
	}
}