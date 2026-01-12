namespace Invoice_Generator.Domain.Entities;

public class AddressTo : BaseEntity
{
    public string? Name { get; set; }
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? PostCode { get; set; }
}