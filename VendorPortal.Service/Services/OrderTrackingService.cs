using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;

namespace VendorPortal.Service.Services
{
    public class OrderTrackingService : IOrderTrackingService
    {
        private IShippingCompany? _shippingCompany;

        public async Task<dynamic> OrderStatusHistory(string AWB, string shippingCompany)
        {
            if (shippingCompany.ToLower().Equals(nameof(ShippingCompanies.ARAMEX).ToLower()))
            {
                _shippingCompany = new Aramex();
                var response = await _shippingCompany.GetOrderStatusHistoryAsync(AWB);
                return response;
            }
            return null;
        }
       
    }
}
