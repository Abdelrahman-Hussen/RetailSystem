using Microsoft.AspNetCore.Mvc;
using RetailSystem.Application.Abstractions;
using RetailSystem.Domain.DTOs;
using RetailSystem.Models;

namespace RetailSystem.Controllers
{
    public class CashierController : Controller
    {
        private readonly ICashierService _cashierService;

        public CashierController(ICashierService cashierService)
            => _cashierService = cashierService;

        public IActionResult Index()
        {
            var result = _cashierService.GetAll(new RequestModel());
            if (result.Ok)
                return View(result.Data);

            else
            {
                ViewBag.ErrorMessage = result.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCashierDto Dto)
        {

            if (ModelState.IsValid)
            {
                var result = await _cashierService.Create(Dto);
                if (result.Ok)
                    return RedirectToAction("Index");

                TempData["ErrorMessage"] = result.Message;

                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "حدث خطأ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCashierDto Dto)
        {

            if (ModelState.IsValid)
            {
                var result = await _cashierService.Update(Dto);
                if (result.Ok)
                    return RedirectToAction("Index");

                TempData["ErrorMessage"] = result.Message;

                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "حدث خطأ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _cashierService.Delete(Id);
            if (result.Ok)
                return RedirectToAction("Index");

            TempData["ErrorMessage"] = result.Message;

            return RedirectToAction("Index");
        }
    }
}
