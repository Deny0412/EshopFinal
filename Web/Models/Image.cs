using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int product_id { get; set; }
        [Required]
        public string path { get; set; }
        [Required]
        public int priority { get; set; }
    }
}
