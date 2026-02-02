namespace Invoice_Generator.Domain.Entities;

public class Invoice : BaseEntity
{
    public string? AddressFromName { get; set; }
    public string? AddressFromLine1 { get; set; }
    public string? AddressFromLine2 { get; set; }
    public string? AddressFromPostCode { get; set; }
    public string? AddressFromEmail { get; set; }
    public string? AddressFromPhone { get; set; }
    public string? AddressToName { get; set; }
    public string? AddressToLine1 { get; set; }
    public string? AddressToLine2 { get; set; }
    public string? AddressToPostCode { get; set; }
    public ICollection<Work> Work { get; set; } = new List<Work>();
    public DateTime Invoiced { get; set; }
}