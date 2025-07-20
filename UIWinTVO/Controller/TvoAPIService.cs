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
        public async Task<T> GetAsync<T>(string endPoint) //-> Metodo genérico para obtener datos de la API select *
        {
            var route = await _httpClient.GetAsync($"{_baseURL}/{endPoint}");
            route.EnsureSuccessStatusCode();

            var content = await route.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content); // -> Deserializa el json a DTO
        }
        public async Task insertObject<T>(T entity, string endPoint, string nameEntity) //-> Metodo genérico para insertar datos a la API
        {
            var json = JsonConvert.SerializeObject(entity); // -> Comvierte el json a DTO
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseURL}/{endPoint}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error : No se puede insertar en {nameEntity}. Detalle: {errorContent}");
            }
        }

    }
}
