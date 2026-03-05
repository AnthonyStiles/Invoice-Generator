using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Models;

namespace Invoice_Generator.ViewModels;

public partial class AddressToEditViewModel : ObservableObject
{
    private readonly IRepository _repository;

    [ObservableProperty] private AddressToModel address;

    public AddressToEditViewModel(IRepository repository)
    {
        Address = new AddressToModel
        {
            Id = Guid.NewGuid()
        };

        _repository = repository;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (!string.IsNullOrEmpty(Address.Name)
            && !string.IsNullOrEmpty(Address.Line1)
            && !string.IsNullOrEmpty(Address.Line2)
            && !string.IsNullOrEmpty(Address.PostCode))
        {
            _repository.Add(Address.ToAddressTo());
            await Shell.Current.GoToAsync("..");
        }
    }
}