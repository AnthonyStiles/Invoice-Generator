using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.Models;

namespace Invoice_Generator.ViewModels;

public partial class AddressToSelectorViewModel : ObservableObject
{
    private readonly IRepository _repository;

    public AddressToSelectorViewModel(IRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    private async Task OnAddressChangedAsync()
    {
        if (SelectedAddress != null && SelectedAddress.ID == Guid.Empty)
        {
            // await Shell.Current.GoToAsync(nameof(AddressFromEdit));
        }
    }

    [RelayCommand]
    private void LoadAddresses()
    {
        Addresses.Clear();
        var data = _repository.GetAll<AddressTo>().ToAddressToModels();
        var emptyItem = new AddressToModel()
        {
            ID = Guid.Empty,
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
            AddressFrom entity = _repository.GetByID<AddressFrom>(address.ID);
            _repository.Delete(entity);
            LoadAddresses();
        }
    }

    [ObservableProperty]
    public ObservableCollection<AddressToModel> addresses = [];

    [ObservableProperty]
    public AddressToModel? selectedAddress;
}
