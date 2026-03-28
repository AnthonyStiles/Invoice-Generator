namespace Invoice_Generator.Models;

public class PaymentDetailModel
{
    public string? AccountHolder { get; set; }
    public string? AccountNumber { get; set; }
    public string? Bank { get; set; }
    public Guid Id { get; set; }
    public string? SortCode { get; set; }
}