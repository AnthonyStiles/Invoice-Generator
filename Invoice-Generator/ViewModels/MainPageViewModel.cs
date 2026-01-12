using Invoice_Generator.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Invoice_Generator.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [RelayCommand]
    private async Task OpenNewInvoiceAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddressFromSelector));
    }
}