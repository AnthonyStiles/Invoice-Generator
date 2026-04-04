using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Invoice_Generator.ViewModels;

public partial class PrivacyPolicyViewModel : ObservableObject
{
    private const string PrivacyPolicyUrl = "https://gist.githubusercontent.com/AnthonyStiles/05b151fcba1c4eeadb082bd695409c4f/raw/9c6cf5b9adc33b01672b45af524f2ef12c40546f/invoiced-privacy-policy.html";

    [ObservableProperty]
    private HtmlWebViewSource htmlSource;

    [RelayCommand]
    private async Task LoadHtmlAsync()
    {
        try
        {
            using var client = new HttpClient();
            var html = await client.GetStringAsync(PrivacyPolicyUrl);
            HtmlSource = new HtmlWebViewSource { Html = html };
        }
        catch (Exception ex)
        {
            HtmlSource = new HtmlWebViewSource { Html = $"<html><body><h1>Error loading privacy policy</h1><p>{ex.Message}</p></body></html>" };
        }
    }
}
