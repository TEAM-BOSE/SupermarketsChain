namespace SupermarketsChain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Measure
    {
        private ICollection<Product> products;

        public Measure()
        {
            products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
