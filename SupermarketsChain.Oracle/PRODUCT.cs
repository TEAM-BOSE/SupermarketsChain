namespace SupermarketsChain.Oracle
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PRODUCTS")]
    public class PRODUCT
    {
        public PRODUCT()
        {

        }

        [Key]
        public int ID { get; set; }

        public string NAME { get; set; }

        public decimal PRICE { get; set; }

        public int VENDORID { get; set; }

        public int MEASUREID { get; set; }
    }
}
