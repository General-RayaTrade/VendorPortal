using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.EF;

namespace VendorPortal.Core.IServices
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetNotificationsAsync(string vendor);
        void MarkNotificationAsRead(int notificationId);
        Task AddNotificationAsync(Notification notification);
    }
}
