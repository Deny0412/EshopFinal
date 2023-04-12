using Microsoft.AspNetCore.Mvc;
using Web.DataModels;
using Web.Models;

namespace Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly MyContext _context;
        public OrderController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(CartDataModel model)
        {
            List<OrderItem> items = GetCart(_context);

            items.ForEach(o => o.unitPrice = o.Variant.product.price);

            Order order = new Order()
            {
                OrderItems = items,
                user = model.User,
                status = "zpracovávání"
            };
            
            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
