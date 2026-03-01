namespace Invoice_Generator.Domain;

public static class InvoiceNumberFormatter
{
    public static string Format(int invoiceNumber, DateTime date)
    {
        return $"{date.Year}-{invoiceNumber}";
    }
}