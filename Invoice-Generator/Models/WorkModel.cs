namespace Invoice_Generator.Models;

public class WorkModel
{
    public decimal? Amount { get; set; }
    public DateTime Completed { get; set; }
    public string? Description { get; set; }
    public decimal? Hours { get; set; }
    public Guid Id { get; set; }
}