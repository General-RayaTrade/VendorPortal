using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortal.EF.IRepositories;

namespace VendorPortal.Service.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<OrdersXsc>> GetOrders(string vendor, int skip = 0, int take = 50)
        {
            var orders = await _unitOfWork.ordersXsc.FindAllAsync(
                ord => ord.OrderSource.ToLower().Contains(vendor.ToLower()),
                skip: skip,
                take: take,
                orderBy: ord => ord.DxCreatedDate,
                orderByDirection: "DESC");
            return orders!;
        }
        public async Task<int> CounterAsync(string vendor)
        {
            var result = await _unitOfWork.ordersXsc.CountAsync(ord => ord.OrderSource.ToLower().Contains(vendor.ToLower()));
            return result;
        }
        public async Task<int> GetTotalOrdersCountAsync(string vendor)
        {
            return await _unitOfWork.ordersXsc.CountAsync(ord => ord.OrderSource.ToLower().Contains(vendor.ToLower()));
        }

        public async Task<int> GetPendingOrdersCountAsync(string vendor)
        {
            return await _unitOfWork.ordersXsc.CountAsync(ord => ord.OrderSource.ToLower().Contains(vendor.ToLower()) && ord.DxStatus.Equals(nameof(DXStatus.OpenOrder)));
        }

        public async Task<int> GetCompletedOrdersCountAsync(string vendor)
        {
            return await _unitOfWork.ordersXsc.CountAsync(ord => ord.OrderSource.ToLower().Contains(vendor.ToLower()) && ord.DxStatus.Equals(nameof(DXStatus.Invoiced)));
        }
        public async Task<int> GetCanceledOrdersCountAsync(string vendor)
        {
            return await _unitOfWork.ordersXsc.CountAsync(ord => ord.OrderSource.ToLower().Contains(vendor.ToLower()) && ord.DxStatus.Equals(nameof(DXStatus.Canceld)));
        }
    }
}
