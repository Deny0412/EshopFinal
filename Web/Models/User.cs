using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Users")]
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int telephone { get; set; }        
        //public string datumZalozeniUctu { get; set; }
        public string address1 { get; set; }
    }
}
