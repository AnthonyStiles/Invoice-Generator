using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Helpers;
using Invoice_Generator.Views.Settings;

namespace Invoice_Generator.ViewModels.Settings;

public partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty]
    private int invoiceNumber;

    public SettingsViewModel()
    {
        InvoiceNumber = InvoiceNumberHelper.GetInvoiceNumber();
    }

    [RelayCommand]
    private async Task OpenLicensesAsync()
    {
        await Shell.Current.GoToAsync(nameof(Licenses));
    }

    [RelayCommand]
    private async Task OpenPrivacyPolicyAsync()
    {
        await Shell.Current.GoToAsync(nameof(PrivacyPolicy));
    }

    [RelayCommand]
    private async Task OpenTermsAndConditionsAsync()
    {
        await Shell.Current.GoToAsync(nameof(TermsAndConditions));
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        InvoiceNumberHelper.SetInvoiceNumber(InvoiceNumber);
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}