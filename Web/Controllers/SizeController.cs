using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Secured]
    public class SizeController : Controller
    {
        private MyContext _context = new MyContext();
        public IActionResult Index()
        {
            List<Size> SizeList = _context.Sizes.ToList();
            return View(SizeList);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Size created)
        {
            if (ModelState.IsValid)
            {
                _context.Sizes.Add(created);
                _context.SaveChanges();
                TempData["success"] = "Size created successfully";
                return RedirectToAction("Index");
            }
            return View(created);
        }

        // GET: SizeController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Size selected = _context.Sizes.Find(id);
            return View(selected);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Size obj)
        {
            if (ModelState.IsValid)
            {
                _context.Sizes.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Size updated successfully";
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
            Size selected = _context.Sizes.Find(id);
            if (selected == null)
            {
                return NotFound();
            }
            return View(selected);
        }

        // POST: SizeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSize(int? id)
        {
            Size selected = _context.Sizes.Find(id);
            if (selected == null)
            {
                return NotFound();
            }
            _context.Sizes.Remove(selected);
            _context.SaveChanges();
            TempData["success"] = "Size deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
