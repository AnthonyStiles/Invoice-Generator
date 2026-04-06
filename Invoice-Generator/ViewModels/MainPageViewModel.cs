using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Helpers;
using Invoice_Generator.Models;
using Invoice_Generator.Views.Invoice;
using Invoice_Generator.Views.Popups;

namespace Invoice_Generator.ViewModels;

public partial class MainPageViewModel(IRepository repository, IInvoiceGenerator invoiceGenerator) : ObservableObject
{
    [ObservableProperty]
    private string instruction;

    [ObservableProperty]
    private ObservableCollection<InvoiceModel> invoiceList;

    [ObservableProperty]
    private InvoiceModel selectedInvoice;

    [RelayCommand]
    private void DeleteInvoice(InvoiceModel deletedInvoice)
    {
        if (InvoiceList.Contains(deletedInvoice))
        {
            var entity = repository.GetByID<Domain.Entities.Invoice>(deletedInvoice.Id);
            if (entity != null)
            {
                repository.Delete(entity);
            }

            PageLoad();
        }
    }

    [RelayCommand]
    private async Task InvoiceChangedAsync()
    {
        var filePath = Path.Combine(FileSystem.AppDataDirectory, SelectedInvoice.Number);
        invoiceGenerator.GenerateInvoice(SelectedInvoice.ToInvoice(), filePath);

        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Print PDF",
            File = new ShareFile(filePath)
        });

        SelectedInvoice = null;
    }

    [RelayCommand]
    private async Task OpenNewInvoiceAsync()
    {
        var termsVersion = Preferences.Get(TermsHelper.TermsPreferencesKey, 0);

        if (termsVersion < TermsHelper.TermsVersion)
        {
            var popupResult = await Shell.Current.ShowPopupAsync<bool>(new TermsAndConditionsPrompt());

            if (popupResult.WasDismissedByTappingOutsideOfPopup || !popupResult.Result)
            {
                return;
            }

            Preferences.Set(TermsHelper.TermsPreferencesKey, TermsHelper.TermsVersion);
        }

        await Shell.Current.GoToAsync(nameof(AddressFromSelector));
    }

    [RelayCommand]
    private async Task OpenSettingsAsync()
    {
        await Shell.Current.GoToAsync(nameof(Settings));
    }

    [RelayCommand]
    private void PageLoad()
    {
        var invoices = repository.GetAll<Domain.Entities.Invoice>();
        InvoiceList = new ObservableCollection<InvoiceModel>(invoices.ToInvoiceModels());

        Instruction = invoices.Count > 0
            ? "Select an invoice to generate it again."
            : "Create an invoice and it will be shown here.";
    }
}