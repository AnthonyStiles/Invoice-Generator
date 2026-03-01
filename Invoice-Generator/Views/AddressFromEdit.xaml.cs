using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

public partial class AddressFromEdit : ContentPage
{
    public AddressFromEdit(IRepository repository)
    {
        InitializeComponent();
        BindingContext = new AddressFromEditViewModel(repository);
    }

    private void OnEntryLoaded(object sender, EventArgs e)
    {
        NameEntry.Focus();
    }
}