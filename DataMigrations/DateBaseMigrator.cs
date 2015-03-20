namespace DataMigrations
{
    using Config;
    using SupermarketsChain.Models;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System;

    public class DateBaseMigrator : IDateBaseMigrator
    {

        private ISupermarketDbContext fromDataContext;
        private ISupermarketDbContext toDataContext;

        public delegate void ChangedEventHandler(object sender, EventArgs e);
        private int changes = 0;

        public DateBaseMigrator(ISupermarketDbContext fromDataContext, ISupermarketDbContext toDataContext)
        {
            this.fromDataContext = fromDataContext;
            this.toDataContext = toDataContext;
        }

        public event ChangedEventHandler Changed;

        // Invoke the Changed event; called whenever list changes
        protected virtual void OnChanged(string status, int rowsAdd)
        {
            if (Changed != null)
                Changed(this, new MigrationReport(status, rowsAdd));
        }

        public void ExcuteMigration()
        {
            var currentChanges = 0;
            this.changes += this.MigrateSupermarkets();
            OnChanged("Supermarkets datebase is transfered", this.changes - currentChanges);
            currentChanges = this.changes;

            this.changes += this.MigrateMeasures();
            OnChanged("Measure datebase is transfered", this.changes - currentChanges);
            currentChanges = this.changes;

            this.changes += this.MigrateVendors();
            OnChanged("Vendors datebase is transfered", this.changes - currentChanges);
            currentChanges = this.changes;

            this.changes += this.MigrateExpenses();
            OnChanged("Expenses datebase is transfered", this.changes - currentChanges);
            currentChanges = this.changes;

            this.changes += this.MigrateProducts();
            OnChanged("Products datebase is transfered", this.changes - currentChanges);
            currentChanges = this.changes;

            this.changes += this.MigrateIncomes();
            OnChanged("Incomes datebase is transfered", this.changes - currentChanges);
            currentChanges = this.changes;

            OnChanged("Transfer is finished", this.changes);
        }

        private int MigrateMeasures()
        {
            int? lastId = null;
            var measures = new List<Measure>();

            if (toDataContext.Measures.Any())
            {
                lastId = this.toDataContext.Measures.Max(x => x.Id);
                measures = this.fromDataContext.Measures.Where(x => x.Id > lastId).ToList();
            }
            else
            {
                measures = this.fromDataContext.Measures.ToList();
            }

            foreach (var measure in measures)
            {
                var newMeasure = new Measure()
                {
                    Name = measure.Name
                };
                this.toDataContext.Measures.Add(newMeasure);
            }

            return this.toDataContext.SaveChanges();
        }

        private int MigrateVendors()
        {
            int? lastId = null;
            var vendors = new List<Vendor>();

            if (toDataContext.Vendors.Any())
            {
                lastId = this.toDataContext.Vendors.Max(x => x.Id);
                vendors = this.fromDataContext.Vendors.Where(x => x.Id > lastId).ToList();
            }
            else
            {
                vendors = this.fromDataContext.Vendors.ToList();
            }

            foreach (var vendor in vendors)
            {
                var newVendor = new Vendor()
                {
                    Name = vendor.Name
                };

                this.toDataContext.Vendors.Add(newVendor);
            }

            return this.toDataContext.SaveChanges();
        }

        private int MigrateExpenses()
        {
            int? lastId = null;
            var expenses = new List<Expense>();

            if (toDataContext.Expenses.Any())
            {
                lastId = this.toDataContext.Expenses.Max(x => x.Id);
                expenses = this.fromDataContext.Expenses.Where(x => x.Id > lastId).ToList();
            }
            else
            {
                expenses = this.fromDataContext.Expenses.ToList();
            }

            foreach (var expense in expenses)
            {
                var newExpense = new Expense()
                {
                    Date = expense.Date,
                    Value = expense.Value,
                    VendorId = expense.VendorId
                };

                this.toDataContext.Expenses.Add(newExpense);
            }

            return this.toDataContext.SaveChanges();
        }

        private int MigrateProducts()
        {
            int? lastId = null;
            var products = new List<Product>();

            if (toDataContext.Products.Any())
            {
                lastId = this.toDataContext.Products.Max(x => x.Id);
                products = this.fromDataContext.Products.Where(x => x.Id > lastId).ToList();
            }
            else
            {
                products = this.fromDataContext.Products.ToList();
            }


            foreach (var product in products)
            {
                var newProduct = new Product()
                {
                    MeasureId = product.MeasureId,
                    Name = product.Name,
                    Price = product.Price,
                    VendorId = product.VendorId
                };

                this.toDataContext.Products.Add(newProduct);
            }

            return this.toDataContext.SaveChanges();
        }

        private int MigrateSupermarkets()
        {
            int? lastId = null;
            var supermarkets = new List<Supermarket>();

            if (toDataContext.Supermarkets.Any())
            {
                lastId = this.toDataContext.Supermarkets.Max(x => x.Id);
                supermarkets = this.fromDataContext.Supermarkets.Where(x => x.Id > lastId).ToList();
            }
            else
            {
                supermarkets = this.fromDataContext.Supermarkets.ToList();
            }

            foreach (var supermarket in supermarkets)
            {
                var newSupermarket = new Supermarket()
                {
                    Name = supermarket.Name
                };

                this.toDataContext.Supermarkets.Add(newSupermarket);
            }

            return this.toDataContext.SaveChanges();
        }
        private int MigrateIncomes()
        {
            int? lastId = null;
            var incomes = new List<Income>();

            if (toDataContext.Incomes.Any())
            {
                lastId = this.toDataContext.Incomes.Max(x => x.Id);
                incomes = this.fromDataContext.Incomes.Where(x => x.Id > lastId).ToList();
            }
            else
            {
                incomes = this.fromDataContext.Incomes.ToList();
            }

            foreach (var income in incomes)
            {
                var newIncome = new Income()
                {
                    Date = income.Date,
                    ProductId = income.ProductId,
                    Quantity = income.Quantity,
                    SupermarketId = income.SupermarketId
                };

                this.toDataContext.Incomes.Add(newIncome);
            }

            return this.toDataContext.SaveChanges();
        }
    }
}
