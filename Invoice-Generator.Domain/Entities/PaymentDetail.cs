namespace Invoice_Generator.Domain.Entities;

public class PaymentDetail : BaseEntity
{
    public string? AccountHolder { get; set; }
    public string? AccountNumber { get; set; }
    public string? Bank { get; set; }
    public string? Reference { get; set; }
    public string? SortCode { get; set; }
}