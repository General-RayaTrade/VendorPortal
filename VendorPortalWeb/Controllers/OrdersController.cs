using Microsoft.AspNetCore.Mvc;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using System.Linq;

namespace VendorPortal.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Return the View
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadOrders(int draw, int start, int length)
        {
            // Fetch orders from service using the skip (start) and take (length)
            var orders = await _orderService.GetOrders(nameof(Vendors.ETISALAT), start, length);

            // Get total record count for pagination
            var totalRecords = await _orderService.CounterAsync(nameof(Vendors.ETISALAT));

            // Return JSON in the structure that DataTables expects
            return Json(new
            {
                draw = draw,  // This is the draw counter from DataTables, passed in request
                recordsTotal = totalRecords,  // Total number of records in the database
                recordsFiltered = totalRecords,  // Total number of records after filtering (if any)
                data = orders.Select(ord => new
                {
                    ord.OrderNumber,
                    ord.OrderRef,
                    ord.CustomerName,
                    ord.DxStatus,
                    ord.DxCreatedDate
                })  // The data to display in the table
            });
        }

    }
}
