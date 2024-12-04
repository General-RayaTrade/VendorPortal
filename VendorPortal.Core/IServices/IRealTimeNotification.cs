using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorPortal.Core.IServices
{
    public interface IRealTimeNotification
    {
        Task SendNotificationAsync(string title, int totalNotifications);
    }
}
