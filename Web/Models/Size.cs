using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Sizes")]
    public class Size
    {

        public int id { get; set; }
        public int size { get; set; }
    }
}
