namespace SupermarketsChain.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;

    using Config;
    using SupermarketsChain.Models.BindingModels.Reports;
    using SupermarketsChain.SQLite;

    public class Requester
    {
        private ISupermarketDbContext context;
        private SQLiteAppContext sqliteContext;

        public Requester(ISupermarketDbContext supermarketContext, SQLiteAppContext sqliteContext)
        {
            this.context = supermarketContext;
            this.sqliteContext = sqliteContext;
        }

        public IList<VendorsFinResultReport> RequestVendorsFinResultReportData()
        {
            var taxes = this.sqliteContext.Taxes.ToList();

            var vendorsByTax = this.context.Vendors.Include(x => x.Products).ToList()
               .Select(v => new
               {
                   Name = v.Name,
                   Tax = v.Products
                        .Sum(x => x.Incomes
                            .Sum(y =>
                                y.Quantity
                                * y.Product.Price
                                * (decimal)taxes.Where(t => t.ProductId == x.Id)
                                                .Select(t => t.Value).FirstOrDefault()))
               }).ToList();


            var vendors = this.context.Vendors
                .Select(v => new
                {
                    VendorName = v.Name,
                    Incomes = v.Products.Sum(pr => pr.Incomes.Sum(y => y.Quantity * y.Product.Price)),
                    Expense = v.Expenses.Sum(ex => ex.Value)
                }).ToList();


            var vendorsData = new List<VendorsFinResultReport>();
            foreach (var ven in vendors)
            {
                var tax = vendorsByTax
                    .Where(v => v.Name == ven.VendorName)
                    .Select(v => v.Tax).FirstOrDefault();
                vendorsData.Add(new VendorsFinResultReport()
                {
                    VendorName = ven.VendorName,
                    Expenses = ven.Expense,
                    Incomes = ven.Incomes,
                    Taxes = tax
                });

            }

            return vendorsData;
        }
    }
}
