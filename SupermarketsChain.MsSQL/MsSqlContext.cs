namespace SupermarketsChain.MsSQL
{
    using System.Data.Entity;

    using SupermarketsChain.Models;
    using Config;
    using SupermarketsChain.MsSQL.Migrations;

    [DbConfigurationType(typeof(MultipleDbConfiguration))]
    public class MsSqlContext : DbContext, ISupermarketDbContext
    {
        public MsSqlContext()
            : base("mssqlConStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlContext, Configuration>());
        }
        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Supermarket> Supermarkets { get; set; }

        public IDbSet<Income> Incomes { get; set; }
    }
}
