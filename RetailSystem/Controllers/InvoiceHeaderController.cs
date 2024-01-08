using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RetailSystem.Application.Abstractions;
using RetailSystem.Domain.DTOs;
using RetailSystem.Models;

namespace RetailSystem.Controllers
{
    public class InvoiceHeaderController : Controller
    {
        private readonly IInvoiceHeaderService _invoiceHeaderService;
        private readonly IBranchService _branchService;
        private readonly ICashierService _cashierService;

        public InvoiceHeaderController(IInvoiceHeaderService invoiceHeaderService, ICashierService cashierService, IBranchService branchService)
        {
            _invoiceHeaderService = invoiceHeaderService;
            _cashierService = cashierService;
            _branchService = branchService;
        }
        public IActionResult Index()
        {
            ViewBag.Cashiers = _cashierService.GetAllForLookUp().Data;
            ViewBag.Branches = _branchService.GetForLookUp().Data;

            return View();
        }

        public IActionResult GetAllInvoiceHeaders()
        {
            var result = _invoiceHeaderService.GetAll(new RequestModel());
            if(result.Ok)
                return PartialView("_Invoices", result.Data);

            else 
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuperInvoiceHeaderDto superInvoiceHeaderDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _invoiceHeaderService.Create(superInvoiceHeaderDto.createInvoiceHeaderDto);
                if (result.Ok)
                    return RedirectToAction("Index");

                TempData["ErrorMessage"] = result.Message;

                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "حدث خطأ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(SuperInvoiceHeaderDto superInvoiceHeaderDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _invoiceHeaderService.Update(superInvoiceHeaderDto.updateInvoiceHeaderDto);
                if (result.Ok)
                    return RedirectToAction("Index");

                TempData["ErrorMessage"] = result.Message;

                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "حدث خطأ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _invoiceHeaderService.Delete(Id);
            if (result.Ok)
                return RedirectToAction("Index");

            TempData["ErrorMessage"] = result.Message;

            return RedirectToAction("Index");
        }
    }
}
