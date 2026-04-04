using Invoice_Generator.ViewModels.Invoice;

namespace Invoice_Generator.Views.Invoice;

public partial class WorkEdit : ContentPage
{
    public WorkEdit()
    {
        InitializeComponent();
        BindingContext = new WorkEditViewModel();
    }
}