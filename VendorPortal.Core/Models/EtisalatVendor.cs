using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.Consts;
using VendorPortal.Core.IServices;
using VendorPortal.EF;
using static VendorPortal.Core.Models.D365Model;

namespace VendorPortal.Core.Models
{
    public class EtisalatVendor : IVendor, INotifi
    {
        private readonly IB2CService _b2CService;
        private readonly INotificationService _notificationService;
        private INotifi notifier;
        public EtisalatVendor(IB2CService b2CService, INotificationService notificationService)
        {
            _b2CService = b2CService;
            _notificationService = notificationService;
            notifier = (INotifi)this;

        }
        public async Task<string> CancelOrderAsync(string orderReference)
        {
            //UpdateETIOrderStatusRoot updateETIOrderStatus = new UpdateETIOrderStatusRoot();
            UpdateETIOrderStatusRoot updateETIOrderStatus = new UpdateETIOrderStatusRoot();
            updateETIOrderStatus.eventId = DateTime.Now.Ticks.ToString();
            updateETIOrderStatus.eventType = "ProductOrderStateChangeEvent";
            updateETIOrderStatus.Event = new Event();
            updateETIOrderStatus.Event.productOrder = new ProductOrder();
            updateETIOrderStatus.Event.productOrder.state = "Cancelled";
            updateETIOrderStatus.Event.productOrder.id = orderReference;
            updateETIOrderStatus.Event.productOrder.relatedParty = new List<RelatedParty>();
            updateETIOrderStatus.Event.productOrder.relatedParty.Add(new RelatedParty()
            {
                name = "Raya",
                role = "Provider"
            });
            updateETIOrderStatus.Event.productOrder.relatedParty.Add(new RelatedParty()
            {
                name = "--Raya.Agent--",
                role = "Agent"
            });
            return await UpdateEtisalatOrderStatus(updateETIOrderStatus);
        }
        async Task INotifi.NotifiOtherAsync(Notification notification)
        {
            await _notificationService.AddNotificationAsync(notification);
        }

        private async Task<string> UpdateEtisalatOrderStatus(UpdateETIOrderStatusRoot updateETIOrderStatusRoot)
        {
            string? token = (await _b2CService.LoginAsync())!.access_token;
            if (token == null)
            {
                await notifier.NotifiOtherAsync(new Notification()
                {
                    Title = "Send Cancelation to the Vendor.",
                    Message = "Can not set cancelation request to the vendor due to token at B2C.",
                    IconClass = "fas fa-times-circle",
                    Url = "/",
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    VendorName = nameof(Vendors.ETISALAT), // Replace with actual user ID
                    ActionState = false
                });
                return string.Empty;
            }

            var body = JsonConvert.SerializeObject(updateETIOrderStatusRoot).Replace("Event", "event");

            var options = new RestClientOptions("http://www.rayatrade.com/RayaB2C_API/api/B2C_Prod/Update_Etisalat_OrderStatus")
            {
                ThrowOnAnyError = true, // Optional: Throw exceptions on HTTP error status codes
                MaxTimeout = -1        // Optional: -1 for no timeout, or set a timeout in milliseconds
            };

            var client = new RestClient(options);

            var request = new RestRequest()
                .AddHeader("x-Gateway-APIKey", "c15856f2-8a39-4f79-9bbd-18267fc60a3d")
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Authorization", "Basic UmF5YTpSYXlhMTIz")
                .AddParameter("application/json", body, ParameterType.RequestBody);

            var response = await client.PostAsync(request);
            if(response?.Content == null)
            {
                await notifier.NotifiOtherAsync(new Notification()
                {
                    Title = $"Send Cancelation to the Vendor. ({updateETIOrderStatusRoot.Event.productOrder.id})",
                    Message = "Can not set cancelation request to the vendor due to vendor Error returned with null.",
                    IconClass = "fas fa-times-circle",
                    Url = "/",
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    VendorName = nameof(Vendors.ETISALAT), // Replace with actual user ID
                    ActionState = false                
                });
            }
            else
            {
                await notifier.NotifiOtherAsync(new Notification()
                {
                    Title = $"Send Cancelation to the Vendor. ({updateETIOrderStatusRoot.Event.productOrder.id})",
                    Message = $"Cancelation response is {(response?.Content.Equals("{}") == true ? "Canceled Successfully" : $"Error: {response?.Content}")}.",
                    IconClass = "fas fa-check-circle",
                    Url = "/",
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    VendorName = nameof(Vendors.ETISALAT), // Replace with actual user ID
                    ActionState = true
                });
            }
            return response?.Content ?? string.Empty;
        }
    }
}
