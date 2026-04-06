using CommunityToolkit.Maui.Views;
using Invoice_Generator.ViewModels.Popups;

namespace Invoice_Generator.Views.Popups;

public partial class TermsAndConditionsPrompt : Popup
{
    public TermsAndConditionsPrompt()
    {
        InitializeComponent();
        BindingContext = new TermsAndConditionsPromptViewModel();

        Opened += OnPopupOpened;
    }

    private void OnPopupOpened(object sender, EventArgs e)
    {
        if (BindingContext is TermsAndConditionsPromptViewModel viewModel)
        {
            viewModel.LoadTermsAndConditionsCommand.Execute(null);
        }
    }
}