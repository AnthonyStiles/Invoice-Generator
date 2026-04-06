using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Helpers;

namespace Invoice_Generator.ViewModels.Settings;

public partial class LicensesViewModel : ObservableObject
{
    [ObservableProperty]
    private string licenseText;

    [RelayCommand]
    private async Task LoadLicensesAsync()
    {
        LicenseText = await ResourceFileReader.Read("Licenses.txt", "Error loading licenses.");
    }
}