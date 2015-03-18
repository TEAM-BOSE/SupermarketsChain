namespace SupermarketsChain.MsSQL.Migrations
{
    using SupermarketsChain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlContext>
    {
        private Random random = new Random(0);

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            var vendors = this.SeedVendors(context);
            var measures = this.SeedMeasures(context);
            this.SeedExpenses(context, vendors);
            this.SeedProdocts(context, vendors, measures);
        }

        private IList<Vendor> SeedVendors(MsSqlContext context)
        {
            var vendors = new List<Vendor>();

            for (int i = 0; i < 20; i++)
            {
                var name = "Vendor" + i;
                var vendor = new Vendor()
                {
                    Name = name
                };

                vendors.Add(vendor);
                context.Vendors.Add(vendor);
            }

            context.SaveChanges();
            return vendors;
        }

        private IList<Measure> SeedMeasures(MsSqlContext context)
        {
            var measureNames = new List<string>() { "liters", "pieces", "kilograms" };
            var measures = new List<Measure>(measureNames.Count());

            foreach (var name in measureNames)
            {
                var measure = new Measure()
                {
                    Name = name
                };

                measures.Add(measure);
                context.Measures.Add(measure);
            }

            context.SaveChanges();
            return measures;
        }

        private void SeedExpenses(MsSqlContext context, IList<Vendor> vendors)
        {
            var date = new DateTime(1999, 1, 1);

            for (int i = 0; i < 100; i++)
            {
                var value = this.random.Next(1000, 10000);
                var expense = new Expense()
                {
                    Date = date.AddMonths(i),
                    Vendor = vendors[this.random.Next(0, vendors.Count)],
                    Value = value
                };

                context.Expenses.Add(expense);
            }

            context.SaveChanges();
        }

        private void SeedProdocts(MsSqlContext context, IList<Vendor> vendors, IList<Measure> measures)
        {
            for (int i = 0; i < 1000; i++)
            {
                var product = new Product()
                {
                    Name = "Product" + i,
                    Measure = measures[this.random.Next(0, measures.Count)],
                    Vendor = vendors[this.random.Next(0, vendors.Count)],
                    Price = (decimal)(this.random.Next(1, 101) * this.random.Next(0, 1) * 10) / 100
                };

                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
