using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Secured]
    public class AdminController : Controller
    {
        MyContext _context;
        public AdminController(MyContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.ToList();
            List<User> users = _context.Users.ToList();
            foreach (User user in users)
            {
                foreach (Order order in orders)
                {
                    if (order.user.id == user.id)
                    {
                        order.user = user;
                    }
                }
            }

            return View(orders);
        }
        //[HttpPost]
        public IActionResult SetOrderDone(int? id)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.id == id);
            order.status = "Hotovo";
            _context.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteOrder(int? id)
        {
            Order order=_context.Orders.Find(id);
            //foreach (var item in _context.OrderItems)
            //{

            //}
            //_context.OrderItems.Where(x=>x.Order.id==order.id)
            _context.Users.Remove(order.user);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
