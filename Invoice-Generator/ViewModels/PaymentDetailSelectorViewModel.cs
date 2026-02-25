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
    private async Task OnPaymentDetailChangedAsync()
    {
        if (SelectedPaymentDetail != null)
        {
            if (SelectedPaymentDetail.Id == Guid.Empty)
            {
                await Shell.Current.GoToAsync(nameof(PaymentDetailEdit));
            }
            else
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
    }

    [RelayCommand]
    private void LoadPaymentDetails()
    {
        PaymentDetails.Clear();
        var data = repository.GetAll<PaymentDetail>().ToPaymentDetailModels();
        var emptyItem = new PaymentDetailModel
        {
            Id = Guid.Empty,
            Bank = "Add New",
            AccountHolder = " "
        };
        data.Insert(0, emptyItem);
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