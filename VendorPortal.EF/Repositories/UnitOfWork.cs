using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VendorPortal.Core;
using VendorPortal.Core.Models;
using VendorPortal.EF.IRepositories;

namespace VendorPortal.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext context { get; }
        public IBaseRepository<OrderStatus> orderStatuses { get; set; }
        public IBaseRepository<OrdersXsc> ordersXsc { get; set; }
        public IBaseRepository<OrdersFlag> ordersFlag { get; set; } 
        public IBaseRepository<OrderConfirmationsData> orderConfirmationsData { get; set; }
        public IBaseRepository<VWcityDistrict> vwcityDistrict { get; set; }
        public IBaseRepository<Notification> notifications { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            orderStatuses = new BaseRepository<OrderStatus>(context);
            ordersXsc = new BaseRepository<OrdersXsc>(context);
            ordersFlag = new BaseRepository<OrdersFlag>(context);
            orderConfirmationsData = new BaseRepository<OrderConfirmationsData>(context);
            vwcityDistrict = new BaseRepository<VWcityDistrict>(context);
            notifications = new BaseRepository<Notification>(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<(string, string)> GetOrderConfirmationsShippingAddressDataAsync(string orderReference)
        {
            string city = string.Empty;
            string district = string.Empty;
            var orderJsonDetail = (await context.OrderJsonDetails.FromSqlRaw("SELECT * FROM dbo.fn_OrderJsonDetails({0})", orderReference)
            .ToListAsync()).FirstOrDefault();

            if (orderJsonDetail != null && !string.IsNullOrEmpty(orderJsonDetail.JSONData))
            {
                // Deserialize JSON string to the D365Model object
                var d365Model = JsonConvert.DeserializeObject<D365Model.D365_SalesOrder_Request>(orderJsonDetail.JSONData);

                // Ensure d365Model is not null and contains the expected structure
                if (d365Model?.SalesOrder != null && d365Model.SalesOrder.Any())
                {
                    var shippingAddress = d365Model.SalesOrder.First().shipping_address.FirstOrDefault();

                    if (shippingAddress != null)
                    {
                        city = shippingAddress.City;
                        district = shippingAddress.District;
                    }
                }
            }
            return (city, district);
        }
    }
}
