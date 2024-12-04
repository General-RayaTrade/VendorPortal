using Microsoft.AspNetCore.Mvc;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using System.Linq;
using VendorPortal.Core.Models;

namespace VendorPortal.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IDynamicsService _dynamicsService;
        private readonly IB2CService _b2cService;
        private readonly INotificationService _notificationService;
        public OrdersController(IOrderService orderService,
                                IB2CService b2cService,
                                IDynamicsService dynamicsService,
                                INotificationService notificationService)
        {
            _orderService = orderService;
            _b2cService = b2cService;
            _dynamicsService = dynamicsService;
            _notificationService = notificationService;
        }

        // Return the View
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadOrders(int draw, int start, int length, string searchValue = "")
        {
            try
            {
                // Fetch orders from service using the skip (start) and take (length)
                var orders = (await _orderService.GetOrders(nameof(Vendors.ETISALAT), start, length, searchValue)).ToList();

                // Get total record count for pagination
                var totalRecords = await _orderService.CounterAsync(nameof(Vendors.ETISALAT), searchValue);

                //orders = await _orderService.GetOrdersExternalShippmentAWBAsync(orders);

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
                        ord.DxCreatedDate,
                        ord.CustomerMobile,
                        ord.PaymentMethod,
                        ord.OrderSource,
                        ord.Awb
                    })  // The data to display in the table
                });
            } catch(Exception ex)
            {
                return Json(new { });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CancelOrder([FromBody] CancelOrderModel cancelOrderModel)
        {
            string result = $"Can not canceling order at {cancelOrderModel.Vendor}.";
            DynamicsCancelSalesOrderResponse dynamicsResponse = await _dynamicsService.CancelOrderAsync(cancelOrderModel.OrderReference);
            if (dynamicsResponse == null || !dynamicsResponse.Status)
            {
                return Json(
                        new
                        {
                            codeStatus = 500,
                            message = dynamicsResponse?.Message ?? "Internal Server Error Dynamics phase."
                        }
                    );
            }
            if (cancelOrderModel.Vendor.ToLower().Contains(nameof(Vendors.ETISALAT).ToLower()))
            {
                EtisalatVendor etisalatVendor = new EtisalatVendor(_b2cService, _notificationService);
                result = await etisalatVendor.CancelOrderAsync(cancelOrderModel.OrderReference);
            }
            return Json(
                new
                {
                    codeStatus = 200,
                    message = result
                }
                );
        }

    }
}
