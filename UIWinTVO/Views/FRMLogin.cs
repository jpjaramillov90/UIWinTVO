using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIWinTVO.Controller;
using UIWinTVO.Model.DTO;

namespace UIWinTVO.Views
{
    public partial class FRMLogin : MaterialSkin.Controls.MaterialForm
    {
        private readonly LoginAPIService _loginAPIService;
        private string _baseURL;
        public FRMLogin()
        {
            InitializeComponent();
            _baseURL = ConfigurationManager.AppSettings["ApiBaseURL"];
            _loginAPIService = new LoginAPIService(_baseURL);
            ConfigureForm();
        }
        private void ConfigureForm()
        {
            txtLoginPassword.UseSystemPasswordChar = true;

            this.AcceptButton = btnLogin;

            txtbLoginMail.Focus();
        }

        private async  void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                ShowLoadingState(true);

                var loginDto = new LoginDTO
                {
                    Mail = txtbLoginMail.Text.Trim(),
                    PasswordClient = txtLoginPassword.Text
                };

                var response = await _loginAPIService.AuthenticateAsync(loginDto);

                if (response.IsSuccessStatusCode)
                {
                    ProcessSuccessfulLogin();
                }
                else
                {
                    ShowLoginError(await response.Content.ReadAsStringAsync());
                }
            }
            catch (HttpRequestException httpEx)
            {
                ShowConnectionError(httpEx.Message);
            }
            catch (Exception ex)
            {
                ShowUnexpectedError(ex.Message);
            }
            finally
            {
                ShowLoadingState(false);
            }

        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtbLoginMail.Text))
            {
                MessageBox.Show("Por favor ingrese su correo electrónico",
                              "Campo requerido",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtbLoginMail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLoginPassword.Text))
            {
                MessageBox.Show("Por favor ingrese su contraseña",
                              "Campo requerido",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtLoginPassword.Focus();
                return false;
            }

            if (!IsValidEmail(txtbLoginMail.Text))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido",
                              "Formato incorrecto",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtbLoginMail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
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

        private void ShowLoadingState(bool isLoading)
        {
            btnLogin.Enabled = !isLoading;
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        }

        private void ProcessSuccessfulLogin()
        {
            var mainForm = new StartApp();
            mainForm.Show();
            this.Hide();
        }

        private void ShowLoginError(string errorMessage)
        {
            MessageBox.Show($"Error en autenticación: {errorMessage}",
                          "Credenciales incorrectas",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            txtLoginPassword.SelectAll();
            txtLoginPassword.Focus();
        }

        private void ShowConnectionError(string message)
        {
            MessageBox.Show($"No se pudo conectar al servidor: {message}\n\nVerifique su conexión a internet e intente nuevamente.",
                          "Error de conexión",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
        }

        private void ShowUnexpectedError(string message)
        {
            MessageBox.Show($"Error inesperado: {message}",
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
        }

        // Evento para mostrar/ocultar contraseña
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                txtLoginPassword.UseSystemPasswordChar = !checkBox.Checked;
            }
        }
    }
}
