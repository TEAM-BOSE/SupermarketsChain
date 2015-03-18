namespace SupermarketsChain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Income
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int SupermarketId { get; set; }

        public virtual Supermarket Supermaket { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public decimal Quantity { get; set; }
    }
}
