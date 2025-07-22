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
            Load += Employee_Click;
            Load += TransportData_Click;
            Load += workOrder_Click;
        }

        // Métodos para Clientes
        private async Task loadClient()
        {
            try
            {
                var listClient = await _tvoAPIService.GetAsync<List<ClientDTO>>("Client/ListClients");
                dgvClients.DataSource = listClient;
                dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los CLientes, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task loadStatusClient()
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
                MessageBox.Show($"Error: NO se listaron los estados para los clientes {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                clearFieldsClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo agregar el cliente. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void mbtnEditClient_Click(object sender, EventArgs e)
        {
            var updatedClient = new ClientDTO
            {
                idClient = int.Parse(txtIdClient.Text),
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
                await _tvoAPIService.updateObject(updatedClient, "Client/UpdateClient", "client");
                await loadClient();
                clearFieldsClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo actualizar el cliente. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClients.Rows[e.RowIndex];
                txtIdClient.Text = row.Cells["idClient"].Value.ToString();
                txtNUIClient.Text = row.Cells["nui"].Value.ToString();
                txtFirstNameClient.Text = row.Cells["firstName"].Value.ToString();
                txtLastNameClient.Text = row.Cells["lastName"].Value.ToString();
                txtPhoneClient.Text = row.Cells["phone"].Value.ToString();
                txtMailClient.Text = row.Cells["mail"].Value.ToString();
                txtAddressClient.Text = row.Cells["addressClient"].Value.ToString();
                txtPasswordClient.Text = row.Cells["passwordClient"].Value.ToString();
                if (row.Cells["idClientStatus"].Value != null)
                {
                    mcbStatusClient.SelectedValue = row.Cells["idClientStatus"].Value;
                }
                else
                {
                    mcbStatusClient.SelectedIndex = -1; // Si no hay valor, deselecciona el combo
                }
            }
        }
        private void clearFieldsClient()
        {
            txtIdClient.Clear();
            txtNUIClient.Clear();
            txtFirstNameClient.Clear();
            txtLastNameClient.Clear();
            txtPhoneClient.Clear();
            txtMailClient.Clear();
            txtAddressClient.Clear();
            txtPasswordClient.Clear();
            mcbStatusClient.SelectedIndex = -1; // Desselecciona el combo
        }
        private void mbtnClearClient_Click(object sender, EventArgs e)
        {
            clearFieldsClient();
        }


        //Métodos para Empleados
        private async Task listRolEmployee()
        {
            try
            {
                var listRolEmployee = await _tvoAPIService.GetAsync<List<RolEmployeeDTO>>("RolEmployee/ListRolEmployee");
                mcbRolEmployee.DataSource = listRolEmployee;
                mcbRolEmployee.DisplayMember = "descriptionRol";
                mcbRolEmployee.ValueMember = "idRolEmployee";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los roles para los empleados, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task listSpecialties()
        {
            try
            {
                var listSpecialties = await _tvoAPIService.GetAsync<List<SpecialtiesDTO>>("Specialties/ListSpecialities");
                mcbSpecialtiesEmployee.DataSource = listSpecialties;
                mcbSpecialtiesEmployee.DisplayMember = "specialty";
                mcbSpecialtiesEmployee.ValueMember = "idSpecialties";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron las especialidades, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task loadEmployees()
        {
            try
            {
                var listEmployees = await _tvoAPIService.GetAsync<List<EmployeeDTO>>("Employee/ListEmployee");
                dgvEmployee.DataSource = listEmployees;
                dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los CLientes, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Employee_Click(object sender, EventArgs e)
        {
            await listRolEmployee();
            await listSpecialties();
            await loadEmployees();
        }

        private void ClearFieldsEmployee()
        {
            txtIdEmployee.Clear();
            txtNUIEmployee.Clear();
            txtFirstNameEmployee.Clear();
            txtLastNameEmployee.Clear();
            txtPhoneEmployee.Clear();
            txtMailEmployee.Clear();
            txtAddressEmployee.Clear();
            mcbRolEmployee.SelectedIndex = -1; // Desselecciona el combo
            mcbSpecialtiesEmployee.SelectedIndex = -1; // Desselecciona el combo
        }

        private void btnClearEmployee_Click(object sender, EventArgs e)
        {
            ClearFieldsEmployee();
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];
                txtIdEmployee.Text = row.Cells["idEmployee"].Value.ToString();
                txtNUIEmployee.Text = row.Cells["nui"].Value.ToString();
                txtFirstNameEmployee.Text = row.Cells["firstName"].Value.ToString();
                txtLastNameEmployee.Text = row.Cells["lastName"].Value.ToString();
                txtPhoneEmployee.Text = row.Cells["phone"].Value.ToString();
                txtMailEmployee.Text = row.Cells["mail"].Value.ToString();
                txtAddressEmployee.Text = row.Cells["addressEmp"].Value.ToString();
                if (row.Cells["idRolEmployee"].Value != null)
                {
                    mcbRolEmployee.SelectedValue = row.Cells["idRolEmployee"].Value;
                }
                else
                {
                    mcbRolEmployee.SelectedIndex = -1; // Si no hay valor, deselecciona el combo
                }
                if (row.Cells["idSpecialties"].Value != null)
                {
                    mcbSpecialtiesEmployee.SelectedValue = row.Cells["idSpecialties"].Value;
                }
                else
                {
                    mcbSpecialtiesEmployee.SelectedIndex = -1; // Si no hay valor, deselecciona el combo
                }
            }
        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var newEmployee = new EmployeeDTO
            {
                nui = txtNUIEmployee.Text,
                firstName = txtFirstNameEmployee.Text,
                lastName = txtLastNameEmployee.Text,
                phone = txtPhoneEmployee.Text,
                mail = txtMailEmployee.Text,
                addressEmp = txtAddressEmployee.Text,
                idRolEmployee = mcbRolEmployee.SelectedIndex == -1 ? null : (int?)mcbRolEmployee.SelectedValue,
                idSpecialties = mcbSpecialtiesEmployee.SelectedIndex == -1 ? null : (int?)mcbSpecialtiesEmployee.SelectedValue
            };
            try
            {
                await _tvoAPIService.insertObject(newEmployee, "Employee/InsertEmployee", "employee");
                await loadEmployees();
                ClearFieldsEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo agregar el empleado. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditEmployee_Click(object sender, EventArgs e)
        {
            var editEmployee = new EmployeeDTO
            {
                idEmployee = int.Parse(txtIdEmployee.Text),
                nui = txtNUIEmployee.Text,
                firstName = txtFirstNameEmployee.Text,
                lastName = txtLastNameEmployee.Text,
                phone = txtPhoneEmployee.Text,
                mail = txtMailEmployee.Text,
                addressEmp = txtAddressEmployee.Text,
                idRolEmployee = mcbRolEmployee.SelectedIndex == -1 ? null : (int?)mcbRolEmployee.SelectedValue,
                idSpecialties = mcbSpecialtiesEmployee.SelectedIndex == -1 ? null : (int?)mcbSpecialtiesEmployee.SelectedValue
            };
            try
            {
                await _tvoAPIService.updateObject(editEmployee, "Employee/UpdateEmployee", "employee");
                await loadEmployees();
                ClearFieldsEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo modificar el empleado. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos para Unidades de transporte y tipos
        private async Task listTypeTransport()
        {
            try
            {
                var listTypeTransport = await _tvoAPIService.GetAsync<List<TransportDTO>>("Transport/ListTransport");
                mcbTypeTransTransportData.DataSource = listTypeTransport;
                mcbTypeTransTransportData.DisplayMember = "typeTransport";
                mcbTypeTransTransportData.ValueMember = "idTransport";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron los tipos de transporte, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task listCooperatives()
        {
            try
            {
                var listCooperatives = await _tvoAPIService.GetAsync<List<CooperativeDTO>>("Cooperative/ListCooperatives");
                mcbCoopTransData.DataSource = listCooperatives;
                mcbCoopTransData.DisplayMember = "nameCooperative";
                mcbCoopTransData.ValueMember = "idCooperative";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron las cooperativas, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task loadTransportData()
        {
            try
            {
                var listTransportData = await _tvoAPIService.GetAsync<List<TransportDataDTO>>("TransportData/ListTransportData");
                dgvTransportData.DataSource = listTransportData;
                dgvTransportData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron los datos de transporte, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task listOwners()
        {
            try
            {
                var listOwners = await _tvoAPIService.GetAsync<List<ClientDTO>>("Client/ListClients");

                // Crear nueva lista con nombre completo y mantener el ID
                var ownersWithFullName = listOwners.Select(owner => new
                {
                    FullName = $"{owner.firstName} {owner.lastName}", // Concatenación
                    owner.idClient // Mantenemos el ID para ValueMember
                }).ToList();

                // Asignar al ComboBox
                mcbClientsTransportData.DataSource = ownersWithFullName;
                mcbClientsTransportData.DisplayMember = "FullName"; // Mostrar nombre completo
                mcbClientsTransportData.ValueMember = "idClient";   // ID como valor interno
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron los propietarios. Detalle: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private async void TransportData_Click(object sender, EventArgs e)
        {
            await listTypeTransport();
            await listCooperatives();
            await listOwners();
            await loadTransportData();
        }

        private void dgvTransportData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransportData.Rows[e.RowIndex];
                txtIdTransportData.Text = row.Cells["idTransportData"].Value.ToString();
                txtPlateTransportData.Text = row.Cells["plate"].Value.ToString();
                txtChassisTransportData.Text = row.Cells["chassis"].Value.ToString();
                txtNumTransportData.Text = row.Cells["num"].Value.ToString();
                if (row.Cells["idTransport"].Value != null)
                {
                    mcbTypeTransTransportData.SelectedValue = row.Cells["idTransport"].Value;
                }
                else
                {
                    mcbTypeTransTransportData.SelectedIndex = -1;
                }
                if (row.Cells["idCooperative"].Value != null)
                {
                    mcbCoopTransData.SelectedValue = row.Cells["idCooperative"].Value;
                }
                else
                {
                    mcbCoopTransData.SelectedIndex = -1;
                }
                if (row.Cells["idClient"].Value != null)
                {
                    mcbClientsTransportData.SelectedValue = row.Cells["idClient"].Value;
                }
                else
                {
                    mcbClientsTransportData.SelectedIndex = -1;
                }
            }
        }

        private void clearFieldsTransportData()
        {
            txtIdTransportData.Clear();
            txtPlateTransportData.Clear();
            txtChassisTransportData.Clear();
            txtNumTransportData.Clear();
            mcbTypeTransTransportData.SelectedIndex = -1; // Desselecciona el combo
            mcbCoopTransData.SelectedIndex = -1; // Desselecciona el combo
            mcbClientsTransportData.SelectedIndex = -1; // Desselecciona el combo
        }

        private async void btnAddTransportData_Click(object sender, EventArgs e)
        {
            var newTransportData = new TransportDataDTO
            {
                plate = txtPlateTransportData.Text,
                chassis = txtChassisTransportData.Text,
                num = int.TryParse(txtNumTransportData.Text, out int num) ? num : 0,
                idTransport = mcbTypeTransTransportData.SelectedIndex == -1 ? null : (int?)mcbTypeTransTransportData.SelectedValue,
                idCooperative = mcbCoopTransData.SelectedIndex == -1 ? null : (int?)mcbCoopTransData.SelectedValue,
                idClient = mcbClientsTransportData.SelectedIndex == -1 ? null : (int?)mcbClientsTransportData.SelectedValue
            };
            try
            {
                await _tvoAPIService.insertObject(newTransportData, "TransportData/InsertTransportData", "transportData");
                await loadTransportData();
                clearFieldsTransportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se insedrtaron los datos de la unidad. Detalle: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private async void btnEditTransportData_Click(object sender, EventArgs e)
        {
            var updatedTransportData = new TransportDataDTO
            {
                idTransportData = int.Parse(txtIdTransportData.Text),
                plate = txtPlateTransportData.Text,
                chassis = txtChassisTransportData.Text,
                num = int.TryParse(txtNumTransportData.Text, out int num) ? num : 0,
                idTransport = mcbTypeTransTransportData.SelectedIndex == -1 ? null : (int?)mcbTypeTransTransportData.SelectedValue,
                idCooperative = mcbCoopTransData.SelectedIndex == -1 ? null : (int?)mcbCoopTransData.SelectedValue,
                idClient = mcbClientsTransportData.SelectedIndex == -1 ? null : (int?)mcbClientsTransportData.SelectedValue
            };
            try
            {
                await _tvoAPIService.updateObject(updatedTransportData, "TransportData/UpdateTransportData", "transportData");
                await loadTransportData();
                clearFieldsTransportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo modificar los datos de la unidad. Detalle: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnClearTransportData_Click(object sender, EventArgs e)
        {
            clearFieldsTransportData();
        }

        // Métodos para ordenes de trabajo
        private async Task listOrderStatus()
        {
            try
            {
                var listOrderStatus = await _tvoAPIService.GetAsync<List<OrderStatusDTO>>("OrderStatus/ListOrderStatus");
                mcbOrderStatus.DataSource = listOrderStatus;
                mcbOrderStatus.DisplayMember = "orderStatus1";
                mcbOrderStatus.ValueMember = "idOrderStatus";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron los estados de las ordenes. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task listEmployees()
        {
            try
            {
                var listEmployees = await _tvoAPIService.GetAsync<List<EmployeeDTO>>("Employee/ListEmployee");

                var employeesFullName = listEmployees.Select(employee => new
                {
                    FullName = $"{employee.firstName} {employee.lastName}",
                    employee.idEmployee
                }).ToList();
                mcbEmployeeWO.DataSource = employeesFullName;
                mcbEmployeeWO.DisplayMember = "FullName";
                mcbEmployeeWO.ValueMember = "idEmployee";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron los propietarios. Detalle: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private async Task loadWorkOrders()
        {
            try
            {
                var listWorkOrders = await _tvoAPIService.GetAsync<List<WorkOrderDTO>>("WorkOrder/ListWorkOrders");
                dgvWorkOrders.DataSource = listWorkOrders;
                dgvWorkOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron los datos de transporte, {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void workOrder_Click(object sender, EventArgs e)
        {
            loadWorkOrders();
            listOrderStatus();
            listEmployees();
        }

        private void dgvWorkOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            { 
                DataGridViewRow row = dgvWorkOrders.Rows[e.RowIndex];
            }
        }
    }
}
