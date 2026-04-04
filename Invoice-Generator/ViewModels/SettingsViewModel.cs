using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Invoice_Generator.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    private const string PrivacyPolicyUrl = "https://gist.githubusercontent.com/AnthonyStiles/05b151fcba1c4eeadb082bd695409c4f/raw/9c6cf5b9adc33b01672b45af524f2ef12c40546f/invoiced-privacy-policy.html";

    [ObservableProperty]
    private HtmlWebViewSource htmlSource;

    [RelayCommand]
    private async Task LoadHtmlAsync()
    {
        using var client = new HttpClient();
        var html = await client.GetStringAsync(PrivacyPolicyUrl);
        HtmlSource = new HtmlWebViewSource { Html = html };
    }
}
