using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : BaseController
    {
        private MyContext _context;

        public LoginController(MyContext context)
        {
            this._context = context;
        }

        public IActionResult Index( string next="")
        {            
            return View(new LoginModel() { Next =next});
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
                List<Admin> admins = _context.Admins.ToList();
                foreach (Admin item in admins)
                {
                    if (item.username == model.Admin.username && item.password == model.Admin.password)
                    {
                        this.HttpContext.Session.SetString("login", model.Admin.username);
                        if (string.IsNullOrWhiteSpace(model.Next))
                        {
                            model.Next = "Home:Index";
                        }
                        string[] parts = model.Next.Split(':');
                        return RedirectToAction(parts[1], parts[0]);
                    }
                }

            TempData["passwordfailed"] = "Password or username was incorrect";
            return View(model);
        }
        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("login");
            return RedirectToAction("Index","Login");
        }
    }
}
