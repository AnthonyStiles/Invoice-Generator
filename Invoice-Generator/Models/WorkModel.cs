namespace Invoice_Generator.Models;

public class WorkModel
{
    public Guid Id { get; set; }
    public DateTime Completed { get; set; }
    public decimal? Hours { get; set; }
    public decimal? Amount { get; set; }
    public string? Description { get; set; }
}