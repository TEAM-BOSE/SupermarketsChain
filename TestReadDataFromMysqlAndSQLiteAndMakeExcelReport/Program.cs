namespace TestReadDataFromMysqlAndSQLiteAndMakeExcelReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Data.Entity;
    using System.Data.SQLite;

    using SupermarketsChain.Models;
    using SupermarketsChain.SQLite;
    using SupermarketsChain.MySQL;
    using SupermarketsChain.MsSQL;
   


    class Program
    {
        static void Main(string[] args)
        {
            var sqliteContext = new SQLiteAppContext();
            var mySqlContext = new MySqlContext();
            //   var mySqlContext = new MsSqlContext();


            //var TaxByVendor = new Dictionary<string, decimal>();
            //var taxes = sqliteContext.Taxes.ToList();

            //var vendorsByTax = mySqlContext.Vendors.Include(x => x.Products).ToList()
            //   .Select(v => new
            //   {
            //       Name = v.Name,
            //       Tax = v.Products
            //       .Sum(x => x.Incomes.Sum(y => y.Quantity * y.Product.Price
            //           * (decimal)taxes.Where(t => t.ProductId == x.Id).Select(t => t.Value).FirstOrDefault()))
            //   }).ToList();


            //var vendors = mySqlContext.Vendors
            //    .Select(v => new
            //    {
            //        VendorName = v.Name,
            //        Incomes = v.Products.Sum(x => x.Incomes.Sum(y => y.Quantity * y.Product.Price)),
            //        Expense = v.Expenses.Sum(x => x.Value)
            //    }).ToList();


            //var vendorsData = new List<VendorsFinResultReport>();
            //foreach (var ven in vendors)
            //{
            //    var tax = vendorsByTax
            //        .Where(v => v.Name == ven.VendorName)
            //        .Select(v => v.Tax).FirstOrDefault();
            //    vendorsData.Add(new VendorsFinResultReport()
            //    {
            //        VendorName = ven.VendorName,
            //        Expenses = ven.Expense,
            //        Incomes = ven.Incomes,
            //        Taxes = tax
            //    });

            //}

            //Console.WriteLine(mySqlContext.Expenses.Sum(x => x.Value));
            //Console.WriteLine(mySqlContext.Incomes.Sum(x => x.Quantity * x.Product.Price));

            //ExcelReportManager.GenerateVendorsFinResultReport(vendorsData);
        }
    }
}
