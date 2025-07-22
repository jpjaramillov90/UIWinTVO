using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UIWinTVO.Model.DTO;

namespace UIWinTVO.Controller
{
    public class LoginAPIService
    {
        private readonly HttpClient _httpClient;
        private string _baseURL;

        public LoginAPIService(string baseURL)
        {
            _baseURL = baseURL;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<HttpResponseMessage> AuthenticateAsync(LoginDTO loginDto)
        {
            try
            {
                // Validación básica del DTO
                if (string.IsNullOrWhiteSpace(loginDto.Mail) || string.IsNullOrWhiteSpace(loginDto.PasswordClient))
                {
                    throw new ArgumentException("Correo electrónico y contraseña son requeridos");
                }

                // Codificar los parámetros para URL
                var encodedEmail = Uri.EscapeDataString(loginDto.Mail);
                var encodedPassword = Uri.EscapeDataString(loginDto.PasswordClient);

                // Construir la URL del endpoint
                var endpoint = $"{_baseURL}/Client/Login/{encodedEmail}/{encodedPassword}";

                // Realizar la solicitud GET
                var response = await _httpClient.GetAsync(endpoint);

                return response;
            }
            catch (Exception ex)
            {
                // Puedes personalizar el manejo de excepciones según tus necesidades
                throw new ApplicationException("Error al autenticar: " + ex.Message, ex);
            }
        }
    }
}
