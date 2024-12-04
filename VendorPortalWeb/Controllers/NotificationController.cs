using Microsoft.AspNetCore.Mvc;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortal.EF;

namespace VendorPortal.Web.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await _notificationService.GetNotificationsAsync(nameof(Vendors.ETISALAT));
            return PartialView("_Notifications", notifications);
        }
        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            _notificationService.MarkNotificationAsRead(id);
            return Ok();
        }

        public async Task<IActionResult> CreateNotification()
        {
            var notification = new Notification
            {
                Title = "New Order Received",
                Message = "You have a new order from vendor.",
                IconClass = "fas fa-envelope",
                Url = "/orders",
                CreatedAt = DateTime.Now,
                IsRead = false,
                VendorName = nameof(Vendors.ETISALAT) // Replace with actual user ID
            };

            await _notificationService.AddNotificationAsync(notification);

            return Ok();
        }

    }
}
