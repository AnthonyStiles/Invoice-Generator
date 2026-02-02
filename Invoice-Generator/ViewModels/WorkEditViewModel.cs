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
            WorkList.Add(Work);
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
            Invoice.Work = WorkList.ToList();

            Dictionary<string, object> data = new()
            {
                { "Invoice", Invoice }
            };

            await Shell.Current.GoToAsync(nameof(AdditionalDetails), data);
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("Invoice") && query["Invoice"] is InvoiceModel invoice)
        {
            Invoice = invoice;
            
            if (invoice.Work?.Count > 0)
            {
                WorkList = new ObservableCollection<WorkModel>(invoice.Work);
            }
        }
    }

    [ObservableProperty] private ObservableCollection<WorkModel> workList = [];

    [ObservableProperty] private WorkModel work;

    private InvoiceModel? Invoice { get; set; }
}