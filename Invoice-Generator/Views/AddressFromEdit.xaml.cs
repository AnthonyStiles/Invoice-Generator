using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

public partial class AddressFromEdit : ContentPage
{
    public AddressFromEdit(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new AddressFromEditViewModel(repository);
    }
}