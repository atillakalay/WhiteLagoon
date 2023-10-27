using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("name", "The description can't exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _context.Add(villa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            Villa? villa = _context.Villas.FirstOrDefault(x => x.Id == id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }
        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            if (ModelState.IsValid && villa.Id > 0)
            {
                _context.Update(villa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Villa? villa = _context.Villas.FirstOrDefault(x => x.Id == id);
            if (villa is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }
        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? obj = _context.Villas.FirstOrDefault(x => x.Id == villa.Id);
            if (obj is not null)
            {
                _context.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
