using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Helpers;

namespace Invoice_Generator.ViewModels.Popups;

public partial class TermsAndConditionsPromptViewModel : ObservableObject
{
    [ObservableProperty]
    private string termsAndConditionsText;

    [RelayCommand]
    private async Task AcceptTermsAsync()
    {
        await Shell.Current.ClosePopupAsync(true);
    }

    [RelayCommand]
    private async Task DeclineTermsAsync()
    {
        await Shell.Current.ClosePopupAsync(false);
    }

    [RelayCommand]
    private async Task LoadTermsAndConditionsAsync()
    {
        TermsAndConditionsText = await ResourceFileReader.Read("EULA.txt", "Error loading Terms and Conditions.");
    }
}