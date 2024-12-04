using Microsoft.AspNetCore.SignalR;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;
using VendorPortal.EF;
using VendorPortal.EF.IRepositories;

namespace VendorPortal.Service.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRealTimeNotification _realTimeNotification;

        public NotificationService(IUnitOfWork unitOfWork, IRealTimeNotification realTimeNotification)
        {
            _unitOfWork = unitOfWork;
            _realTimeNotification = realTimeNotification;
        }
        public async Task AddNotificationAsync(Notification notification)
        {
            await _unitOfWork.notifications.AddAsync(notification);

            var totalNotifications = await _unitOfWork.notifications.CountAsync(noti => noti.VendorName == nameof(Vendors.ETISALAT));

            await _realTimeNotification.SendNotificationAsync(notification.Title, totalNotifications);
        }
        public async Task<IEnumerable<Notification>> GetNotificationsAsync(string vendor)
        {
            try
            {
                var notifications = await _unitOfWork.notifications.FindAllAsync(noti => noti.VendorName.Equals(vendor));
                return notifications;
            } catch (Exception ex)
            {
                throw;
            }
            //throw new NotImplementedException();
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            throw new NotImplementedException();
        }
    }
}
