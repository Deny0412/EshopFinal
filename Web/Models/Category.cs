using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table ("Categories")]
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
