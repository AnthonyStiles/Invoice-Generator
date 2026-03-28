using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;
using Invoice_Generator.Views;

namespace Invoice_Generator.ViewModels;

[QueryProperty("Invoice", "Invoice")]
public partial class AddressToSelectorViewModel(IRepository repository) : ObservableObject
{
    [ObservableProperty] public ObservableCollection<AddressToModel> addresses = [];

    [ObservableProperty] public InvoiceModel invoice;

    [ObservableProperty] public AddressToModel? selectedAddress;

    [RelayCommand]
    private void DeleteAddress(AddressToModel address)
    {
        if (Addresses.Contains(address))
        {
            var entity = repository.GetByID<AddressTo>(address.Id);
            repository.Delete<AddressTo>(entity);
            LoadAddresses();
        }
    }

    [RelayCommand]
    private void LoadAddresses()
    {
        Addresses.Clear();
        var data = repository.GetAll<AddressTo>().ToAddressToModels();
        Addresses = new ObservableCollection<AddressToModel>(data);
    }

    [RelayCommand]
    private async Task OnAddNewDetailsAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddressToEdit));
    }

    [RelayCommand]
    private async Task OnAddressChangedAsync()
    {
        if (SelectedAddress != null)
        {
            Invoice.AddressToLine1 = SelectedAddress.Line1;
            Invoice.AddressToLine2 = SelectedAddress.Line2;
            Invoice.AddressToName = SelectedAddress.Name;
            Invoice.AddressToPostCode = SelectedAddress.PostCode;

            var data = new Dictionary<string, object>
            {
                { "Invoice", Invoice }
            };

            SelectedAddress = null;

            await Shell.Current.GoToAsync(nameof(WorkEdit), data);
        }
    }
}