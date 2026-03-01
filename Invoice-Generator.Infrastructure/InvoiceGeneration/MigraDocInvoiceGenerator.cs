using Invoice_Generator.Application.Interfaces;
using Invoice_Generator.Domain.Entities;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;

namespace Invoice_Generator.Infrastructure.InvoiceGeneration;

public class MigraDocInvoiceGenerator : IInvoiceGenerator
{
    private static void GenerateAddressSection(Section section, Invoice invoice)
    {
        var addressTable = section.AddTable();
        addressTable.AddColumn("8cm");
        var fromColumn = addressTable.AddColumn("8cm");
        fromColumn.Format.Alignment = ParagraphAlignment.Right;

        var row = addressTable.AddRow();
        var toAddressParagraph = row.Cells[0].AddParagraph();
        toAddressParagraph.AddFormattedText("Billed To:\n", TextFormat.Bold);
        toAddressParagraph.AddText($"{invoice.AddressToName}\n");
        toAddressParagraph.AddText($"{invoice.AddressToLine1}\n");
        toAddressParagraph.AddText($"{invoice.AddressToLine2}\n");
        toAddressParagraph.AddText($"{invoice.AddressToPostCode}\n");

        var fromAddressParagraph = row.Cells[1].AddParagraph();
        fromAddressParagraph.AddFormattedText("Invoiced By:\n", TextFormat.Bold);
        fromAddressParagraph.AddText($"{invoice.AddressFromName}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromLine1}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromLine2}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromPostCode}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromEmail}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromPhone}\n");
    }

    private void GenerateInvoiceDetailsSection(Section section, Invoice invoice)
    {
        var details = section.AddParagraph();
        details.AddText($"Invoice Number: {invoice.Number}\n");
        details.AddText($"Invoice Date: {invoice.Invoiced:d} \n");
    }

    private void GenerateWorkSection(Section section, Invoice invoice)
    {
        var table = section.AddTable();
        table.Borders.Visible = false;

        table.AddColumn("3cm"); // Date
        table.AddColumn("7cm"); // Description
        table.AddColumn("3cm"); // Hours
        table.AddColumn("3cm"); // Amount

        var headerRow = table.AddRow();
        headerRow.Shading.Color = Colors.LightGray;

        var dateHeader = headerRow.Cells[0].AddParagraph("Date");
        dateHeader.Format.Font.Bold = true;
        dateHeader.Format.SpaceBefore = "0.25cm";
        dateHeader.Format.SpaceAfter = "0.25cm";

        var descriptionHeader = headerRow.Cells[1].AddParagraph("Description");
        descriptionHeader.Format.Font.Bold = true;
        descriptionHeader.Format.SpaceBefore = "0.25cm";
        descriptionHeader.Format.SpaceAfter = "0.25cm";

        var hoursHeader = headerRow.Cells[2].AddParagraph("Hours");
        hoursHeader.Format.Font.Bold = true;
        hoursHeader.Format.SpaceBefore = "0.25cm";
        hoursHeader.Format.SpaceAfter = "0.25cm";

        var amountHeader = headerRow.Cells[3].AddParagraph("Amount");
        amountHeader.Format.Font.Bold = true;
        amountHeader.Format.SpaceBefore = "0.25cm";
        amountHeader.Format.SpaceAfter = "0.25cm";

        var workByDate = invoice.Work.GroupBy(work => work.Completed.Date);

        foreach (var workGroup in workByDate)
        {
            var workRow = table.AddRow();
            workRow.Cells[0].AddParagraph(workGroup.Key.ToString("d"));

            var description = workRow.Cells[1].AddParagraph();
            description.Format.SpaceAfter = "0.5cm";

            var hours = workRow.Cells[2].AddParagraph();
            hours.Format.SpaceAfter = "0.5cm";

            var amount = workRow.Cells[3].AddParagraph();
            amount.Format.SpaceAfter = "0.5cm";

            for (var i = 0; i < workGroup.Count(); i++)
            {
                var workList = workGroup.ToList();
                if (i == workGroup.Count() - 1)
                {
                    description.AddText(workList[i].Description);
                    hours.AddText(workList[i].Hours.ToString("F2"));
                    amount.AddText(workList[i].Amount.ToString("C"));
                }
                else
                {
                    description.AddText($"{workList[i].Description}\n");
                    hours.AddText($"{workList[i].Hours:F2}\n");
                    amount.AddText($"{workList[i].Amount:C}\n");
                }
            }
        }

        var totalRow = table.AddRow();

        var totalLabelColumn = totalRow.Cells[2];
        totalLabelColumn.Borders.Top.Width = Unit.FromPoint(0.5);
        totalLabelColumn.Borders.Top.Color = Colors.LightGray;

        var totalLabel = totalLabelColumn.AddParagraph("Total:");
        totalLabel.Format.Font.Bold = true;

        var totalValueColumn = totalRow.Cells[3];
        totalValueColumn.Borders.Top.Width = Unit.FromPoint(0.5);
        totalValueColumn.Borders.Top.Color = Colors.LightGray;

        totalValueColumn.AddParagraph(invoice.Total.ToString("C")).Format.Font.Bold = true;
    }

    private void GenerateTotalSection(Section section, Invoice invoice)
    {
        var totals = section.AddParagraph();
        totals.AddText($"Total to be paid: {invoice.Total:C}");
        totals.Format.Font.Bold = true;
        totals.Format.Font.Size = 16;
    }

    private void GeneratePaymentDetailsSection(Section section, Invoice invoice)
    {
        var paymentDetailsTable = section.AddTable();
        paymentDetailsTable.AddColumn("4cm");
        paymentDetailsTable.AddColumn("4cm");

        var row = paymentDetailsTable.AddRow();

        var labels = row.Cells[0].AddParagraph();
        labels.AddFormattedText("Payment Details:\n", TextFormat.Bold);
        labels.AddText("Bank:\n");
        labels.AddText("Account Holder:\n");
        labels.AddText("Sort Code:\n");
        labels.AddText("Account Number\n");

        var values = row.Cells[1].AddParagraph();
        values.AddText("\n");
        values.AddText($"{invoice.Bank}\n");
        values.AddText($"{invoice.AccountHolder}\n");
        values.AddText($"{invoice.SortCode}\n");
        values.AddText($"{invoice.AccountNumber}\n");
    }

    public void GenerateInvoice(Invoice invoice, string outputDirectory)
    {
        if (Capabilities.Build.IsCoreBuild) GlobalFontSettings.FontResolver = new FailsafeFontResolver();

        var document = new Document
        {
            Info =
            {
                Title = "Invoice"
            }
        };

        ApplyStyle(document);

        var baseSection = document.AddSection();

        var title = baseSection.AddParagraph("INVOICE");
        title.Format.Font.Size = 20;
        title.Format.Font.Bold = true;
        baseSection.AddParagraph("\n\n");

        GenerateAddressSection(baseSection, invoice);
        baseSection.AddParagraph("\n\n");

        GenerateInvoiceDetailsSection(baseSection, invoice);
        baseSection.AddParagraph("\n\n");

        GenerateWorkSection(baseSection, invoice);
        baseSection.AddParagraph("\n\n");

        if (!string.IsNullOrEmpty(invoice.Bank))
        {
            GeneratePaymentDetailsSection(baseSection, invoice);
            baseSection.AddParagraph("\n\n");
        }

        GenerateTotalSection(baseSection, invoice);

        var pdfDocumentRenderer = new PdfDocumentRenderer();
        pdfDocumentRenderer.Document = document;
        pdfDocumentRenderer.RenderDocument();
        pdfDocumentRenderer.PdfDocument.Save(outputDirectory);
    }

    private void ApplyStyle(Document document)
    {
        var style = document.Styles["Normal"];
        if (style != null)
        {
            style.Font.Name = "Verdana";
            style.Font.Size = 10;
        }
    }
}