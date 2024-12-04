using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;

namespace VendorPortal.Service.Services
{
    public class SupplyChainGatewayService : ISupplyChainGatewayService
    {
        private readonly HttpClient _httpClient;
        public SupplyChainGatewayService()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.rayalogistics.com.eg/RayaLogisticsAPI/")
            };
        }
        public async Task<HttpResponseMessage> SendConfirmationRequestAsync(ConfirmationOrderRequest request)
        {
            try
            {

                // Create an anonymous object excluding the cityId property
                var dataToSend = new
                {
                    request.Ordernumber,
                    request.BusinessUnitId,
                    request.districtId,
                    request.DeliveryDate,
                    request.street,
                    request.MobileNumber1,
                    request.MobileNumber2,
                    request.CreateBy,
                    request.AWB,
                    request.Email,
                    request.deliveryMethod
                };

                var jsonContent = JsonConvert.SerializeObject(dataToSend);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Set headers
                _httpClient.Timeout = TimeSpan.FromSeconds(60); // Example timeout of 60 seconds
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Username", "Etisalat_OnLine");
                _httpClient.DefaultRequestHeaders.Add("Password", "Raya@2024");

                // Send HTTP request
                var response = await _httpClient.PostAsync("api/shipmentStatus/Confirm-Order", content);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
