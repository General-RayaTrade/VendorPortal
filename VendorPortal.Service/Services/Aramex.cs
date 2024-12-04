using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;

namespace VendorPortal.Service.Services
{
    public class Aramex : IShippingCompany
    {
        public async Task<dynamic> GetOrderStatusHistoryAsync(string AWB)
        {
            return await CallingAramexEndpointAsync(AWB);
        }
        private async Task<AramexTrackingResult> CallingAramexEndpointAsync(string AWB)
        {
            var options = new RestClientOptions("http://www.rayatrade.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/rayatradewcfservice/RayaService.svc/TrackShipments/60510272/{AWB}/false", Method.Get);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<AramexTrackingResult>(response.Content!);
            return result!;
        }
    }
}
