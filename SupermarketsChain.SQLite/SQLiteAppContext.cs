namespace SupermarketsChain.SQLite
{
    using System.Data.Entity;

    using SupermarketsChain.Models;
    using Config;

    [DbConfigurationType(typeof(MultipleDbConfiguration))]
    public class SQLiteAppContext : DbContext
    {
        public SQLiteAppContext()
            : base("sqliteConStr")
        {
        }

        public IDbSet<Tax> Taxes { get; set; }
    }
}
