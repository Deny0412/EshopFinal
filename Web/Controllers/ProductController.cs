using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;
using Ubiety.Dns.Core.Records.NotUsed;
using Web.Models;
using Web.Utils;

namespace Web.Controllers
{
    //[Secured]
    public class ProductController : BaseController
    {
        private MyContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(MyContext context, IWebHostEnvironment hostEnvironment)
        {
            this._context = context;
            _hostEnvironment = hostEnvironment;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            List<Product> ProductList = _context.Products.ToList();            
            this.ViewBag.Images = _context.Images.ToList();
            return View(ProductList);
        }


        //GET
        public ActionResult Upsert(int? id)
        {
            Product product = new Product();
            if (id == null || id == 0)
            {
                return View(product);
            }
            else
            {
                Product selected = _context.Products.Find(id);
                List<Image> Images = _context.Images.ToList();
                List<Image> AdditionalImages=new List<Image>();
                foreach (var item in Images)
                {
                    if (item.product_id==selected.id && item.priority==2)
                    {
                        AdditionalImages.Add(item);
                    }
                }
                return View(selected);
            }
        }
        // POST: ProductController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Upsert(Product obj,IFormFile? file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //startImage
        //        string wwwRootPath = _hostEnvironment.WebRootPath;
        //        if (file != null)
        //        {
        //            string fileName = Guid.NewGuid().ToString();
        //            var uploads = Path.Combine(wwwRootPath, @"images\products");
        //            var extension = Path.GetExtension(file.FileName);

        //            if (obj.photoMain != null)
        //            {
        //                var oldImagePath = Path.Combine(wwwRootPath, obj.photoMain.TrimStart('\\'));
        //                if (System.IO.File.Exists(oldImagePath))
        //                {
        //                    System.IO.File.Delete(oldImagePath);
        //                }
        //            }

        //            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
        //            {
        //                file.CopyTo(fileStreams);
        //            }
        //            obj.photoMain = @"\images\products\" + fileName + extension;

        //        }
        //        //endImage
        //        if (obj.id == 0)
        //        {
        //            _context.Products.Add(obj);
        //        }
        //        else
        //        {
        //            _context.Products.Update(obj);
        //        }
                
        //        _context.SaveChanges();
        //        TempData["success"] = "Product created successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Product obj, IList<IFormFile>? listImages,IFormFile? mainPhoto)
        {
            if (ModelState.IsValid)
            {
                if (obj.id == 0)
                {
                    _context.Products.Add(obj);
                }
                else
                {
                    _context.Products.Update(obj);
                }
                _context.SaveChanges();
                //startImage
                //string wwwRootPath = _hostEnvironment.WebRootPath;
                using (ImageService service = new ImageService(_context, _hostEnvironment))
                {
                        service.Upload(obj, listImages);

                    
                        service.Upload(obj, mainPhoto,1);
                    
                };
                

                


                //endImage                    
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product selected = _context.Products.Find(id);
            if (selected == null)
            {
                return NotFound();
            }
            return View(selected);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int? id)
        {
            List<TotalProduct> variants = _context.Variants.ToList();
            List<Image> images=_context.Images.ToList();
            Product selected = _context.Products.Find(id);
            string wwwRootPath = _hostEnvironment.WebRootPath;
            foreach (Image item in images)
            {
                if (item.product_id==selected.id)
                {
                    string uploads = wwwRootPath + item.path;////////dodělat

                    System.IO.File.Delete(uploads);
                    _context.Images.Remove(item);
                    _context.SaveChanges();
                }
                
                if (selected == null)
                {
                    return NotFound();
                }
            }
            
            foreach (var item in variants)
            {
                if (item.product.id == id)
                {
                    _context.Variants.Remove(item);
                }
            }
            
            _context.SaveChanges();
            _context.Products.Remove(selected);
            _context.SaveChanges();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Variant(int? id)
        {
            Product selected = _context.Products.Find(id);
            return View(selected);
        }
        public IActionResult DelVariant(int? id)
        {
            TotalProduct selected = _context.Variants.Find(id);
            List<Product> products = _context.Products.ToList();
            List<Size> sizes = _context.Sizes.ToList();
            List<Color> colors = _context.Colors.ToList();
            this.ViewBag.Products = products;
            this.ViewBag.Sizes = sizes;
            this.ViewBag.Colors = colors;
            return View(selected);
        }
        [HttpPost, ActionName("DelVariant")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVariant(int? id)
        {
            TotalProduct selected = _context.Variants.Find(id);
            _context.Variants.Remove(selected);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult CreateVariant(int id)
        {
            Product selected = _context.Products.Find(id);
            TotalProduct selectedProduct = new TotalProduct();
            selectedProduct.product =selected;

            this.ViewBag.Colors = _context.Colors.ToList();
            this.ViewBag.Sizes = _context.Sizes.ToList();

            return View(selectedProduct);
        }

        [HttpPost, ActionName("CreateVariant")]
        public IActionResult CreateVariant(TotalProduct variant,int? productId)
        {
            
                Product product = _context.Products.Find(productId);
                variant.product = product;
                variant.id = 0;
                _context.Variants.Add(variant);
                _context.SaveChanges();
                TempData["success"] = "Variant created successfully";
                return RedirectToAction("Index","Product");
            return View(variant);
        }
    }
}
