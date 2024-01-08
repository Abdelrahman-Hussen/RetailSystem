using Microsoft.AspNetCore.Mvc;
using RetailSystem.Application.Abstractions;
using RetailSystem.Domain.DTOs;
using RetailSystem.Models;

namespace RetailSystem.Controllers
{
    public class InvoiceDetailController : Controller
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService)
            => _invoiceDetailService = invoiceDetailService;

        public IActionResult GetInvoiceDetails(long ID)
        {
            var result = _invoiceDetailService.GetAll(new InvoiceDetailRequestModel() { InvoiceHeaderId = ID });
            if (result.Ok)
                return PartialView("_InvoiceDetails",result.Data);

            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction("Index", "InvoiceHeader");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuperInvoiceHeaderDto superInvoiceHeaderDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _invoiceDetailService.Create(superInvoiceHeaderDto.createInvoiceDetailDto);
                if (result.Ok)
                    return RedirectToAction("Index", "InvoiceHeader");

                TempData["ErrorMessage"] = result.Message;

                return RedirectToAction("Index", "InvoiceHeader");
            }
            TempData["ErrorMessage"] = "حدث خطأ";
            return RedirectToAction("Index", "InvoiceHeader");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _invoiceDetailService.Delete(Id);
            if (result.Ok)
                return RedirectToAction("Index", "InvoiceHeader");

            TempData["ErrorMessage"] = result.Message;

            return RedirectToAction("Index", "InvoiceHeader");
        }
    }
}
