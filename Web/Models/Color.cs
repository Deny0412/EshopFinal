using Castle.Components.DictionaryAdapter;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Colors")]
    public class Color
    {
        public int id { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public string hex { get; set; }
    }
}
