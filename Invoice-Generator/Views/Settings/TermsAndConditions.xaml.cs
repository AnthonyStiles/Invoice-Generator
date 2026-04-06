using Invoice_Generator.ViewModels.Settings;

namespace Invoice_Generator.Views.Settings;

public partial class TermsAndConditions : ContentPage
{
    public TermsAndConditions()
    {
        InitializeComponent();
        BindingContext = new TermsAndConditionsViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is TermsAndConditionsViewModel viewModel)
        {
            viewModel.LoadTermsAndConditionsCommand.Execute(null);
        }
    }
}