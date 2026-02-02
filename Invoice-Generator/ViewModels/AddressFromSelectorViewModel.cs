using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.Models;
using Invoice_Generator.Views;

namespace Invoice_Generator.ViewModels;

public partial class AddressFromSelectorViewModel(IRepository repository) : ObservableObject
{
    private AddressFromModel? address;

    [ObservableProperty] private ObservableCollection<AddressFromModel> addresses = [];

    [ObservableProperty] private AddressFromModel? selectedAddress;

    [RelayCommand]
    private async Task OnAddressChangedAsync()
    {
        if (SelectedAddress != null)
        {
            if (SelectedAddress.Id == Guid.Empty)
            {
                await Shell.Current.GoToAsync(nameof(AddressFromEdit));
            }
            else
            {
                InvoiceModel invoice = new()
                {
                    AddressFromEmail = SelectedAddress.Email,
                    AddressFromLine1 = SelectedAddress.Line1,
                    AddressFromLine2 = SelectedAddress.Line2,
                    AddressFromName = SelectedAddress.Name,
                    AddressFromPhone = SelectedAddress.Phone,
                    AddressFromPostCode = SelectedAddress.PostCode
                };

                var data = new Dictionary<string, object>
                {
                    { "Invoice", invoice }
                };

                await Shell.Current.GoToAsync(nameof(AddressToSelector), data);
            }
        }
    }

    [RelayCommand]
    private void LoadAddresses()
    {
        Addresses.Clear();
        var data = repository.GetAll<AddressFrom>().ToAddressFromModels();
        var emptyItem = new AddressFromModel
        {
            Id = Guid.Empty,
            Name = "Add New",
            Line1 = " ",
            PostCode = " "
        };
        data.Insert(0, emptyItem);
        Addresses = new ObservableCollection<AddressFromModel>(data);
    }

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
}