using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Web.ViewModels;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VillaNumberController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villaNumbers = _context.VillaNumbers.Include(x => x.Villa).ToList();
            return View(villaNumbers);
        }
        public IActionResult Create()
        {
            var villaNumber = new VillaNumberViewModel()
            {
                VillaList = _context.Villas.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(villaNumber);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberViewModel villaNumberViewModel)
        {
            bool roomNumberExist = _context.VillaNumbers.Any(x => x.Villa_Number == villaNumberViewModel.VillaNumber.Villa_Number);


            if (ModelState.IsValid && !roomNumberExist)
            {
                _context.VillaNumbers.Add(villaNumberViewModel.VillaNumber);
                _context.SaveChanges();
                TempData["success"] = "The villa number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            if (roomNumberExist)
            {
                TempData["error"] = "The villa number already exist.";
            }
            villaNumberViewModel.VillaList = _context.Villas.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(villaNumberViewModel);
        }
        public IActionResult Update(int villaNumberId)
        {
            VillaNumberViewModel villaNumberViewModel = new()
            {
                VillaList = _context.Villas.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                VillaNumber = _context.VillaNumbers.FirstOrDefault(x => x.Villa_Number == villaNumberId)
            };
            if (villaNumberViewModel.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberViewModel);
        }
        [HttpPost]
        public IActionResult Update(VillaNumberViewModel villaNumberViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.VillaNumbers.Update(villaNumberViewModel.VillaNumber);
                _context.SaveChanges();
                TempData["success"] = "The villa number has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            villaNumberViewModel.VillaList = _context.Villas.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(villaNumberViewModel);
        }
        public IActionResult Delete(int villaNumberId)
        {
            VillaNumberViewModel villaNumberViewModel = new VillaNumberViewModel
            {
                VillaList = _context.Villas.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                VillaNumber = _context.VillaNumbers.FirstOrDefault(x => x.Villa_Number == villaNumberId)
            };
            if (villaNumberViewModel.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberViewModel);
        }
        [HttpPost]
        public IActionResult Delete(VillaNumberViewModel villaNumberViewModel)
        {
            VillaNumber objFromDb = _context.VillaNumbers
                .FirstOrDefault(x => x.Villa_Number == villaNumberViewModel.VillaNumber.Villa_Number);

            if (objFromDb != null)
            {
                _context.VillaNumbers.Remove(objFromDb);
                _context.SaveChanges();
                TempData["success"] = "The villa number has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The villa number could not be deleted.";
            return View(villaNumberViewModel);
        }
    }
}
