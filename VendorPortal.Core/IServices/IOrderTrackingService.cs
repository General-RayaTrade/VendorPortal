using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorPortal.Core.IServices
{
    public interface IOrderTrackingService
    {
        Task<dynamic> OrderStatusHistory(string AWB, string shippingCompany);
    }
}
