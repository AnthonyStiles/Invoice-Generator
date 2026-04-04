using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Invoice_Generator.Adapters;
using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Models;

namespace Invoice_Generator.ViewModels.Invoice;

public partial class PaymentDetailEditViewModel : ObservableObject
{
    private readonly IRepository _repository;

    [ObservableProperty] private PaymentDetailModel paymentDetail;

    public PaymentDetailEditViewModel(IRepository repository)
    {
        PaymentDetail = new PaymentDetailModel
        {
            Id = Guid.NewGuid()
        };

        _repository = repository;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (!string.IsNullOrEmpty(PaymentDetail.Bank)
            && !string.IsNullOrEmpty(PaymentDetail.AccountHolder)
            && !string.IsNullOrEmpty(PaymentDetail.SortCode)
            && !string.IsNullOrEmpty(PaymentDetail.AccountNumber))
        {
            _repository.Add(PaymentDetail.ToPaymentDetail());
            await Shell.Current.GoToAsync("..");
        }
    }
}