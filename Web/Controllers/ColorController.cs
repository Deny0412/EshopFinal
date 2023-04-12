using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Web.Models;
using Color = Web.Models.Color;

namespace Web.Controllers
{
    [Secured]
    public class ColorController : Controller
    {
        private MyContext _context = new MyContext();
        public IActionResult Index()
        {
            List<Color> ColorList = _context.Colors.ToList();
            return View(ColorList);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Color created)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Add(created);
                _context.SaveChanges();
                TempData["success"] = "Color created successfully";
                return RedirectToAction("Index");
            }
               
            return View(created);
        }

        // GET: ColorController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Color selected = _context.Colors.Find(id);
            return View(selected);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Color obj)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Color updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Color selected = _context.Colors.Find(id);
            if (selected == null)
            {
                return NotFound();
            }
            return View(selected);
        }

        // POST: ColorController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteColor(int? id)
        {
            Color selected = _context.Colors.Find(id);
            if (selected == null)
            {
                return NotFound();
            }
            _context.Colors.Remove(selected);
            _context.SaveChanges();
            TempData["success"] = "Color deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
