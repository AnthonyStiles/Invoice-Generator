using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Domain.Interfaces;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;

namespace Invoice_Generator.Infrastructure.InvoiceGeneration;

public class MigraDocInvoiceGenerator : IInvoiceGenerator
{
    public void GenerateInvoice(Invoice invoice, string outputDirectory)
    {
        if (Capabilities.Build.IsCoreBuild)
        {
            GlobalFontSettings.FontResolver = new FailsafeFontResolver();
        }
        
        var document = new Document
        {
            Info =
            {
                Title = "Invoice"
            }
        };

        ApplyStyle(document);

        Section section = document.AddSection();

        Paragraph title = section.AddParagraph("INVOICE");
        title.Format.Font.Size = 20;
        title.Format.Font.Bold = true;
        title.Format.SpaceAfter = "1cm";
        
        Table addressTable = section.AddTable();
        addressTable.AddColumn("8cm");
        addressTable.AddColumn("8cm");

        Row row = addressTable.AddRow();
        Paragraph fromAddressParagraph = row.Cells[0].AddParagraph();
        fromAddressParagraph.AddFormattedText("From:\n", TextFormat.Bold);
        fromAddressParagraph.AddText($"{invoice.AddressFromName}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromLine1}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromLine2}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromPostCode}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromEmail}\n");
        fromAddressParagraph.AddText($"{invoice.AddressFromPhone}\n");
        
        Paragraph toAddressParagraph = row.Cells[1].AddParagraph();
        toAddressParagraph.AddFormattedText("To:\n", TextFormat.Bold);
        toAddressParagraph.AddText($"{invoice.AddressToName}\n");
        toAddressParagraph.AddText($"{invoice.AddressToLine1}\n");
        toAddressParagraph.AddText($"{invoice.AddressToLine2}\n");
        toAddressParagraph.AddText($"{invoice.AddressToPostCode}\n");
        
        //not sure about this
        section.AddParagraph("\n");
        
        Paragraph details = section.AddParagraph();
        details.AddText("Invoice Number: \n");
        details.AddText($"Invoice Date: {invoice.Invoiced:d} \n");
        details.Format.SpaceAfter = "1cm";
        
        Table table = section.AddTable();
        table.Borders.Width = 0.75;
        table.Borders.Color = Colors.Black;

        Column column = table.AddColumn("3cm"); // Date
        column.Format.Alignment = ParagraphAlignment.Left;
            
        column = table.AddColumn("10cm"); // Description
        column.Format.Alignment = ParagraphAlignment.Left;

        column = table.AddColumn("3cm"); // Amount
        column.Format.Alignment = ParagraphAlignment.Right;
        
        Row headerRow = table.AddRow();
        headerRow.Shading.Color = Colors.LightGray;
        headerRow.Cells[0].AddParagraph("Date").Format.Font.Bold = true;
        headerRow.Cells[1].AddParagraph("Description").Format.Font.Bold = true;
        headerRow.Cells[2].AddParagraph("Amount").Format.Font.Bold = true;

        var workByDate = invoice.Work.GroupBy(work => work.Completed.Date);

        foreach (var workGroup in workByDate)
        {
            Row workRow = table.AddRow();
            workRow.Cells[0].AddParagraph(workGroup.Key.ToString("d"));
            
            Paragraph descriptionParagraph = workRow.Cells[1].AddParagraph();
            Paragraph amountParagraph = workRow.Cells[2].AddParagraph();

            for (int i = 0; i < workGroup.Count(); i++)
            {
                var workList = workGroup.ToList();
                if (i == workGroup.Count() - 1)
                {
                    descriptionParagraph.AddText(workList[i].Description);
                    amountParagraph.AddText(workList[i].Amount.ToString("C"));
                }
                else
                {
                    descriptionParagraph.AddText($"{workList[i].Description}\n");
                    amountParagraph.AddText($"{workList[i].Amount:C}\n");
                }
            }
        }
        
        PdfDocumentRenderer pdfDocumentRenderer = new PdfDocumentRenderer();
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