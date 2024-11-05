using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortalWeb.Models;

namespace VendorPortalWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var totalOrders = await _orderService.GetTotalOrdersCountAsync(nameof(Vendors.ETISALAT));
            var canceledOrders = await _orderService.GetCanceledOrdersCountAsync(nameof(Vendors.ETISALAT));
            var pendingOrders = await _orderService.GetPendingOrdersCountAsync(nameof(Vendors.ETISALAT));
            var completedOrders = await _orderService.GetCompletedOrdersCountAsync(nameof(Vendors.ETISALAT));

            // Calculate percentages
            var canceledPercentage = totalOrders > 0 ? (double)canceledOrders / totalOrders * 100 : 0;
            var pendingPercentage = totalOrders > 0 ? (double)pendingOrders / totalOrders * 100 : 0;
            var completedPercentage = totalOrders > 0 ? (double)completedOrders / totalOrders * 100 : 0;

            ViewBag.TotalOrders = totalOrders;
            ViewBag.CanceledOrders = canceledOrders;
            ViewBag.PendingOrders = pendingOrders;
            ViewBag.CompletedOrders = completedOrders;

            ViewBag.CanceledPercentage = canceledPercentage;
            ViewBag.PendingPercentage = pendingPercentage;
            ViewBag.CompletedPercentage = completedPercentage;

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
