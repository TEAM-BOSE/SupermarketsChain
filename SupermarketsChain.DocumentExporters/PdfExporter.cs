namespace SupermarketsChain.DocumentExporters
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Xml.Linq;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using SupermarketsChain.Models;
    using SupermarketsChain.MsSQL;

    public class PdfExporter
    {
        public static void InitiateExport()
        {
            FileStream fs = new FileStream("test.pdf", FileMode.Create, FileAccess.Write, FileShare.None);

            Document doc = new Document();

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            PdfPTable tableReport = new PdfPTable(5);

            PdfPCell cell = new PdfPCell(new Phrase("Products in the Supermarkets Chain"));

            cell.Colspan = 5;
            cell.HorizontalAlignment = 1;
            tableReport.AddCell(cell);

            var context = new MsSqlContext();

            var students = context.Products;
            doc.Open();
            foreach (var s in students)
            {
                tableReport.AddCell(s.Id.ToString());
                tableReport.AddCell(s.Name);
                tableReport.AddCell(s.Price.ToString());
                tableReport.AddCell(s.MeasureId.ToString());
                tableReport.AddCell(s.VendorId.ToString());
            }
            doc.Add(tableReport);
            doc.Close();
        }
    }
}
