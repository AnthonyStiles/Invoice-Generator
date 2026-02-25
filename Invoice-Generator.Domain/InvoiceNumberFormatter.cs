namespace Invoice_Generator.Domain;

public static class InvoiceNumberFormatter
{
    public static string Format(int invoiceNumber, DateTime date) => $"{date.Year}-{invoiceNumber}";
}