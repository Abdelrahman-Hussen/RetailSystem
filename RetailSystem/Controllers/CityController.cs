using Microsoft.AspNetCore.Mvc;
using RetailSystem.Application.Abstractions;
using RetailSystem.Domain.DTOs;

namespace RetailSystem.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
            => _cityService = cityService;

        public IActionResult Index()
        {
            var result = _cityService.GetAll(new RequestModel());
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
