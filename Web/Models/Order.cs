using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Orders")]
    public class Order
    {
        public int id { get; set; }


        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        public string status { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
