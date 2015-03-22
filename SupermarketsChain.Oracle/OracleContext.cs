namespace SupermarketsChain.Oracle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class OracleContext : DbContext
    {
        public OracleContext()
            : base("name=OracleContext")
        {

        }

        public DbSet<PRODUCT> PRODUCTS { get; set; }
        public DbSet<VENDOR> VENDORS { get; set; }

        public DbSet<MEASURE> MEASURES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SUPERMARKETSCHAIN");

        }
    }
}
