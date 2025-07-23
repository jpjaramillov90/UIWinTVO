using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIWinTVO.Model.DTO;

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
            var json = JsonConvert.SerializeObject(entity); // -> Convierte el json a DTO
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseURL}/{endPoint}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error : No se puede insertar en {nameEntity}. Detalle: {errorContent}");
            }
        }

        public async Task updateObject<T>(T entity, string endPoint, string nameEntity) //-> Metodo genérico para actualizar datos a la API
        {
            var json = JsonConvert.SerializeObject(entity); // -> Convierte el json a DTO
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseURL}/{endPoint}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error : No se puede actualizar en {nameEntity}. Detalle: {errorContent}");
            }
        }
        public async Task<List<SearchBudgetDTO>> searchNUIBudget(string endPoint, string nui)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseURL}/{endPoint}/{nui}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SearchBudgetDTO>>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al buscar presupuestos para NUI {nui}: {ex.Message}", ex);
            }
        }

        public async Task<decimal?> GetTotalBudgetByNui(string endPoint, string nui)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseURL}/{endPoint}/{nui}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TotalBudgetDTO>(content);

                return result?.totalBudget;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al obtener el total del presupuesto para NUI {nui}: {ex.Message}", ex);
            }
        }

        public async Task<bool> IsChassisExists(string endPoint, string chassis)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseURL}/{endPoint}/{chassis}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                // Suponiendo que el endpoint devuelve "true" o "false" como texto plano
                return bool.TryParse(content, out bool exists) && exists;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al validar el chasis {chassis}: {ex.Message}", ex);
            }
        }

    }
}   
