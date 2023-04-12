using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("TotalProduct")]
    public class TotalProduct
    {
        public int id { get; set; } 


        [ForeignKey("product_id")]
        public virtual Product product {get; set;}

        public int color_id {get; set;}

        public int size_id {get; set;}
    }
}
