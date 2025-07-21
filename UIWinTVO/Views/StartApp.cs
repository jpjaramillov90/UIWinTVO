using MaterialSkin;
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
    public partial class StartApp : MaterialSkin.Controls.MaterialForm
    {
        private readonly TvoAPIService _tvoAPIService;
        private string _baseURL;
        public StartApp()
        {
            InitializeComponent();
            _baseURL = ConfigurationManager.AppSettings["ApiBaseURL"];
            _tvoAPIService = new TvoAPIService(_baseURL);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue300, Accent.LightBlue700, TextShade.WHITE);

            Load += tabPage2_Click;

        }

        // Metodos para Clientes
        public async Task loadClient()
        {
            try
            {
                var listClient = await _tvoAPIService.GetAsync<List<ClientDTO>>("Client/ListClients");
                dgvClients.DataSource = listClient;
                dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los CLientes {ex.Message}");
            }
        }

        public async Task loadStatusClient()
        {
            try
            {
                var listStatusClient = await _tvoAPIService.GetAsync<List<ClientStatusDTO>>("ClientStatus/ListClientStatus");
                mcbStatusClient.DataSource = listStatusClient;
                mcbStatusClient.DisplayMember = "clientStatus1";
                mcbStatusClient.ValueMember = "idClientStatus";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los estados para los clientes {ex.Message}");
            }
        }


        private async void tabPage2_Click(object sender, EventArgs e)
        {
            await loadClient();
            await loadStatusClient();
        }

        private async void mbtnAddClient_Click(object sender, EventArgs e)
        {
            var newClient = new ClientDTO
            {
                nui = txtNUIClient.Text,
                firstName = txtFirstNameClient.Text,
                lastName = txtLastNameClient.Text,
                phone = txtPhoneClient.Text,
                mail = txtMailClient.Text,
                addressClient = txtAddressClient.Text,
                passwordClient = txtPasswordClient.Text,
                idClientStatus = mcbStatusClient.SelectedIndex == -1 ? null : (int?)mcbStatusClient.SelectedValue
            };
            try
            {
                await _tvoAPIService.insertObject(newClient, "Client/InsertClient", "client");
                await loadClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo agregar el cliente. Detalle: {ex.Message}");
            }
        }        //Metodos para Empleados
    }
}
