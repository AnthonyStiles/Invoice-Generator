using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;
using Invoice_Generator.Views;

namespace Invoice_Generator.ViewModels;

[QueryProperty("Invoice", "Invoice")]
public partial class PaymentDetailSelectorViewModel(IRepository repository) : ObservableObject
{
    [RelayCommand]
    private async Task OnAddNewDetailsAsync()
    {
        await Shell.Current.GoToAsync(nameof(PaymentDetailEdit));
    }

    [RelayCommand]
    private async Task OnPaymentDetailChangedAsync()
    {
        if (SelectedPaymentDetail != null)
        {
            Invoice.Bank = SelectedPaymentDetail.Bank;
            Invoice.AccountHolder = SelectedPaymentDetail.AccountHolder;
            Invoice.SortCode = SelectedPaymentDetail.SortCode;
            Invoice.AccountNumber = SelectedPaymentDetail.AccountNumber;

            var data = new Dictionary<string, object>
            {
                { "Invoice", Invoice }
            };

            await Shell.Current.GoToAsync(nameof(InvoiceDate), data);
        }
    }

    [RelayCommand]
    private void LoadPaymentDetails()
    {
        PaymentDetails.Clear();
        var data = repository.GetAll<PaymentDetail>().ToPaymentDetailModels();
        PaymentDetails = new ObservableCollection<PaymentDetailModel>(data);
    }

    [RelayCommand]
    private void DeletePaymentDetail(PaymentDetailModel paymentDetail)
    {
        if (PaymentDetails.Contains(paymentDetail))
        {
            var entity = repository.GetByID<PaymentDetail>(paymentDetail.Id);
            repository.Delete<PaymentDetail>(entity);
            LoadPaymentDetails();
        }
    }

    [RelayCommand]
    private async Task NavigateNextAsync()
    {
        Dictionary<string, object> data = new()
        {
            { "Invoice", Invoice }
        };

        await Shell.Current.GoToAsync(nameof(InvoiceDate), data);
    }

    [ObservableProperty] public ObservableCollection<PaymentDetailModel> paymentDetails = [];

    [ObservableProperty] public PaymentDetailModel? selectedPaymentDetail;

    [ObservableProperty] public InvoiceModel invoice;
}