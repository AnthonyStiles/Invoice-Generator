using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.Models;
using Invoice_Generator.Views;

namespace Invoice_Generator.ViewModels;

[QueryProperty("Invoice", "Invoice")]
public partial class AddressToSelectorViewModel(IRepository repository) : ObservableObject
{
    [RelayCommand]
    private async Task OnAddressChangedAsync()
    {
        if (SelectedAddress != null)
        {
            if (SelectedAddress.Id == Guid.Empty)
            {
                await Shell.Current.GoToAsync(nameof(AddressToEdit));
            }
            else
            {
                Invoice.AddressToLine1 = SelectedAddress.Line1;
                Invoice.AddressToLine2 = SelectedAddress.Line2;
                Invoice.AddressToName = SelectedAddress.Name;
                Invoice.AddressToPostCode = SelectedAddress.PostCode;
                
                var data = new Dictionary<string, object>
                {
                    { "Invoice", Invoice }
                };
                
                await Shell.Current.GoToAsync(nameof(WorkEdit), data);
            }
        }
    }

    [RelayCommand]
    private void LoadAddresses()
    {
        Addresses.Clear();
        var data = repository.GetAll<AddressTo>().ToAddressToModels();
        var emptyItem = new AddressToModel
        {
            Id = Guid.Empty,
            Name = "Add New",
            Line1 = " ",
            PostCode = " "
        };
        data.Insert(0, emptyItem);
        Addresses = new ObservableCollection<AddressToModel>(data);
    }

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

    [ObservableProperty] public ObservableCollection<AddressToModel> addresses = [];

    [ObservableProperty] public AddressToModel? selectedAddress;

    [ObservableProperty] public InvoiceModel invoice;
}