using Web.Models;

namespace Web.DataModels
{
	public class CartDataModel
	{
		public List<OrderItem> OrderItems { get; set; }

		public User User { get; set; }
	}
}
