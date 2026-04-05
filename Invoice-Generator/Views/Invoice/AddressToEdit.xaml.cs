using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels.Invoice;

namespace Invoice_Generator.Views.Invoice;

public partial class AddressToEdit : ContentPage
{
    public AddressToEdit(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new AddressToEditViewModel(repository);
    }
}