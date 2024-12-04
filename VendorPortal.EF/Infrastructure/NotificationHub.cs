using Microsoft.AspNetCore.SignalR;

namespace VendorPortal.EF.Infrastructure
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string message, int totalNotifications)
        {
            await Clients.All.SendAsync("ReceiveNotification", message, totalNotifications);
        }
    }
}
