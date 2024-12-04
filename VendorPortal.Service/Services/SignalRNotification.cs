using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.IServices;
using VendorPortal.EF.Infrastructure;

namespace VendorPortal.Service.Services
{
    public class SignalRNotification : IRealTimeNotification
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public SignalRNotification(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(string title, int totalNotifications)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", title, totalNotifications);
        }
    }
}
