using Microsoft.AspNetCore.Mvc;
using RetailSystem.Application.Abstractions;
using RetailSystem.Domain.DTOs;

namespace RetailSystem.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
            => _branchService = branchService;

        public IActionResult Index()
        {
            var result = _branchService.GetAll(new RequestModel());
            if (result.Ok)
                return View(result.Data);

            else
            {
                ViewBag.ErrorMessage = result.Message;
                return View();
            }
        }
    }
}
