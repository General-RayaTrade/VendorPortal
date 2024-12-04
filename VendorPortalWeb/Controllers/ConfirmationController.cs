using Microsoft.AspNetCore.Mvc;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;

namespace VendorPortal.Web.Controllers
{
    public class ConfirmationController : Controller
    {
        private readonly IConfirmationService _confirmationService;
        public ConfirmationController(IConfirmationService confirmationService)
        {
            _confirmationService = confirmationService;
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] OrderConfirmationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.OrderReference))
            {
                return BadRequest("Order reference cannot be empty.");
            }

            var (isValid, message) = await _confirmationService.ValidateOrderConfirmationConstraintsAsync(nameof(Vendors.ETISALAT), request.OrderReference);

            if (!isValid)
            {
                return BadRequest($"{message} Order Reference: {request.OrderReference}");
            }

            var result = await _confirmationService.GetOrderConfirmationDataAsync(nameof(Vendors.ETISALAT), request.OrderReference);

            if (result == null)
            {
                return NotFound($"Order data not found for reference: {request.OrderReference}");
            }

            return View(result); // Render a partial view to return HTML directly.
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder([FromBody] ConfirmationOrderRequest confirmationOrderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Model state is invalid." });
            }

            try
            {
                var response = await _confirmationService.ConfirmOrderAsync(confirmationOrderRequest);
                if (response.state)
                {
                    return Json(new { success = true, message = "Order confirmed successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = $"Error: {response.statusCode}, {response.message}" });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { success = false, message = "An internal server error occurred." });
            }
        }
    }
}
