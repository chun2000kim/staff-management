using Newtonsoft.Json;
using StaffManagement.MVC.Models;
using StaffManagement.MVC.Repositories;
using System.Text;

namespace StaffManagement.MVC.Services
{
    public class StaffRepository : IStaffRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<Staff> _logger;

        public StaffRepository(HttpClient httpClient, ILogger<Staff> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<string> CreateAsync(Staff staff)
        {
            try
            {
                var json = JsonConvert.SerializeObject(staff);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/staff/create", content);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<Staff>>>(result);
                return apiResponse?.Message?? "";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/staff/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("/api/staff");
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Staff>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var wrapperData = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Staff>>>(json);
            return wrapperData?.Data ?? Enumerable.Empty<Staff>();       
        }

        public async Task<Staff?> GetByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/staff/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Staff>(json);
        }

        public async Task<bool> UpdateAsync(string id, Staff staff)
        {
            var json = JsonConvert.SerializeObject(staff);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/staff/{id}", content);
            return response.IsSuccessStatusCode;
        }
    }
}
