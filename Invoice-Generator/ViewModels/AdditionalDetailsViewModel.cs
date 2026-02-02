using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Domain.Interfaces;
using Invoice_Generator.Models;

namespace Invoice_Generator.ViewModels;

[QueryProperty("Invoice", "Invoice")]
public partial class AdditionalDetailsViewModel : ObservableObject
{
    private readonly IRepository _repository;
    private readonly IInvoiceGenerator _invoiceGenerator;

    public AdditionalDetailsViewModel(IRepository repository, IInvoiceGenerator invoiceGenerator)
    {
        _repository = repository;
        _invoiceGenerator = invoiceGenerator;
        InvoiceDate = DateTime.Now.Date;
    }

    [RelayCommand]
    private async Task FinishAsync()
    {
        Invoice.Invoiced = InvoiceDate;
        Invoice newInvoice = Invoice.ToInvoice();
        _repository.Add(newInvoice);

        string filePath = Path.Combine(FileSystem.AppDataDirectory, "test.pdf");
        _invoiceGenerator.GenerateInvoice(newInvoice, filePath);
        
        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Print PDF",
            File = new ShareFile(filePath)
        });
        
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    [ObservableProperty] private DateTime invoiceDate;

    [ObservableProperty] private InvoiceModel invoice;
}