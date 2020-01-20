using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcSample.WebUI.Models;
using Application.Dtos;
using Application.Interfaces;
using System.Threading;

namespace MvcSample.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPricerService _pricerService;
        private readonly ILlpaService _llpaService;

        public HomeController(IPricerService pricerService, ILlpaService llpaService)
        {
            _pricerService = pricerService;
            _llpaService = llpaService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new PricerViewModel
            {
                LlpaCount = await _llpaService.GetCount()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PricerViewModel vm, CancellationToken cancellationToken)
        {
            var dto = new LoanDto
            {
                Occupancy = vm.Occupancy,
                PropertyType = vm.PropertyType,
                Purpose = vm.Purpose
            };

            var prices = await _pricerService.GetAdjustedPrices(dto, cancellationToken);

            vm.Rates = prices.GroupBy(g => g.Rate).OrderBy(o => o.Key).ToDictionary(x => x.Key, x => x.OrderBy(p => p.Days).ToList());

            return View(vm);
        }

        public IActionResult Llpas()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
