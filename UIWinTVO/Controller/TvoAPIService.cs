using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Controller
{
    public class TvoAPIService
    {
        //Variable comunicación API
        private readonly HttpClient _httpClient;
        //Dirección base del API URL
        private string _baseURL;
        public TvoAPIService(string baseURL)
        {
            _baseURL = baseURL.TrimEnd('/');
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string endPoint)
        {
            var route = await _httpClient.GetAsync($"{_baseURL}/{endPoint}");
            route.EnsureSuccessStatusCode();

            var content = await route.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

    }
}
