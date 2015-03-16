﻿namespace Data.MsSQL
{
    using System.Data.Entity;

    using SupermarketsChain.Models;

    public class MsSqlContext : DbContext
    {
        public MsSqlContext()
            : base("mssqlConStr")
        {
        }
        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Expense> Expenses { get; set; }
    }
}
