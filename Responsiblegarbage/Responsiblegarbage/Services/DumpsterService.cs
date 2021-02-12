using Newtonsoft.Json;
using Responsiblegarbage.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Responsiblegarbage.Services
{
    public class DumpsterService : IDumpsterService
    {
        HttpClient client;

        public DumpsterService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
        }

        public async Task<List<DumpsterDto>> GetByProductAsync(int productId)
        {
            var response = await client.GetAsync($"api/dumpsters?productId={productId}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<List<DumpsterDto>>(json));
            }

            return new List<DumpsterDto>();
        }
    }
}
