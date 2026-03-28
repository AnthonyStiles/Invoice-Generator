namespace Invoice_Generator.Models;

public class AddressToModel
{
    public Guid Id { get; set; }
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Name { get; set; }
    public string? PostCode { get; set; }
}