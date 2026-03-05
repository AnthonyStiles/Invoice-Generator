using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Helpers;
using Invoice_Generator.Models;
using Invoice_Generator.Views;

namespace Invoice_Generator.ViewModels;

[QueryProperty("Invoice", "Invoice")]
public partial class WorkEditViewModel : ObservableObject
{
    [ObservableProperty] public InvoiceModel invoice;

    [ObservableProperty] private WorkModel work;

    public WorkEditViewModel()
    {
        Work = new WorkModel
        {
            Completed = DateTime.Now
        };
    }

    [RelayCommand]
    private void AddWork()
    {
        if (!string.IsNullOrWhiteSpace(Work.Description)
            && Work.Hours > 0
            && Work.Amount > 0)
        {
            WorkGroupHelper.GroupWorkItem(Invoice.Work, Work);

            Work = new WorkModel
            {
                Completed = DateTime.Now
            };
        }
    }

    [RelayCommand]
    private async Task NavigateNextAsync()
    {
        if (Invoice != null)
        {
            Dictionary<string, object> data = new()
            {
                { "Invoice", Invoice }
            };

            await Shell.Current.GoToAsync(nameof(PaymentDetailSelector), data);
        }
    }

    [RelayCommand]
    private void DeleteWork(WorkModel deletedWork)
    {
        var workGroup = Invoice.Work.FirstOrDefault(workItem => deletedWork.Completed.Date == workItem.Date.Date);

        if (workGroup != null)
        {
            workGroup.Work.Remove(deletedWork);

            if (workGroup.Work.Count == 0) Invoice.Work.Remove(workGroup);
        }
    }
}