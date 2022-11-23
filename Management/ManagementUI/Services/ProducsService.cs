using ManagementUI.Services.IServices;
using ManagementUI.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace ManagementUI.Services
{
    public class ProducsService : IProducsService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;

        public ProducsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
        }

        public async Task CreateNewProduct(ProductVM productVM)
        {
            var content = JsonConvert.SerializeObject(productVM);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/products", bodyContent);
            string responseResult = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseResult);
            }
        }
    }
}
