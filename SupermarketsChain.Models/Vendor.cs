namespace SupermarketsChain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Vendor
    {
        private ICollection<Product> products;
        private ICollection<Expense> expenses;

        public Vendor()
        {
            products = new HashSet<Product>();
            expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
        public virtual ICollection<Expense> Expenses
        {
            get { return this.expenses; }
            set { this.expenses = value; }
        }
    }
}
