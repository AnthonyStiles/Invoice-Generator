using System.Collections.ObjectModel;
using Invoice_Generator.Models;
using Invoice_Generator.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Adapters;

namespace Invoice_Generator.ViewModels;

public partial class AddressFromSelectorViewModel : ObservableObject
{
  private readonly IRepository _repository;

  public AddressFromModel? address;

  public AddressFromSelectorViewModel(IRepository repository)
  {
    _repository = repository;
  }

  [RelayCommand]
  private async Task OnAddressChangedAsync()
  {
    if (SelectedAddress != null && SelectedAddress.ID == Guid.Empty)
    {
      await Shell.Current.GoToAsync(nameof(AddressFromEdit));
    }
    else if (SelectedAddress != null && SelectedAddress.ID != Guid.Empty)
    {
      InvoiceModel invoice = new()
      {
        AddressFrom = SelectedAddress.ID
      };

      Dictionary<string, object> data = new Dictionary<string, object>()
      {
        { "Invoice", invoice }
      };

      await Shell.Current.GoToAsync(nameof(AddressToSelector), data);
    }
  }

  [RelayCommand]
  private void LoadAddresses()
  {
    Addresses.Clear();
    var data = _repository.GetAll<AddressFrom>().ToAddressFromModels();
    var emptyItem = new AddressFromModel()
    {
      ID = Guid.Empty,
      Name = "Add New",
      Line1 = " ",
      PostCode = " "
    };
    data.Insert(0, emptyItem);
    Addresses = new ObservableCollection<AddressFromModel>(data);
  }

  [RelayCommand]
  private void DeleteAddress(AddressFromModel address)
  {
    if (Addresses.Contains(address))
    {
      AddressFrom entity = _repository.GetByID<AddressFrom>(address.ID);
      _repository.Delete(entity);
      LoadAddresses();
    }
  }

  [ObservableProperty]
  public ObservableCollection<AddressFromModel> addresses = [];

  [ObservableProperty]
  public AddressFromModel? selectedAddress;
}