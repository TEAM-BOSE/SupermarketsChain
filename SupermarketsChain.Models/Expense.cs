namespace SupermarketsChain.Models
{
    using System;
    public class Expense
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public DateTime Date { get; set; }
    }
}
