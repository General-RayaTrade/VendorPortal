using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;

namespace VendorPortal.Service.Services
{
    public class B2CService : IB2CService
    {
        public async Task<B2CLoginResponse?> LoginAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://www.rayatrade.com/RayETI_Marketplace_API/oauth/token");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("client_Id", "150EB6F2-29F8-4083-92A6-16D9A862E08M"));
            collection.Add(new("client_Secret", "85154045B38A4374A58D17759C31B47Z"));
            collection.Add(new("grant_type", "client_credentials"));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var B2CResponse = JsonConvert.DeserializeObject<B2CLoginResponse>(await response.Content.ReadAsStringAsync());
            return B2CResponse;
        }
    }
}
