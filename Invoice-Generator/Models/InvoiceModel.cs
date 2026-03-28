using System.Collections.ObjectModel;

namespace Invoice_Generator.Models;

public class InvoiceModel
{
    public string? AccountHolder { get; set; }
    public string? AccountNumber { get; set; }
    public string? AddressFromEmail { get; set; }
    public string? AddressFromLine1 { get; set; }
    public string? AddressFromLine2 { get; set; }
    public string? AddressFromName { get; set; }
    public string? AddressFromPhone { get; set; }
    public string? AddressFromPostCode { get; set; }
    public string? AddressToLine1 { get; set; }
    public string? AddressToLine2 { get; set; }
    public string? AddressToName { get; set; }
    public string? AddressToPostCode { get; set; }
    public string? Bank { get; set; }
    public Guid Id { get; set; }
    public DateTime Invoiced { get; set; }
    public string? Number { get; set; }
    public string? SortCode { get; set; }
    public decimal Total { get; set; }
    public ObservableCollection<WorkGroupModel> Work { get; set; } = [];
}