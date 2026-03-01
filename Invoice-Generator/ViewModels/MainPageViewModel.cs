using System.Collections.ObjectModel;
using Invoice_Generator.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Interfaces;

namespace Invoice_Generator.ViewModels;

public partial class MainPageViewModel(IRepository repository, IInvoiceGenerator invoiceGenerator) : ObservableObject
{
    [RelayCommand]
    private async Task OpenNewInvoiceAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddressFromSelector));
    }

    [RelayCommand]
    private async Task InvoiceChangedAsync()
    {
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "test.pdf");
        invoiceGenerator.GenerateInvoice(SelectedInvoice.ToInvoice(), filePath);

        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Print PDF",
            File = new ShareFile(filePath)
        });
    }

    [RelayCommand]
    private void PageLoad()
    {
        var invoices = repository.GetAll<Invoice>();
        InvoiceList = new ObservableCollection<InvoiceModel>(invoices.ToInvoiceModels());

        Instruction = invoices.Count > 0
            ? "Select one of the previously created invoices generate it again."
            : "Create an invoice for it to appear here.";
    }

    [RelayCommand]
    private void DeleteInvoice(InvoiceModel deletedInvoice)
    {
        if (InvoiceList.Contains(deletedInvoice))
        {
            var entity = repository.GetByID<Invoice>(deletedInvoice.Id);
            if (entity != null) repository.Delete(entity);
            PageLoad();
        }
    }

    [ObservableProperty] private InvoiceModel selectedInvoice;

    [ObservableProperty] private ObservableCollection<InvoiceModel> invoiceList;

    [ObservableProperty] private string instruction;
}