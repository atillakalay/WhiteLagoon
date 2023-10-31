using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var villas = _unitOfWork.Villa.GetAll();
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
                if (villa.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");

                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                        villa.Image.CopyTo(fileStream);

                    villa.ImageUrl = @"\images\VillaImage\" + fileName;

                }
                else
                {
                    villa.ImageUrl = "https://placehold.co/600x400";
                }

                _unitOfWork.Villa.Add(villa);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa could not be created.";
            return View();
        }
        public IActionResult Update(int id)
        {
            Villa? villa = _unitOfWork.Villa.Get(x => x.Id == id);
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
                if (villa.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");

                    if (!string.IsNullOrEmpty(villa.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, villa.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                        villa.Image.CopyTo(fileStream);

                    villa.ImageUrl = @"\images\VillaImage\" + fileName;

                }

                _unitOfWork.Villa.Update(villa);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa could not be updated.";
            return View();
        }
        public IActionResult Delete(int id)
        {
            Villa? villa = _unitOfWork.Villa.Get(x => x.Id == id);
            if (villa is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }
        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? obj = _unitOfWork.Villa.Get(x => x.Id == villa.Id);
            if (obj is not null)
            {
                if (!string.IsNullOrEmpty(obj.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfWork.Villa.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa could not be deleted.";
            return View();
        }
    }
}
