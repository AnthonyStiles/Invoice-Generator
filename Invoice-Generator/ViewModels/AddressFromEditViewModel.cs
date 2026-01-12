using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.Models;

namespace Invoice_Generator.ViewModels;

public partial class AddressFromEditViewModel : ObservableObject
{
    private readonly IRepository _repository;
    
    [ObservableProperty]
    public AddressFromModel address;

    public AddressFromEditViewModel(IRepository repository)
    {
        Address = new AddressFromModel()
        {
            ID = Guid.NewGuid()
        };
        
        _repository = repository;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        _repository.Add(Address.ToAddressFrom());
        await Shell.Current.GoToAsync("..");
    }
}
