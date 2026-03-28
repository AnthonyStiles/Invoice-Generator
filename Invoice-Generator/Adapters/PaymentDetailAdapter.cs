using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;

namespace Invoice_Generator.Adapters;

internal static class PaymentDetailAdapter
{
    internal static PaymentDetail ToPaymentDetail(this PaymentDetailModel detail)
    {
        return new PaymentDetail
        {
            Id = detail.Id,
            Bank = detail.Bank,
            AccountHolder = detail.AccountHolder,
            AccountNumber = detail.AccountNumber,
            SortCode = detail.SortCode
        };
    }

    private static PaymentDetailModel ToPaymentDetailModel(this PaymentDetail detail)
    {
        return new PaymentDetailModel
        {
            Id = detail.Id,
            Bank = detail.Bank,
            AccountHolder = detail.AccountHolder,
            AccountNumber = detail.AccountNumber,
            SortCode = detail.SortCode
        };
    }

    internal static List<PaymentDetailModel> ToPaymentDetailModels(this List<PaymentDetail> paymentDetails)
    {
        return paymentDetails.ConvertAll(detail => detail.ToPaymentDetailModel());
    }
}