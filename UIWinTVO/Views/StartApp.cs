using MaterialSkin;
using Microsoft.VisualBasic.Logging;
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
                var listStatusClient = await _tvoAPIService.GetAsync<List<ClientStatusDTO>>("ClientStatus/ListClientStatus");

                var clientStatusDescriptions = listStatusClient.ToDictionary(
                    cs => cs.idClientStatus,
                    cs => cs.clientStatus1 
                );

                var displayClients = listClient.Select(c => new
                {
                    c.idClient,
                    c.nui,
                    c.firstName,
                    c.lastName,
                    c.phone,
                    c.mail,
                    c.addressClient,
                    c.passwordClient, 
                    idClientStatus = c.idClientStatus,
                    ClientStatusName = c.idClientStatus.HasValue && clientStatusDescriptions.ContainsKey(c.idClientStatus.Value)
                                       ? clientStatusDescriptions[c.idClientStatus.Value]
                                       : "Desconocido" 
                }).ToList();

                dgvClients.DataSource = displayClients;
                dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvClients.Columns.Contains("idClientStatus"))
                    dgvClients.Columns["idClientStatus"].Visible = false;

                if (dgvClients.Columns.Contains("passwordClient"))
                    dgvClients.Columns["passwordClient"].Visible = false;

                if (dgvClients.Columns.Contains("idClient"))
                    dgvClients.Columns["idClient"].HeaderText = "Id Cliente";
                if (dgvClients.Columns.Contains("nui"))
                    dgvClients.Columns["nui"].HeaderText = "NUI";
                if (dgvClients.Columns.Contains("firstName"))
                    dgvClients.Columns["firstName"].HeaderText = "Nombre";
                if (dgvClients.Columns.Contains("lastName"))
                    dgvClients.Columns["lastName"].HeaderText = "Apellido";
                if (dgvClients.Columns.Contains("phone"))
                    dgvClients.Columns["phone"].HeaderText = "Teléfono";
                if (dgvClients.Columns.Contains("mail"))
                    dgvClients.Columns["mail"].HeaderText = "Correo";
                if (dgvClients.Columns.Contains("addressClient"))
                    dgvClients.Columns["addressClient"].HeaderText = "Dirección";

                if (dgvClients.Columns.Contains("ClientStatusName"))
                    dgvClients.Columns["ClientStatusName"].HeaderText = "Estado Cliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los Clientes. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var listRolEmployee = await _tvoAPIService.GetAsync<List<RolEmployeeDTO>>("RolEmployee/ListRolEmployee");
                var listSpecialties = await _tvoAPIService.GetAsync<List<SpecialtiesDTO>>("Specialties/ListSpecialities");

                var rolDescriptions = listRolEmployee.ToDictionary(
                    rol => rol.idRolEmployee,
                    rol => rol.descriptionRol
                );

                var specialtyDescriptions = listSpecialties.ToDictionary(
                    spec => spec.idSpecialties,
                    spec => spec.specialty
                );

                var displayEmployees = listEmployees.Select(emp => new
                {
                    emp.idEmployee,
                    // Incluir firstName y lastName para que el CellContentClick los encuentre
                    emp.firstName,   // <-- Añadir esta línea
                    emp.lastName,    // <-- Añadir esta línea
                    FullName = $"{emp.firstName} {emp.lastName}", // Esta es la columna que se mostrará
                    emp.nui,
                    emp.phone,
                    emp.mail,
                    emp.addressEmp,

                    idRolEmployee = emp.idRolEmployee,
                    idSpecialties = emp.idSpecialties,

                    RolName = emp.idRolEmployee.HasValue && rolDescriptions.ContainsKey(emp.idRolEmployee.Value)
                              ? rolDescriptions[emp.idRolEmployee.Value]
                              : "Desconocido",
                    SpecialtyName = emp.idSpecialties.HasValue && specialtyDescriptions.ContainsKey(emp.idSpecialties.Value)
                                    ? specialtyDescriptions[emp.idSpecialties.Value]
                                    : "Desconocida"
                }).ToList();

                dgvEmployee.DataSource = displayEmployees;
                dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ocultar las columnas de ID y las de firstName/lastName si solo quieres ver FullName
                if (dgvEmployee.Columns.Contains("idRolEmployee"))
                    dgvEmployee.Columns["idRolEmployee"].Visible = false;
                if (dgvEmployee.Columns.Contains("idSpecialties"))
                    dgvEmployee.Columns["idSpecialties"].Visible = false;
                if (dgvEmployee.Columns.Contains("firstName")) // <-- Ocultar si solo quieres ver FullName
                    dgvEmployee.Columns["firstName"].Visible = false;
                if (dgvEmployee.Columns.Contains("lastName"))  // <-- Ocultar si solo quieres ver FullName
                    dgvEmployee.Columns["lastName"].Visible = false;

                // Renombrar las cabeceras de las columnas visibles
                if (dgvEmployee.Columns.Contains("idEmployee"))
                    dgvEmployee.Columns["idEmployee"].HeaderText = "Id Empleado";
                if (dgvEmployee.Columns.Contains("FullName"))
                    dgvEmployee.Columns["FullName"].HeaderText = "Nombre Completo";
                if (dgvEmployee.Columns.Contains("nui"))
                    dgvEmployee.Columns["nui"].HeaderText = "NUI";
                if (dgvEmployee.Columns.Contains("phone"))
                    dgvEmployee.Columns["phone"].HeaderText = "Teléfono";
                if (dgvEmployee.Columns.Contains("mail"))
                    dgvEmployee.Columns["mail"].HeaderText = "Correo";
                if (dgvEmployee.Columns.Contains("addressEmp"))
                    dgvEmployee.Columns["addressEmp"].HeaderText = "Dirección";
                if (dgvEmployee.Columns.Contains("RolName"))
                    dgvEmployee.Columns["RolName"].HeaderText = "Rol";
                if (dgvEmployee.Columns.Contains("SpecialtyName"))
                    dgvEmployee.Columns["SpecialtyName"].HeaderText = "Especialidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: NO se listaron los empleados. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var employees = await _tvoAPIService.GetAsync<List<EmployeeDTO>>("Employee/ListEmployee");
                var orderStatuses = await _tvoAPIService.GetAsync<List<OrderStatusDTO>>("OrderStatus/ListOrderStatus");

                var employeeNames = employees.ToDictionary(
                    emp => emp.idEmployee,
                    emp => $"{emp.firstName} {emp.lastName}"
                );

                var orderStatusDescriptions = orderStatuses.ToDictionary(
                    os => os.idOrderStatus,
                    os => os.orderStatus1 
                );

                var displayWorkOrders = listWorkOrders.Select(wo => new
                {
                    wo.idWorkOrder,
                    idEmployee = wo.idEmployee,
                    idOrderStatus = wo.idOrderStatus,
                    EmployeeName = wo.idEmployee.HasValue && employeeNames.ContainsKey(wo.idEmployee.Value) ? employeeNames[wo.idEmployee.Value] : "Desconocido",
                    OrderStatusDescription = wo.idOrderStatus.HasValue && orderStatusDescriptions.ContainsKey(wo.idOrderStatus.Value) ? orderStatusDescriptions[wo.idOrderStatus.Value] : "Desconocido",
                    wo.descriptionWO,
                    wo.expires
                }).ToList();
                dgvWorkOrders.DataSource = displayWorkOrders;
                dgvWorkOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvWorkOrders.Columns.Contains("idEmployee"))
                    dgvWorkOrders.Columns["idEmployee"].Visible = false;
                if (dgvWorkOrders.Columns.Contains("idOrderStatus"))
                    dgvWorkOrders.Columns["idOrderStatus"].Visible = false;
                if (dgvWorkOrders.Columns.Contains("idWorkOrder"))
                    dgvWorkOrders.Columns["idWorkOrder"].HeaderText = "Id Orden";
                if (dgvWorkOrders.Columns.Contains("EmployeeName"))
                    dgvWorkOrders.Columns["EmployeeName"].HeaderText = "Empleado";
                if (dgvWorkOrders.Columns.Contains("OrderStatusDescription"))
                    dgvWorkOrders.Columns["OrderStatusDescription"].HeaderText = "Estado";
                if (dgvWorkOrders.Columns.Contains("descriptionWO"))
                    dgvWorkOrders.Columns["descriptionWO"].HeaderText = "Descripción";
                if (dgvWorkOrders.Columns.Contains("expires"))
                    dgvWorkOrders.Columns["expires"].HeaderText = "Caducidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se listaron los datos de órdenes de trabajo. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtIdWO.Text = row.Cells["idWorkOrder"].Value.ToString();
                txtDescriptionWO.Text = row.Cells["descriptionWO"].Value.ToString();
                if (row.Cells["idEmployee"].Value != null)
                {
                    mcbEmployeeWO.SelectedValue = row.Cells["idEmployee"].Value;
                }
                else
                {
                    mcbEmployeeWO.SelectedIndex = -1; // Si no hay valor, deselecciona el combo
                }
                if (row.Cells["idOrderStatus"].Value != null)
                {
                    mcbOrderStatus.SelectedValue = row.Cells["idOrderStatus"].Value;
                }
                else
                {
                    mcbOrderStatus.SelectedIndex = -1; // Si no hay valor, deselecciona el combo
                }
                if (DateTime.TryParse(row.Cells["expires"].Value.ToString(), out DateTime expires))
                {
                    dtpExpireWO.Value = expires;
                }
                else
                {
                    dtpExpireWO.Value = DateTime.Now; // Valor por defecto si no se puede parsear
                }
            }
        }

        private void clearFieldsWorkOrder()
        {
            txtIdWO.Clear();
            txtDescriptionWO.Clear();
            mcbEmployeeWO.SelectedIndex = -1;
            mcbOrderStatus.SelectedIndex = -1;
            dtpExpireWO.Value = DateTime.Now;
        }

        private void btnClearWO_Click(object sender, EventArgs e)
        {
            clearFieldsWorkOrder();
        }

        private async void btnAddWO_Click(object sender, EventArgs e)
        {
            var newWorkOrder = new WorkOrderDTO
            {
                descriptionWO = txtDescriptionWO.Text,
                idEmployee = mcbEmployeeWO.SelectedIndex == -1 ? null : (int?)mcbEmployeeWO.SelectedValue,
                idOrderStatus = mcbOrderStatus.SelectedIndex == -1 ? null : (int?)mcbOrderStatus.SelectedValue,
                expires = DateOnly.FromDateTime(dtpExpireWO.Value)
            };
            try
            {
                await _tvoAPIService.insertObject(newWorkOrder, "WorkOrder/InsertWorkOrder", "workOrder");
                loadWorkOrders();
                clearFieldsWorkOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo agregar la orden de trabajo. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnEditWO_Click_1(object sender, EventArgs e)
        {
            var updatedWorkOrder = new WorkOrderDTO
            {
                idWorkOrder = int.Parse(txtIdWO.Text),
                descriptionWO = txtDescriptionWO.Text,
                idEmployee = mcbEmployeeWO.SelectedIndex == -1 ? null : (int?)mcbEmployeeWO.SelectedValue,
                idOrderStatus = mcbOrderStatus.SelectedIndex == -1 ? null : (int?)mcbOrderStatus.SelectedValue,
                expires = DateOnly.FromDateTime(dtpExpireWO.Value)
            };
            try
            {
                await _tvoAPIService.updateObject(updatedWorkOrder, "WorkOrder/UpdateWorkOrder", "workOrder");
                loadWorkOrders();
                clearFieldsWorkOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo modificar la orden de trabajo. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos para presupuestos

    }
}
