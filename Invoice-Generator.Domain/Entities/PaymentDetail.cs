namespace Invoice_Generator.Domain.Entities;

public class PaymentDetail : BaseEntity
{
    public string? Bank { get; set; }
    public string? AccountHolder { get; set; }
    public string? AccountNumber { get; set; }
    public string? SortCode { get; set; }
    public string? Reference { get; set; }
}