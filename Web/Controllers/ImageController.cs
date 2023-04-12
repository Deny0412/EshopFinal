using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Web.Models;

namespace Web.Controllers
{
    [Secured]
    public class ImageController : Controller
    {
        MyContext _context=new MyContext();
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageController(MyContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> products=_context.Products.ToList();
            List<Image> images = _context.Images.ToList();
            this.ViewBag.Products = products;
            return View(images);
        }

        
        public IActionResult Delete(int? id,int? productID)
        {
            //this.ViewBag.productID = this.TempData["backtosite"];
            if (id==null)
            {
                return NotFound();
            }
            Image selected = _context.Images.Find(id);
            //_context.Images.Remove(deleted);
            //return View("Upsert", "Product", ViewBag.BackToSite);
            this.ViewBag.ProductID = productID;
            return View(selected);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteImage(int id,int? productID)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            
            Image deleted= _context.Images.Find(id);
            string delete = wwwRootPath + deleted.path;
            System.IO.File.Delete(delete);
            _context.Images.Remove(deleted);
            _context.SaveChanges();
            //return RedirectToAction("Upsert", "Product", this.ViewBag.site);
            return RedirectToAction("Upsert", "Product", new { id = productID } );
        }
    }
}
