using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.DataModels;
using Web.Models;

namespace Web.Controllers
{
    public class CartController : BaseController
    {
        MyContext _context;
        
        public CartController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<OrderItem> cart = this.GetCart(_context);
            List<Image> images = _context.Images.ToList();
            this.ViewBag.Images = images;
            List<Color> colors = _context.Colors.ToList();
            this.ViewBag.Colors = colors;
            List<Size> sizes = _context.Sizes.ToList();
            this.ViewBag.Sizes = sizes;

            return View(new CartDataModel()
            {
                OrderItems = cart,
                User = new User()
            });
        }

        public IActionResult Add(int variantID)
        {
            //totalProduct variantWantToAdd= _context.Variants.Find(variantID);
            

            //totalProduct variant = variants.Where(v => v. == colorId && v.size_id == sizeId).FirstOrDefault();

            List<OrderItemDataModel> data = this.ViewBag.Cart;

            //OrderItemDataModel orderItem = data.Where(x => x.totalProductId == variant.id).FirstOrDefault();
            //orderItem.quantity++;
            //OrderItemDataModel zkouska = new OrderItemDataModel();
            data.Add(new OrderItemDataModel()
            {
                totalProductId = variantID,
                quantity = 1
            });

            Save(data);

            return Redirect("Index");
        }
        public IActionResult Edit(int index, int quantity)
        {
            List<OrderItemDataModel> cart = this.ViewBag.Cart;

            if (index < cart.Count() && index >= 0)
            {
                cart[index].quantity = quantity <= 0 ? 1 : quantity;
                Save(cart);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int index)
        {
            List<OrderItemDataModel> cart = this.ViewBag.Cart;

            if (index < cart.Count() && index >= 0)
            {
                cart.RemoveAt(index);
                Save(cart);
            }

            return RedirectToAction("Index");
        }
        private void Save(List<OrderItemDataModel> cart)
        {
            this.HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
    }
}
