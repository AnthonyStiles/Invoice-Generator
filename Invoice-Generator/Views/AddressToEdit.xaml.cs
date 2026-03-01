using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

public partial class AddressToEdit : ContentPage
{
    public AddressToEdit(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new AddressToEditViewModel(repository);
    }

    private void OnEntryLoaded(object sender, EventArgs e)
    {
        NameEntry.Focus();
    }
}