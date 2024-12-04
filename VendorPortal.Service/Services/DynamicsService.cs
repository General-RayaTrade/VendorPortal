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
    public class DynamicsService : IDynamicsService
    {
        private readonly IB2CService _b2CService;
        public DynamicsService(IB2CService b2CService)
        {
            _b2CService = b2CService;
        }
        public async Task<DynamicsCancelSalesOrderResponse> CancelOrderAsync(string orderReference)
        {
            DynamicsCancelSalesOrderResponse dynamicsCancelSalesOrderResponse= new DynamicsCancelSalesOrderResponse();
            string? token = (await _b2CService.LoginAsync())!.access_token;
            if (token == null)
            {
                dynamicsCancelSalesOrderResponse.Status = false;
                dynamicsCancelSalesOrderResponse.Message = "Can not authorize at B2CLogin.";
                return dynamicsCancelSalesOrderResponse;

            }

            CancelOrderRequest cancelOrderRequest = new CancelOrderRequest()
            {
                MagentoRef = orderReference
            };

            var body = JsonConvert.SerializeObject(cancelOrderRequest);

            var options = new RestClientOptions("http://www.rayatrade.com/RayaB2C_API/api/B2C_Prod/Cancel_D365_SalesOrder")
            {
                ThrowOnAnyError = true, // Optional: Throw exceptions on HTTP error status codes
                MaxTimeout = -1        // Optional: -1 for no timeout, or set a timeout in milliseconds
            };

            var client = new RestClient(options);

            var request = new RestRequest()
                .AddHeader("Authorization", "Bearer " + token)
                .AddHeader("Content-Type", "application/json")
                .AddJsonBody(body); // Automatically sets the body and Content-Type

            var response = await client.PostAsync(request);
            dynamicsCancelSalesOrderResponse.Status = (bool)(response?.Content!.ToLower().Contains("true")!) ? true : false;
            dynamicsCancelSalesOrderResponse.Message = response?.Content!;
            return dynamicsCancelSalesOrderResponse;
            
        }


        public Task<string> ConfirmReturnOrderAsync(string orderReference, string orderNumber)
        {
            throw new NotImplementedException();
        }

        public Task<string> RejectReturnOrderAsync(string orderReference)
        {
            throw new NotImplementedException();
        }
        private async Task<string> CallingDynamicsEndpointAsync(string url, string body)
        {
            throw new NotImplementedException();
        }
    }
}
