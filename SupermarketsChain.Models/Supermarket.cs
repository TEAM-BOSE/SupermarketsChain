namespace SupermarketsChain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Supermarket
    {
        private ICollection<Income> incomes;

        public Supermarket()
        {
            this.incomes = new HashSet<Income>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Income> Incomes
        {
            get { return this.incomes; }
            set { this.incomes = value; }
        }
    }
}
