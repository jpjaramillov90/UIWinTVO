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
    public partial class FRMBudget : MaterialSkin.Controls.MaterialForm
    {
        private readonly TvoAPIService _tvoAPIService;
        private string _baseURL;
        public FRMBudget()
        {
            InitializeComponent();
            _baseURL = ConfigurationManager.AppSettings["ApiBaseURL"];
            _tvoAPIService = new TvoAPIService(_baseURL);
            Load += FRMBudget_Load;
        }

        private async Task listBudgetStatement()
        {
            try
            {
                var listBudgetStatement = await _tvoAPIService.GetAsync<List<BudgetStatementDTO>>("BudgetStatement/ListBudgetStatements");
                mcbBudgetStatementBudget.DataSource = listBudgetStatement;
                mcbBudgetStatementBudget.DisplayMember = "descriptionStatement";
                mcbBudgetStatementBudget.ValueMember = "idBudgetStatement";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los estados del presupuesto, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task listBrands()
        {
            try
            {
                var listBrands = await _tvoAPIService.GetAsync<List<BrandsDTO>>("Brands/ListBrands");
                mcbBrandsBudget.DataSource = listBrands;
                mcbBrandsBudget.DisplayMember = "brand";
                mcbBrandsBudget.ValueMember = "idBrands";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron las marcas. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task listPlates()
        {
            try
            {
                var listPlates = await _tvoAPIService.GetAsync<List<TransportDataDTO>>("TransportData/ListTransportData");
                mcbPlateTransDataBudget.DataSource = listPlates;
                mcbPlateTransDataBudget.DisplayMember = "plate";
                mcbPlateTransDataBudget.ValueMember = "idTransportData";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron las placas. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task loadBudgets()
        {
            try
            {
                // Obtener listas necesarias de la API
                var listBudgets = await _tvoAPIService.GetAsync<List<BudgetDTO>>("Budget/ListBudget");
                var listBudgetStatements = await _tvoAPIService.GetAsync<List<BudgetStatementDTO>>("BudgetStatement/ListBudgetStatements");
                var listBrands = await _tvoAPIService.GetAsync<List<BrandsDTO>>("Brands/ListBrands");
                var listTransportData = await _tvoAPIService.GetAsync<List<TransportDataDTO>>("TransportData/ListTransportData");

                // Crear diccionarios para mapear IDs a descripciones
                var budgetStatementDescriptions = listBudgetStatements.ToDictionary(
                    bs => bs.idBudgetStatement,
                    bs => bs.descriptionStatement
                );

                var brandNames = listBrands.ToDictionary(
                    b => b.idBrands,
                    b => b.brand
                );

                var transportPlates = listTransportData.ToDictionary(
                    td => td.idTransportData,
                    td => td.plate
                );

                // Crear la lista para mostrar en el DataGridView
                var displayBudgets = listBudgets.Select(b => new
                {
                    b.idBudget,
                    b.idWorkOrder,
                    idTransportData = b.idTransportData,
                    TransportPlate = b.idTransportData.HasValue && transportPlates.ContainsKey(b.idTransportData.Value)
                                    ? transportPlates[b.idTransportData.Value]
                                    : "No asignado",
                    idBudgetStatement = b.idBudgetStatement,
                    BudgetStatement = b.idBudgetStatement.HasValue && budgetStatementDescriptions.ContainsKey(b.idBudgetStatement.Value)
                                       ? budgetStatementDescriptions[b.idBudgetStatement.Value]
                                       : "Desconocido",
                    idBrands = b.idBrands,
                    BrandName = b.idBrands.HasValue && brandNames.ContainsKey(b.idBrands.Value)
                               ? brandNames[b.idBrands.Value]
                               : "No especificada",
                    b.issueDate,
                    b.validUntil,
                    b.comments
                }).ToList();

                // Asignar datos al DataGridView
                dgvBudgets.DataSource = displayBudgets;
                dgvBudgets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ocultar columnas de IDs
                if (dgvBudgets.Columns.Contains("idTransportData"))
                    dgvBudgets.Columns["idTransportData"].Visible = false;

                if (dgvBudgets.Columns.Contains("idBudgetStatement"))
                    dgvBudgets.Columns["idBudgetStatement"].Visible = false;

                if (dgvBudgets.Columns.Contains("idBrands"))
                    dgvBudgets.Columns["idBrands"].Visible = false;

                // Personalizar nombres de columnas
                if (dgvBudgets.Columns.Contains("idBudget"))
                    dgvBudgets.Columns["idBudget"].HeaderText = "ID Presupuesto";

                if (dgvBudgets.Columns.Contains("idWorkOrder"))
                    dgvBudgets.Columns["idWorkOrder"].HeaderText = "ID Orden Trabajo";

                if (dgvBudgets.Columns.Contains("TransportPlate"))
                    dgvBudgets.Columns["TransportPlate"].HeaderText = "Placa Vehículo";

                if (dgvBudgets.Columns.Contains("BudgetStatement"))
                    dgvBudgets.Columns["BudgetStatement"].HeaderText = "Estado Presupuesto";

                if (dgvBudgets.Columns.Contains("BrandName"))
                    dgvBudgets.Columns["BrandName"].HeaderText = "Marca";

                if (dgvBudgets.Columns.Contains("issueDate"))
                    dgvBudgets.Columns["issueDate"].HeaderText = "Fecha Emisión";

                if (dgvBudgets.Columns.Contains("validUntil"))
                    dgvBudgets.Columns["validUntil"].HeaderText = "Válido Hasta";

                if (dgvBudgets.Columns.Contains("comments"))
                    dgvBudgets.Columns["comments"].HeaderText = "Comentarios";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los presupuestos. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FRMBudget_Load(object sender, EventArgs e)
        {
            listBudgetStatement();
            listBrands();
            listPlates();
            loadBudgets();
        }

        private void btnClearBudget_Click(object sender, EventArgs e)
        {
            txtIDBudget.Clear();
            txtIdWOBudget.Clear();
            txtComentsBudget.Clear();
            mcbPlateTransDataBudget.SelectedIndex = -1;
            mcbBrandsBudget.SelectedIndex = -1;
            mcbBudgetStatementBudget.SelectedIndex = -1;
        }

        private async void btnAddBudget_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdWOBudget.Text) ||
        mcbPlateTransDataBudget.SelectedIndex == -1 ||
        mcbBrandsBudget.SelectedIndex == -1 ||
        mcbBudgetStatementBudget.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos obligatorios deben ser completados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el ID de orden de trabajo sea numérico
            if (!Validator.ContainsOnlyNumbers(txtIdWOBudget.Text))
            {
                MessageBox.Show("El ID de orden de trabajo solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener fechas (issueDate = fecha actual, validUntil = fecha actual + 15 días)
            //DateOnly issueDate = DateOnly.FromDateTime(DateTime.Today);
            //DateOnly validUntil = issueDate.AddDays(15);

            // Crear nuevo objeto BudgetDTO
            var newBudget = new BudgetDTO
            {
                idWorkOrder = int.Parse(txtIdWOBudget.Text),
                idTransportData = (int?)mcbPlateTransDataBudget.SelectedValue,
                idBudgetStatement = (int?)mcbBudgetStatementBudget.SelectedValue,
                idBrands = (int?)mcbBrandsBudget.SelectedValue,
                //issueDate = issueDate,
                //validUntil = validUntil,
                comments = txtComentsBudget.Text
            };

            try
            {
                // Insertar el nuevo presupuesto
                await _tvoAPIService.insertObject(newBudget, "Budget/InsertBudget", "budget");

                // Recargar la lista de presupuestos
                await loadBudgets();

                // Limpiar campos
                btnClearBudget_Click(sender, e);

                MessageBox.Show("Presupuesto agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo agregar el presupuesto. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBudgets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBudgets.Rows[e.RowIndex];

                // Asignar valores a los campos del formulario
                txtIDBudget.Text = row.Cells["idBudget"].Value?.ToString() ?? "";
                txtIdWOBudget.Text = row.Cells["idWorkOrder"].Value?.ToString() ?? "";
                txtComentsBudget.Text = row.Cells["comments"].Value?.ToString() ?? "";

                // Manejar los ComboBox con valores posibles nulos
                if (row.Cells["idTransportData"].Value != null)
                {
                    mcbPlateTransDataBudget.SelectedValue = row.Cells["idTransportData"].Value;
                }
                else
                {
                    mcbPlateTransDataBudget.SelectedIndex = -1;
                }

                if (row.Cells["idBudgetStatement"].Value != null)
                {
                    mcbBudgetStatementBudget.SelectedValue = row.Cells["idBudgetStatement"].Value;
                }
                else
                {
                    mcbBudgetStatementBudget.SelectedIndex = -1;
                }

                if (row.Cells["idBrands"].Value != null)
                {
                    mcbBrandsBudget.SelectedValue = row.Cells["idBrands"].Value;
                }
                else
                {
                    mcbBrandsBudget.SelectedIndex = -1;
                }
            }
        }

        private async void btnEditBudget_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDBudget.Text))
            {
                MessageBox.Show("Debe seleccionar un presupuesto para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtIdWOBudget.Text) ||
                mcbPlateTransDataBudget.SelectedIndex == -1 ||
                mcbBrandsBudget.SelectedIndex == -1 ||
                mcbBudgetStatementBudget.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos obligatorios deben ser completados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el ID de orden de trabajo sea numérico
            if (!Validator.ContainsOnlyNumbers(txtIdWOBudget.Text))
            {
                MessageBox.Show("El ID de orden de trabajo solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateOnly issueDate = DateOnly.FromDateTime(DateTime.Today);
            DateOnly validUntil = issueDate.AddDays(15);

            try
            {
                // Crear objeto con los datos actualizados
                var updatedBudget = new BudgetDTO
                {
                    idBudget = int.Parse(txtIDBudget.Text),
                    idWorkOrder = int.Parse(txtIdWOBudget.Text),
                    idTransportData = (int?)mcbPlateTransDataBudget.SelectedValue,
                    idBudgetStatement = (int?)mcbBudgetStatementBudget.SelectedValue,
                    idBrands = (int?)mcbBrandsBudget.SelectedValue,
                    issueDate = issueDate,
                    validUntil = validUntil,
                    comments = txtComentsBudget.Text
                };

                // Llamar al servicio para actualizar
                await _tvoAPIService.updateObject(updatedBudget,"Budget/UpdateBudget" , "budget");

                // Recargar la lista de presupuestos
                await loadBudgets();

                MessageBox.Show("Presupuesto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo actualizar el presupuesto. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
