using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.Models;

namespace VendorPortal.Core.IServices
{
    public interface IConfirmationService
    {
        Task<ConfirmationOrderResponse> ConfirmOrderAsync(ConfirmationOrderRequest request);
        Task<ConfirmationOrderData?> GetOrderConfirmationDataAsync(string vendor, string orderReference);
        Task<(bool IsValid, string Message)> ValidateOrderConfirmationConstraintsAsync(string vendor, string orderReference);
    }
}
