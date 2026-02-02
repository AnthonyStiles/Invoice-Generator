namespace Invoice_Generator.Models;

public class AddressFromModel
{
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Name { get; set; }
    public string? PostCode { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public Guid Id { get; set; }
}