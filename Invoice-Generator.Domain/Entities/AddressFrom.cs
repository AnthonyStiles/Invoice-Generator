namespace Invoice_Generator.Domain.Entities;

public class AddressFrom : BaseEntity
{
    public string? Name { get; set; }
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? PostCode { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}