using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Models;
using Invoice_Generator.Views;

namespace Invoice_Generator.ViewModels;

public partial class WorkEditViewModel : ObservableObject, IQueryAttributable
{
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
            GroupWork(Work);
            Invoice?.Work.Add(Work);
            
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
        var workGroup = WorkList.FirstOrDefault(workItem => deletedWork.Completed.Date == workItem.Date.Date);

        if (workGroup != null)
        {
            workGroup.Work.Remove(deletedWork);
            Invoice?.Work.Remove(deletedWork);

            if (workGroup.Work.Count == 0)
            {
                WorkList.Remove(workGroup);
            }
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("Invoice") && query["Invoice"] is InvoiceModel invoice)
        {
            Invoice = invoice;
            
            if (invoice.Work?.Count > 0)
            {
                WorkList = [];
                foreach (var workItem in invoice.Work)
                {
                    GroupWork(workItem);
                }
            }
        }
    }

    private void GroupWork(WorkModel workItem)
    {
        var workGroup = WorkList.FirstOrDefault(group => group.Date.Date == workItem.Completed.Date);
        if (workGroup != null)
        {
            workGroup.Work.Add(workItem);
        }
        else
        {
            WorkList.Add(new()
            {
                Date = workItem.Completed.Date, 
                Work = [ workItem ]
            });
        }
    }

    [ObservableProperty] private ObservableCollection<WorkGroupModel> workList = [];

    [ObservableProperty] private WorkModel work;

    private InvoiceModel? Invoice { get; set; }
}