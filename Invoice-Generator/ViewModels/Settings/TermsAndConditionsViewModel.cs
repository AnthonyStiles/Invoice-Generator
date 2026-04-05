using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Invoice_Generator.ViewModels.Settings;

public partial class TermsAndConditionsViewModel : ObservableObject
{
    [ObservableProperty]
    private string termsAndConditionsText;

    [RelayCommand]
    private async Task LoadTermsAndConditionsAsync()
    {
        try
        {
            await using var stream = await FileSystem.OpenAppPackageFileAsync("ELUA.txt");
            using var reader = new StreamReader(stream);
            TermsAndConditionsText = await reader.ReadToEndAsync();
        }
        catch (Exception ex)
        {
            TermsAndConditionsText = $"Error loading terms and conditions.";
        }
    }
}
