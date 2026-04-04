using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Models;

namespace Invoice_Generator.ViewModels.Invoice;

public partial class AddressFromEditViewModel : ObservableObject
{
    private readonly IRepository _repository;

    [ObservableProperty] public AddressFromModel address;

    public AddressFromEditViewModel(IRepository repository)
    {
        Address = new AddressFromModel
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
            && !string.IsNullOrEmpty(Address.PostCode)
            && !string.IsNullOrEmpty(Address.Email)
            && !string.IsNullOrEmpty(Address.Phone))
        {
            _repository.Add(Address.ToAddressFrom());
            await Shell.Current.GoToAsync("..");
        }
    }
}