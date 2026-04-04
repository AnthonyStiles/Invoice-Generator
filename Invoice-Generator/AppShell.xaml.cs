using Invoice_Generator.Views.Invoice;
using Invoice_Generator.Views.Settings;

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
        Routing.RegisterRoute(nameof(InvoiceDate), typeof(InvoiceDate));
        Routing.RegisterRoute(nameof(PaymentDetailSelector), typeof(PaymentDetailSelector));
        Routing.RegisterRoute(nameof(PaymentDetailEdit), typeof(PaymentDetailEdit));
        Routing.RegisterRoute(nameof(Settings), typeof(Settings));
        Routing.RegisterRoute(nameof(PrivacyPolicy), typeof(PrivacyPolicy));
        Routing.RegisterRoute(nameof(Licenses), typeof(Licenses));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}