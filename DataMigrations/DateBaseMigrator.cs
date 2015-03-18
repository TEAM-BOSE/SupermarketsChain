namespace DataMigrations
{
    using Config;
    using SupermarketsChain.Models;
    using System.Linq;

    public class DateBaseMigrator : IDateBaseMigrator
    {
        private ISupermarketDbContext fromDataContext;
        private ISupermarketDbContext toDataContext;
        public int changes = 0;

        public DateBaseMigrator(ISupermarketDbContext fromDataContext, ISupermarketDbContext toDataContext)
        {
            this.fromDataContext = fromDataContext;
            this.toDataContext = toDataContext;
        }

        public void ExcuteMigration()
        {
            this.changes += this.MigrateMeasures();
            this.changes += this.MigrateVendors();
            this.changes += this.MigrateExpenses();
            this.changes += this.MigrateProducts();
        }

        private int MigrateMeasures()
        {
            var lastId = this.toDataContext.Measures.Max(x => x.Id);
            var measures = this.fromDataContext.Measures.Where(x => x.Id > lastId).ToList();

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
            var lastId = this.toDataContext.Vendors.Max(x => x.Id);
            var vendors = this.fromDataContext.Vendors.Where(x => x.Id > lastId).ToList();

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
            var lastId = this.toDataContext.Expenses.Max(x => x.Id);
            var expenses = this.fromDataContext.Expenses.Where(x => x.Id > lastId).ToList();

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
            var lastId = this.toDataContext.Products.Max(x => x.Id);
            var products = this.fromDataContext.Products.Where(x => x.Id > lastId).ToList();

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
    }
}
