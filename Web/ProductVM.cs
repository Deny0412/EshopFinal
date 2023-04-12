using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models;

namespace Web
{
	public class ProductVM
	{
        public Product Product { get; set; }
        [ValidateNever]
        public List<Category> CategoryList { get; set; }
    }
}
