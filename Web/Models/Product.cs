using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Web.Models
{
    [Table ("Products")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string desc { get; set; }
        public string SKU { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public int category_id { get; set; }

    }
}
