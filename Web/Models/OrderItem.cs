using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("OrdersItems")]
    public class OrderItem
    {
        public int id { get; set; }

        [ForeignKey("order_id")]
        public virtual Order Order { get; set; }

        [ForeignKey("totalProduct_id")]
        public virtual TotalProduct Variant { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }

    }
}
