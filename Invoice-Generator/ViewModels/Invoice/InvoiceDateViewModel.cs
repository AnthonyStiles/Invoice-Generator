using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Data;
using Invoice_Generator.Application.Handlers;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Helpers;
using Invoice_Generator.Models;

namespace Invoice_Generator.ViewModels.Invoice;

[QueryProperty("Invoice", "Invoice")]
public partial class InvoiceDateViewModel : ObservableObject
{
    private readonly ICreateInvoiceHandler _createInvoiceHandler;
    private readonly IInvoiceGenerator _invoiceGenerator;
    private readonly IRepository _repository;

    [ObservableProperty]
    private InvoiceModel invoice;

    [ObservableProperty]
    private DateTime invoiceDate;

    public InvoiceDateViewModel(IRepository repository, IInvoiceGenerator invoiceGenerator,
        ICreateInvoiceHandler createInvoiceHandler)
    {
        _repository = repository;
        _invoiceGenerator = invoiceGenerator;
        _createInvoiceHandler = createInvoiceHandler;
        InvoiceDate = DateTime.Now.Date;
    }

    [RelayCommand]
    private async Task FinishAsync()
    {
        SentrySdk.CaptureMessage("Invoice generated.");
        
        Invoice.Invoiced = InvoiceDate;

        var newInvoice = Invoice.ToInvoice();
        var invoiceNumber = InvoiceNumberHelper.GetInvoiceNumber();

        _createInvoiceHandler.Handle(new CreateInvoiceData { Invoice = newInvoice, InvoiceNumber = invoiceNumber });

        var filePath = Path.Combine(FileSystem.AppDataDirectory, $"{newInvoice.Number}_{DateTime.Now:HH:mm:ss}");
        _invoiceGenerator.GenerateInvoice(newInvoice, filePath);

        InvoiceNumberHelper.IncrementInvoiceNumber();

        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Invoice",
            File = new ShareFile(filePath)
        });

        File.Delete(filePath);

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}