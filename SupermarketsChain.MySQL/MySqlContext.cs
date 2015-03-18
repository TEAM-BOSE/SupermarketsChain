namespace SupermarketsChain.MySQL
{
    using System.Data.Entity;

    using SupermarketsChain.Models;
    using MySql.Data.Entity;
    using Config;

    [DbConfigurationType(typeof(MultipleDbConfiguration))]
    public class MySqlContext : DbContext, ISupermarketDbContext
    {

        public MySqlContext()
            : base("mysqlConStr")
        {
            //  Database.SetInitializer(new DropCreateDatabaseAlways<MySqlContext>());
        }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Supermarket> Supermarkets { get; set; }

        public IDbSet<Income> Incomes { get; set; }

    }
}
