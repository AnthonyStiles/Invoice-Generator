using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Views;

namespace Invoice_Generator.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    [RelayCommand]
    private async Task OpenPrivacyPolicyAsync()
    {
        await Shell.Current.GoToAsync(nameof(PrivacyPolicy));
    }

    [RelayCommand]
    private async Task OpenLicensesAsync()
    {
        await Shell.Current.GoToAsync(nameof(Licenses));
    }
}
