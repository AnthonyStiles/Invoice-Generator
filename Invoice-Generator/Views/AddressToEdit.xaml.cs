using Invoice_Generator.ViewModels;
using Invoice_Generator.Domain.Interfaces;

namespace Invoice_Generator.Views;

public partial class AddressToEdit : ContentPage
{
    public AddressToEdit(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new AddressToEditViewModel(repository);
    }
}