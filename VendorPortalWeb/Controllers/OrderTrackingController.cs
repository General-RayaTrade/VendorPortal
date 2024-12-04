using Microsoft.AspNetCore.Mvc;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;

namespace VendorPortal.Web.Controllers
{
    public class OrderTrackingController : Controller
    {
        private readonly IOrderTrackingService _orderTrackingService;
        public OrderTrackingController(IOrderTrackingService orderTrackingService)
        {
            _orderTrackingService = orderTrackingService;
        }
        public async Task<IActionResult> Index([FromBody] TrackOrderRequestModel model)
        {
            var result = await _orderTrackingService.OrderStatusHistory(model.awb, nameof(ShippingCompanies.ARAMEX));
            return View(result);
        }
    }
}
