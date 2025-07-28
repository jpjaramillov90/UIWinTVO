using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIWinTVO.Controller;
using UIWinTVO.Model.DTO;

namespace UIWinTVO.Views
{
    public partial class FRMOrderDetails : MaterialSkin.Controls.MaterialForm
    {
        private readonly TvoAPIService _tvoAPIService;
        private string _baseURL;
        public FRMOrderDetails()
        {
            InitializeComponent();
            _baseURL = ConfigurationManager.AppSettings["ApiBaseURL"];
            _tvoAPIService = new TvoAPIService(_baseURL);
            InitializeForm();
        }

        private async Task listServices()
        {
            try
            {
                var listServices = await _tvoAPIService.GetAsync<List<ServicesDTO>>("Services/ListServices");

                mcbServiceDescriptionOrderDetails.DataSource = listServices;
                mcbServiceDescriptionOrderDetails.DisplayMember = "descriptionServices";
                mcbServiceDescriptionOrderDetails.ValueMember = "idService";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron los servicios. Detalle: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private async void InitializeForm()
        {
            try
            {
                await listServices();

                // Configurar DataGridView vacío
                dgvDetailsOrderDetails.DataSource = new List<GetServicesByWorkOrderDTO>();
                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar formulario: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private async void btnAddDetails_Click(object sender, EventArgs e)
        {
            // Validar que el ID de orden sea válido
            if (!int.TryParse(txtIdOTOrderDetails.Text, out int idWorkOrder) || idWorkOrder <= 0)
            {
                MessageBox.Show("Ingrese un ID de orden de trabajo válido",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtIdOTOrderDetails.Focus();
                return;
            }

            // Validar que se haya seleccionado un servicio
            if (mcbServiceDescriptionOrderDetails.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un servicio de la lista",
                               "Validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                mcbServiceDescriptionOrderDetails.Focus();
                return;
            }

            try
            {
                // Obtener el servicio seleccionado
                var selectedService = (ServicesDTO)mcbServiceDescriptionOrderDetails.SelectedItem;

                // Crear el objeto para insertar
                var newOrderDetail = new OrderDetailsDTO
                {
                    idWorkOrder = idWorkOrder,
                    idService = selectedService.idService
                };

                // Insertar usando el método genérico
                await _tvoAPIService.insertObject(
                    newOrderDetail,
                    "OrderDetails/InsertOrderDetail",
                    "OrderDetails");

                // Actualizar el DataGridView con los servicios asociados
                await RefreshServicesGrid(idWorkOrder);

                MessageBox.Show("Detalle agregado correctamente",
                               "Éxito",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar detalle: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private async Task RefreshServicesGrid(int idWorkOrder)
        {
            try
            {
                var services = await _tvoAPIService.GetServicesByWorkOrderDTO(
                    "Services/GetServicesByWorkOrder",
                    idWorkOrder);

                dgvDetailsOrderDetails.DataSource = services;
                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la lista: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
        private void ConfigureDataGridViewColumns()
        {
            dgvDetailsOrderDetails.AutoGenerateColumns = false;
            dgvDetailsOrderDetails.Columns.Clear();

            // Configurar columna para mostrar solo la descripción del servicio
            DataGridViewTextBoxColumn descColumn = new DataGridViewTextBoxColumn();
            descColumn.DataPropertyName = "Description";
            descColumn.HeaderText = "Servicios Asociados";
            descColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descColumn.ReadOnly = true;

            dgvDetailsOrderDetails.Columns.Add(descColumn);
        }

        private void btnClearOrderDetails_Click(object sender, EventArgs e)
        {
            txtIdOTOrderDetails.Clear();
            mcbServiceDescriptionOrderDetails.SelectedIndex = -1;
        }
    }
}
