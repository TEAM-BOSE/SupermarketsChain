namespace SupermarketsChain.Models.BindingModels.Reports
{
    public class VendorsFinResultReport
    {
        public string VendorName { get; set; }

        public decimal Incomes { get; set; }

        public decimal Expenses { get; set; }

        public decimal Taxes { get; set; }

        public decimal FinResult
        {
            get
            {
                return this.Incomes - this.Expenses - this.Taxes;
            }
        }
    }
}
