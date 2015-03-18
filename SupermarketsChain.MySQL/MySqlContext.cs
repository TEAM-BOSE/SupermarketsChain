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
        }
        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Expense> Expenses { get; set; }
    }
}
