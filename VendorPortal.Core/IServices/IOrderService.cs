using VendorPortal.Core.Models;

namespace VendorPortal.Core.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrdersXsc>> GetOrders(string vendor, int skip = 0, int take = 50, string searchValue = "");
        Task<int> CounterAsync(string vendor, string searchValue = "");
        Task<int> GetTotalOrdersCountAsync(string vendor);
        Task<int> GetPendingOrdersCountAsync(string vendor);
        Task<int> GetCompletedOrdersCountAsync(string vendor);
        Task<int> GetCanceledOrdersCountAsync(string vendor);
        Task<OrdersXsc?> GetOrderAsync(string vendor, string orderReference);
    }
}
