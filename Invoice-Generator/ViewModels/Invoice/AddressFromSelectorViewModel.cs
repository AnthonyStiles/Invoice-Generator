using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;
using Invoice_Generator.Views.Invoice;
using Invoice_Generator.Views.Settings;

namespace Invoice_Generator.ViewModels.Invoice;

[QueryProperty("Invoice", "Invoice")]
public partial class AddressFromSelectorViewModel(IRepository repository) : ObservableObject
{
    private AddressFromModel? address;

    [ObservableProperty] private ObservableCollection<AddressFromModel> addresses = [];

    [ObservableProperty] public InvoiceModel invoice;

    [ObservableProperty] private AddressFromModel? selectedAddress;

    [RelayCommand]
    private void DeleteAddress(AddressFromModel deletedAddress)
    {
        if (Addresses.Contains(deletedAddress))
        {
            var entity = repository.GetByID<AddressFrom>(deletedAddress.Id);
            if (entity != null) repository.Delete(entity);
            LoadAddresses();
        }
    }

    [RelayCommand]
    private void LoadAddresses()
    {
        Addresses.Clear();
        var data = repository.GetAll<AddressFrom>().ToAddressFromModels();
        Addresses = new ObservableCollection<AddressFromModel>(data);
    }

    [RelayCommand]
    private async Task OnAddNewDetailsAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddressFromEdit));
    }

    [RelayCommand]
    private async Task OnAddressChangedAsync()
    {
        if (SelectedAddress != null)
        {
            Invoice ??= new InvoiceModel();
            Invoice.AddressFromEmail = SelectedAddress.Email;
            Invoice.AddressFromLine1 = SelectedAddress.Line1;
            Invoice.AddressFromLine2 = SelectedAddress.Line2;
            Invoice.AddressFromName = SelectedAddress.Name;
            Invoice.AddressFromPhone = SelectedAddress.Phone;
            Invoice.AddressFromPostCode = SelectedAddress.PostCode;

            var data = new Dictionary<string, object>
            {
                { "Invoice", Invoice }
            };

            SelectedAddress = null;

            await Shell.Current.GoToAsync(nameof(AddressToSelector), data);
        }
    }
}