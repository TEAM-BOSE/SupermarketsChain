//This class is only for sqlite database
namespace SupermarketsChain.Models
{
    public class Tax
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public double Value { get; set; }
    }
}
