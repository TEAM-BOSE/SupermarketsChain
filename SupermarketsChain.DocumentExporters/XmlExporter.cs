namespace SupermarketsChain.DocumentExporters
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Xml.Linq;

    using SupermarketsChain.Models;
    using SupermarketsChain.MsSQL;

    public class XmlExporter
    {
        public static void InitiateExport()
        {
            var context = new MsSqlContext();

            var products = context.Products;

            XElement StudentsXml = new XElement("Products",
                               (from tbl in products
                                select new
                                {
                                    tbl.Id,
                                    tbl.Name,
                                    tbl.Price,
                                    tbl.MeasureId,
                                    tbl.VendorId
                                }).ToList().Select(
                               x => new XElement("Product",
                                    new XAttribute("Id", x.Id),
                                    new XAttribute("Name", x.Name),
                                    new XAttribute("Price", x.Price),
                                    new XAttribute("MeasureId", x.MeasureId),
                                    new XAttribute("VendorId", x.VendorId)

            )));

            string fullPath = System.IO.Path.GetFullPath(".\\");

            string path = "";

            for (int i = 0; i < fullPath.Length - 10; i++)
            {
                path += fullPath[i];
            }
            path += "XML";

            StudentsXml.Save(path + @"\test.xml");

            string str = File.ReadAllText(path + @"\test.xml");
            Console.WriteLine(str);
        }
    }
}
