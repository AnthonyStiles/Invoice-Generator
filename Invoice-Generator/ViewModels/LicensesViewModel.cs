using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Invoice_Generator.ViewModels;

public partial class LicensesViewModel : ObservableObject
{
    [ObservableProperty]
    private string licenseText;

    [RelayCommand]
    private async Task LoadLicensesAsync()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("Licenses.txt");
            using var reader = new StreamReader(stream);
            LicenseText = await reader.ReadToEndAsync();
        }
        catch (Exception ex)
        {
            LicenseText = $"Error loading licenses: {ex.Message}";
        }
    }
}
