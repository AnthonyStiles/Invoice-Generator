using Invoice_Generator.ViewModels;

namespace Invoice_Generator.Views;

public partial class WorkEdit : ContentPage
{
    public WorkEdit()
    {
        InitializeComponent();
        BindingContext = new WorkEditViewModel();
    }
}