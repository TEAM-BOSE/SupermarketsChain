﻿namespace SupermarketsChain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        private ICollection<Income> incomes;

        public Product()
        {
            incomes = new HashSet<Income>();
        }
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public virtual ICollection<Income> Incomes
        {
            get { return this.incomes; }
            set { this.incomes = value; }
        }
    }
}
