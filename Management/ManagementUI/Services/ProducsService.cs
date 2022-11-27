using ManagementUI.Services.IServices;
using ManagementUI.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace ManagementUI.Services
{
    public class ProducsService : IProducsService
    {
        private readonly HttpClient _httpClient;

        public ProducsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductVM> CreateNewProduct(ProductVM productVM)
        {
            var content = JsonConvert.SerializeObject(productVM);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/products", bodyContent);
            if (response != null)
            {
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<ProductVM>(responseResult);
                    return result;  
                }
            }
            return new ProductVM();
        }

        public async Task<ProductVM> UpdateProduct(ProductVM productVM)
        {
            var content = JsonConvert.SerializeObject(productVM);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/products", bodyContent);
            if(response != null)
            {
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<ProductVM>(responseResult);
                    return result;
                }
            }
            return new ProductVM();
        }

        public async Task<List<ProductVM>> SearchProductByName(string partialName)
        {
            var response = await _httpClient.GetAsync($"api/products?partialName={partialName}");
            if(response != null)
            {
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<List<ProductVM>>(responseResult);
                    return result;
                }
            }
            return new List<ProductVM>();
        }

        public async Task<ProductVM> GetProductById(string productId)
        {
            var response = await _httpClient.GetAsync($"api/products/{productId}");
            if(response != null)
            {
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseResult);
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<ProductVM>(responseResult);
                    return result;
                }
            }
            return new ProductVM();
        }
    }
}
