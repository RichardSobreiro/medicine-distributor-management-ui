using ManagementUI.Services.IServices;
using ManagementUI.ViewModels;
using Newtonsoft.Json;

namespace ManagementUI.Services
{
    public class MeasurementUnitsService : IMeasurementUnitsService
    {
        private readonly HttpClient _httpClient;

        public MeasurementUnitsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MeasurementUnitVM>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/measurement-units");
            string responseResult = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseResult);
            }
            else
            {
                var result = JsonConvert.DeserializeObject<List<MeasurementUnitVM>>(responseResult);
                return result;
            }
        }
    }
}
