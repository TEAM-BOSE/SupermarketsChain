namespace Config
{
    using System.Data.Entity;

    using SupermarketsChain.Models;

    public interface ISupermarketDbContext
    {
        IDbSet<Vendor> Vendors { get; set; }

        IDbSet<Measure> Measures { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Expense> Expenses { get; set; }

        IDbSet<Supermarket> Supermarkets { get; set; }

        IDbSet<Income> Incomes { get; set; }

        int SaveChanges();
    }
}
