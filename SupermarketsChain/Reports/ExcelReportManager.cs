namespace ExcelReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Diagnostics;
    using System.Drawing;

    using OfficeOpenXml;

    using SupermarketsChain.Models;
    using System.Data;
    using SupermarketsChain.Models.BindingModels.Reports;

    public static class ExcelReportManager
    {
        public static void GenerateVendorsFinResultReport(IList<VendorsFinResultReport> reportData)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                var wb = p.Workbook.Worksheets.Add("text");

                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Cells[2, 2].Value = "Vendors";
                ws.Cells[2, 3].Value = "Incomes";
                ws.Cells[2, 4].Value = "Expenses";
                ws.Cells[2, 5].Value = "Total Taxes";
                ws.Cells[2, 6].Value = "Financial Result";

                var header = ws.Cells[2, 2, 2, 6];
                header.Style.Font.Bold = true;
                header.Style.Font.Bold = true;
                header.Style.Font.Color.SetColor(Color.Azure);
                header.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                header.Style.Fill.BackgroundColor.SetColor(Color.Black);

                for (int i = 0; i < reportData.Count; i++)
                {
                    ws.Cells[i + 3, 2].Value = reportData[i].VendorName;
                    ws.Cells[i + 3, 3].Value = reportData[i].Incomes;
                    ws.Cells[i + 3, 4].Value = reportData[i].Expenses;
                    ws.Cells[i + 3, 5].Value = reportData[i].Taxes;
                    ws.Cells[i + 3, 6].Value = reportData[i].FinResult;
                }

                var footer = ws.Cells[reportData.Count + 3, 2, reportData.Count + 3, 6];
                footer.Style.Font.Bold = true;
                footer.Style.Font.Color.SetColor(Color.Azure);
                footer.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                footer.Style.Fill.BackgroundColor.SetColor(Color.Black);



                //Generate A File with Random name
                Byte[] bin = p.GetAsByteArray();
                string file = "TaxReport.xlsx";//Guid.NewGuid().ToString() + ".xlsx";
                File.WriteAllBytes(file, bin);

                //These lines will open it in Excel
                ProcessStartInfo pi = new ProcessStartInfo(file);
                Process.Start(pi);
            }
        }
    }
}
