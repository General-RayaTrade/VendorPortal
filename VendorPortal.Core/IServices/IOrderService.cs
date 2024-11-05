using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorPortal.Core.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrdersXsc>> GetOrders(string vendor, int skip = 0, int take = 50);
        Task<int> CounterAsync(string vendor);
        Task<int> GetTotalOrdersCountAsync(string vendor);
        Task<int> GetPendingOrdersCountAsync(string vendor);
        Task<int> GetCompletedOrdersCountAsync(string vendor);
        Task<int> GetCanceledOrdersCountAsync(string vendor);
    }
}
