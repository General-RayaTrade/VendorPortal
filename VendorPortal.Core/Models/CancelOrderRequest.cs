using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorPortal.Core.Models
{
    public class CancelOrderRequest
    {
        public string MagentoRef { set; get; }
    }
    public class CancelOrderModel
    {
        public string OrderReference { get; set; }
        public string Vendor { get; set; }
    }
}
