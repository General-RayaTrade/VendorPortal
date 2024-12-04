using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core;
using VendorPortal.Core.Models;

namespace VendorPortal.EF.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext context { get; }
        IBaseRepository<OrderStatus> orderStatuses { get; } 
        IBaseRepository<OrdersXsc> ordersXsc { get; }
        IBaseRepository<OrdersFlag> ordersFlag { get; }
        IBaseRepository<OrderConfirmationsData> orderConfirmationsData { get; }
        IBaseRepository<VWcityDistrict> vwcityDistrict { get; }
        IBaseRepository<Notification>  notifications { get; }
        int Complete();
        Task<(string, string)> GetOrderConfirmationsShippingAddressDataAsync(string orderReference);
    }
}
