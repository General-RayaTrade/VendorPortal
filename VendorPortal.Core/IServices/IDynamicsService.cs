using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.Models;

namespace VendorPortal.Core.IServices
{
    public interface IDynamicsService
    {
        Task<DynamicsCancelSalesOrderResponse> CancelOrderAsync(string orderReference);
        Task<string> RejectReturnOrderAsync(string orderReference);
        Task<string> ConfirmReturnOrderAsync(string orderReference, string orderNumber);

    }
}
