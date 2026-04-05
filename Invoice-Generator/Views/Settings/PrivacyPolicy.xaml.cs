using Invoice_Generator.ViewModels.Settings;

namespace Invoice_Generator.Views.Settings;

public partial class PrivacyPolicy : ContentPage
{
    public PrivacyPolicy()
    {
        InitializeComponent();
        BindingContext = new PrivacyPolicyViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is PrivacyPolicyViewModel viewModel)
        {
            viewModel.LoadHtmlCommand.Execute(null);
        }
    }
}