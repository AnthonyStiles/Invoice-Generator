namespace Invoice_Generator.Helpers;

internal static class InvoiceNumberHelper
{
    private const string InvoiceNumberKey = "InvoiceNumber";

    internal static int GetInvoiceNumber()
    {
        if (!Preferences.ContainsKey(InvoiceNumberKey))
        {
            Preferences.Set(InvoiceNumberKey, 1);
        }

        return Preferences.Get(InvoiceNumberKey, 1);
    }

    internal static void IncrementInvoiceNumber()
    {
        var invoiceNumber = GetInvoiceNumber();

        if (invoiceNumber < int.MaxValue)
        {
            Preferences.Set(InvoiceNumberKey, GetInvoiceNumber() + 1);
        }
    }

    internal static void SetInvoiceNumber(int invoiceNumber)
    {
        Preferences.Set(InvoiceNumberKey, invoiceNumber);
    }
}