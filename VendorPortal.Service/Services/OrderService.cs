using Microsoft.EntityFrameworkCore;
using VendorPortal.Core;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;
using VendorPortal.EF;
using VendorPortal.EF.IRepositories;

namespace VendorPortal.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        public OrderService(IUnitOfWork unitOfWork,
                            ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<IEnumerable<OrdersXsc>> GetOrders(string vendor, int skip = 0, int take = 50, string searchValue = "")
        {
            IEnumerable<OrdersXsc?> orders;
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                orders = await _unitOfWork.ordersXsc.FindAllAsync(
                                                    ord => ord.OrderSource.ToLower().Contains(vendor.ToLower())
                                                           && (ord.OrderNumber.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.OrderRef.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.CustomerName!.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.CustomerMobile!.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.PaymentMethod.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.DxStatus.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.Awb.ToLower().Contains(searchValue.ToLower())),
                                                    skip: skip,
                                                    take: take,
                                                    orderBy: ord => ord.DxCreatedDate,
                                                    orderByDirection: "DESC");
            }
            else
            {
                orders = await _unitOfWork.ordersXsc.FindAllAsync(
                ord => ord.OrderSource.ToLower().Contains(vendor.ToLower()),
                skip: skip,
                take: take,
                orderBy: ord => ord.DxCreatedDate,
                orderByDirection: "DESC");
            }
            return orders!;
        }
        public async Task<int> CounterAsync(string vendor, string searchValue = "")
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                result = await _unitOfWork.ordersXsc.CountAsync(ord => ord.OrderSource.ToLower().Contains(vendor.ToLower())
                                                                       && (ord.OrderNumber.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.OrderRef.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.CustomerName!.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.CustomerMobile!.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.PaymentMethod.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.DxStatus.ToLower().Contains(searchValue.ToLower()) ||
                                                    ord.Awb.ToLower().Contains(searchValue.ToLower())));

            }
            else
            {
                result = await _unitOfWork.ordersXsc.CountAsync(ord => ord.OrderSource.ToLower().Contains(vendor.ToLower()));
            }
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

        public async Task<OrdersXsc?> GetOrderAsync(string vendor, string orderReference)
        {
            return await _unitOfWork.ordersXsc.FindAsync(order => order.OrderRef.Equals(orderReference));
        }     
    }
}
