using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.DataModels;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        MyContext _context=new MyContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> products8= _context.Products.Take(8).ToList();
            List<Image> images = _context.Images.ToList();
            this.ViewBag.Images = images;
            
            return View(products8);
        }

        public IActionResult Detail(int? id, int? variantID)
        {
            Product selected = _context.Products.Find(id);
            List<Category> categories = _context.Categories.ToList();
            List<Image> images= _context.Images.ToList();
            List<TotalProduct> variants=_context.Variants.Where(x=>x.product.id==selected.id).ToList();
            List<Color> colors=_context.Colors.ToList();
            List<Size> sizes=_context.Sizes.ToList();
            this.ViewBag.Categories= categories;
            this.ViewBag.Sizes= sizes;
            this.ViewBag.Colors= colors;
            this.ViewBag.Variants= variants;
            this.ViewBag.Images= images;


            List<Image> image3 = _context.Images.Where(i => i.product_id == id && i.priority==2).Take(3).ToList();
            this.ViewBag.Images3= image3;
            List<Product> product4 = _context.Products.Take(4).ToList();
            this.ViewBag.Products4 = product4;
            TotalProduct selectedVariant = variantID == null 
                ? variants.FirstOrDefault() 
                : variants.Where(v => v.id == variantID).First();

            ProductDataModel model= new ProductDataModel(selected,selectedVariant);

            model.product = selected;

            return View(model);
        }
        public IActionResult Demand()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}