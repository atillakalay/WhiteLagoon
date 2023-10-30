using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Web.ViewModels;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var villaNumbers = _unitOfWork.VillaNumber.GetAll(includeProperties:"Villa");
            return View(villaNumbers);
        }
        public IActionResult Create()
        {
            var villaNumber = new VillaNumberViewModel()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
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
            bool roomNumberExist = _unitOfWork.VillaNumber.Any(x => x.Villa_Number == villaNumberViewModel.VillaNumber.Villa_Number);


            if (ModelState.IsValid && !roomNumberExist)
            {
                _unitOfWork.VillaNumber.Add(villaNumberViewModel.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            if (roomNumberExist)
            {
                TempData["error"] = "The villa number already exist.";
            }
            villaNumberViewModel.VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
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
                VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                VillaNumber = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumberId)
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
                _unitOfWork.VillaNumber.Update(villaNumberViewModel.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa number has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            villaNumberViewModel.VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
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
                VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                VillaNumber = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumberId)
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
            VillaNumber objFromDb = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumberViewModel.VillaNumber.Villa_Number);

            if (objFromDb != null)
            {
                _unitOfWork.VillaNumber.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "The villa number has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The villa number could not be deleted.";
            return View(villaNumberViewModel);
        }
    }
}
