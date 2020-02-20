using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNetMovie.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
    }
}