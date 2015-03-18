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
            var supermarkets = this.SeedSupermarkets(context);
            var products = this.SeedProducts(context, vendors, measures);
            this.SeedExpenses(context, vendors);
            this.SeedIncomes(context, products, supermarkets);
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
        private IList<Supermarket> SeedSupermarkets(MsSqlContext context)
        {
            var supermarkets = new List<Supermarket>();

            for (int i = 0; i < 20; i++)
            {
                var name = "Supermarket" + i;
                var supermarket = new Supermarket()
                {
                    Name = name
                };

                supermarkets.Add(supermarket);
                context.Supermarkets.Add(supermarket);
            }

            context.SaveChanges();
            return supermarkets;
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

            for (int i = 0; i < 500; i++)
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

        private void SeedIncomes(MsSqlContext context, IList<Product> products, IList<Supermarket> supermarkets)
        {
            var date = new DateTime(1999, 1, 1);

            for (int i = 0; i < 500; i++)
            {
                var value = this.random.Next(1000, 10000);
                var income = new Income()
                {
                    Date = date.AddMonths(i),
                    Product = products[this.random.Next(0, products.Count)],
                    Quantity = this.random.Next(1, 100),
                    Supermaket = supermarkets[this.random.Next(0, supermarkets.Count)]
                };

                context.Incomes.Add(income);
            }

            context.SaveChanges();
        }

        private IList<Product> SeedProducts(MsSqlContext context, IList<Vendor> vendors, IList<Measure> measures)
        {
            var products = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                var price = (this.random.Next(1, 101) * this.random.Next(1, 10)) / 100.00m;
                var product = new Product()
                {
                    Name = "Product" + i,
                    Measure = measures[this.random.Next(0, measures.Count)],
                    Vendor = vendors[this.random.Next(0, vendors.Count)],
                    Price = price
                };
                products.Add(product);
                context.Products.Add(product);
            }

            context.SaveChanges();
            return products;
        }
    }
}
