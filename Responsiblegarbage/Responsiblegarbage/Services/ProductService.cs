using Newtonsoft.Json;
using Responsiblegarbage.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Responsiblegarbage.Services
{
    public class ProductService : IProductService
    {
        HttpClient client;

        public ProductService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
        }

        public async Task<ProductDto> SearchProductAsync(string barcode)
        {
            var response = await client.GetAsync($"api/products/search?barcode={barcode}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<ProductDto>(json));
        }
    }
}
