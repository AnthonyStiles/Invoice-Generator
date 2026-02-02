using Invoice_Generator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Domain.Interfaces;

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
        _repository.Add(Address.ToAddressTo());
        await Shell.Current.GoToAsync("..");
    }
}