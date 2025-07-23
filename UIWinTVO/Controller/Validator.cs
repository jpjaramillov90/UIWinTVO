using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Controller
{
    public class Validator
    {
        private readonly HttpClient _httpClient;
        private string _baseURL;
        public Validator(string baseURL)
        {
            _baseURL = baseURL.TrimEnd('/');
            _httpClient = new HttpClient();
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ContainsOnlyLetters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ') // Permite espacios entre nombres
                    return false;
            }
            return true;
        }

        public static bool ContainsOnlyNumbers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public static bool IsValidNUI(string nui)
        {
            return !string.IsNullOrWhiteSpace(nui) && nui.Length >= 5 && nui.Length < 15;
        }
        public static bool IsValidPlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate))
                return false;
            if (plate.Length < 6 || plate.Length > 7)
                return false;
            return plate.All(c => char.IsLetterOrDigit(c));
        }
    }
}
