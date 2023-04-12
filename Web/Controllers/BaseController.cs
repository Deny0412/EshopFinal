using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Web.DataModels;
using Web.Models;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        //public IEnumerable<object> DataviewModel { get; private set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            this.ViewBag.Authenticated = this.HttpContext.Session.GetString("login") != null;

            string? JSONcart = this.HttpContext.Session.GetString("cart");
            this.ViewBag.Cart = JSONcart == null ? new List<OrderItemDataModel>() : JsonConvert.DeserializeObject<List<OrderItemDataModel>> (JSONcart);
        }
        public List<OrderItem> GetCart(MyContext context)
        {
            string? JSONcart = this.HttpContext.Session.GetString("cart");

            if (JSONcart==null)
            {
                return new List<OrderItem>();
            }
            else
            {
                List<OrderItemDataModel> cart = JsonConvert.DeserializeObject<List<OrderItemDataModel>>(JSONcart);

                return cart.Select(orderI => new OrderItem()
                {
                    quantity = orderI.quantity,
                    Variant = context.Variants
                                    .ToList()
                                    .Where(v => v.id == orderI.totalProductId).First()
                }).ToList();
            }
        }
    }
}
