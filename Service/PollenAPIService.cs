using System.Net.Http;
using System.Threading.Tasks;

namespace Gruppe1.Service
{
    public class PollenAPIService : IPollenAPIService
    {
        private readonly HttpClient _httpClient;

        public PollenAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetPollenForecastAsync()
        {
            var url = "https://pollen.googleapis.com/v1/forecast:lookup?location.latitude=59.26754&location.longitude=10.40762&days=5&key=AIzaSyCcJ3vf6FXeMkfgdGuJytfRuh6PQ_tDJ7U";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}