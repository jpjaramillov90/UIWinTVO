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
            if (string.IsNullOrWhiteSpace(txtNUIClient.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstNameClient.Text) ||
                    string.IsNullOrWhiteSpace(txtLastNameClient.Text) ||
                    string.IsNullOrWhiteSpace(txtPhoneClient.Text) ||
                    string.IsNullOrWhiteSpace(txtMailClient.Text) ||
                    string.IsNullOrWhiteSpace(txtPasswordClient.Text))
            {
                MessageBox.Show("Todos los campos obligatorios deben ser completados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validator.IsValidNUI(txtNUIClient.Text))
            {
                MessageBox.Show("El NUI/pasaporte debe tener al menos 5 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validator.IsValidEmail(txtMailClient.Text))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ContainsOnlyLetters(txtFirstNameClient.Text) || !Validator.ContainsOnlyLetters(txtLastNameClient.Text))
            {
                MessageBox.Show("El nombre y apellido solo deben contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ContainsOnlyNumbers(txtPhoneClient.Text))
            {
                MessageBox.Show("El teléfono solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                MessageBox.Show("Cliente agregado con exito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo agregar el cliente. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void mbtnEditClient_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (
                string.IsNullOrWhiteSpace(txtNUIClient.Text) ||
                string.IsNullOrWhiteSpace(txtFirstNameClient.Text) ||
                string.IsNullOrWhiteSpace(txtLastNameClient.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneClient.Text) ||
                string.IsNullOrWhiteSpace(txtMailClient.Text) ||
                string.IsNullOrWhiteSpace(txtPasswordClient.Text))
            {
                MessageBox.Show("Todos los campos obligatorios deben ser completados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ContainsOnlyNumbers(txtIdClient.Text))
            {
                MessageBox.Show("El ID debe ser un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.IsValidNUI(txtNUIClient.Text))
            {
                MessageBox.Show("El NUI debe tener al menos 5 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.IsValidEmail(txtMailClient.Text))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ContainsOnlyLetters(txtFirstNameClient.Text) ||
                !Validator.ContainsOnlyLetters(txtLastNameClient.Text))
            {
                MessageBox.Show("El nombre y apellido solo deben contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ContainsOnlyNumbers(txtPhoneClient.Text))
            {
                MessageBox.Show("El teléfono solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPasswordClient.Text.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    mcbStatusClient.SelectedIndex = -1;
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
            mcbStatusClient.SelectedIndex = -1;
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
                    emp.firstName,
                    emp.lastName,
                    FullName = $"{emp.firstName} {emp.lastName}",
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

                if (dgvEmployee.Columns.Contains("idRolEmployee"))
                    dgvEmployee.Columns["idRolEmployee"].Visible = false;
                if (dgvEmployee.Columns.Contains("idSpecialties"))
                    dgvEmployee.Columns["idSpecialties"].Visible = false;
                if (dgvEmployee.Columns.Contains("firstName"))
                    dgvEmployee.Columns["firstName"].Visible = false;
                if (dgvEmployee.Columns.Contains("lastName"))
                    dgvEmployee.Columns["lastName"].Visible = false;

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
            mcbRolEmployee.SelectedIndex = -1;
            mcbSpecialtiesEmployee.SelectedIndex = -1;
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
                    mcbRolEmployee.SelectedIndex = -1;
                }
                if (row.Cells["idSpecialties"].Value != null)
                {
                    mcbSpecialtiesEmployee.SelectedValue = row.Cells["idSpecialties"].Value;
                }
                else
                {
                    mcbSpecialtiesEmployee.SelectedIndex = -1;
                }
            }
        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNUIEmployee.Text) ||
                string.IsNullOrWhiteSpace(txtFirstNameEmployee.Text) ||
                string.IsNullOrWhiteSpace(txtLastNameEmployee.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneEmployee.Text) ||
                string.IsNullOrWhiteSpace(txtMailEmployee.Text))
            {
                MessageBox.Show("Todos los campos marcados como obligatorios deben ser completados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.IsValidEmail(txtMailEmployee.Text))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ContainsOnlyLetters(txtFirstNameEmployee.Text) || !Validator.ContainsOnlyLetters(txtLastNameEmployee.Text))
            {
                MessageBox.Show("El nombre y apellido solo deben contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ContainsOnlyNumbers(txtPhoneEmployee.Text))
            {
                MessageBox.Show("El teléfono solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                MessageBox.Show("Empleado agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo agregar el empleado. Detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(txtNUIEmployee.Text) ||
                string.IsNullOrWhiteSpace(txtFirstNameEmployee.Text) ||
                string.IsNullOrWhiteSpace(txtLastNameEmployee.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneEmployee.Text) ||
                string.IsNullOrWhiteSpace(txtMailEmployee.Text))
            {
                MessageBox.Show("Todos los campos marcados como obligatorios deben ser completados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validator.IsValidNUI(txtNUIEmployee.Text))
            {
                MessageBox.Show("El NUI/pasaporte debe tener al menos 5 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validator.IsValidEmail(txtMailEmployee.Text))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validator.ContainsOnlyLetters(txtFirstNameEmployee.Text) ||
                !Validator.ContainsOnlyLetters(txtLastNameEmployee.Text))
            {
                MessageBox.Show("El nombre y apellido solo deben contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ContainsOnlyNumbers(txtPhoneEmployee.Text))
            {
                MessageBox.Show("El teléfono solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                MessageBox.Show("Empleado modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var listTransports = await _tvoAPIService.GetAsync<List<TransportDTO>>("Transport/ListTransport");
                var listCooperatives = await _tvoAPIService.GetAsync<List<CooperativeDTO>>("Cooperative/ListCooperatives");
                var listClients = await _tvoAPIService.GetAsync<List<ClientDTO>>("Client/ListClients");

                var transportTypes = listTransports?.ToDictionary(
                    t => t.idTransport,
                    t => t.typeTransport
                ) ?? new Dictionary<int, string>();

                var cooperativeNames = listCooperatives?.ToDictionary(
                    c => c.idCooperative,
                    c => c.nameCooperative
                ) ?? new Dictionary<int, string>();

                var clientNames = listClients?.ToDictionary(
                    cl => cl.idClient,
                    cl => $"{cl.firstName} {cl.lastName}"
                ) ?? new Dictionary<int, string>();

                var displayTransportData = listTransportData.Select(td => new
                {
                    td.idTransportData,
                    Plate = td.plate,
                    Number = td.num,
                    Chassis = td.chassis,

                    TransportType = td.idTransport.HasValue && transportTypes.TryGetValue(td.idTransport.Value, out var transportName)
                                   ? transportName
                                   : "No especificado",

                    CooperativeName = td.idCooperative.HasValue && cooperativeNames.TryGetValue(td.idCooperative.Value, out var coopName)
                                     ? coopName
                                     : "No especificada",

                    ClientFullName = td.idClient.HasValue && clientNames.TryGetValue(td.idClient.Value, out var clientName)
                                    ? clientName
                                    : "No especificado",

                    idTransport = td.idTransport,
                    idCooperative = td.idCooperative,
                    idClient = td.idClient
                }).ToList();

                dgvTransportData.DataSource = displayTransportData;
                dgvTransportData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvTransportData.Columns.Contains("idTransportData"))
                    dgvTransportData.Columns["idTransportData"].HeaderText = "ID";

                if (dgvTransportData.Columns.Contains("Plate"))
                    dgvTransportData.Columns["Plate"].HeaderText = "Placa";

                if (dgvTransportData.Columns.Contains("Number"))
                    dgvTransportData.Columns["Number"].HeaderText = "Número";

                if (dgvTransportData.Columns.Contains("Chassis"))
                    dgvTransportData.Columns["Chassis"].HeaderText = "Chasis";

                if (dgvTransportData.Columns.Contains("TransportType"))
                    dgvTransportData.Columns["TransportType"].HeaderText = "Tipo de Transporte";

                if (dgvTransportData.Columns.Contains("CooperativeName"))
                    dgvTransportData.Columns["CooperativeName"].HeaderText = "Cooperativa";

                if (dgvTransportData.Columns.Contains("ClientFullName"))
                    dgvTransportData.Columns["ClientFullName"].HeaderText = "Propietario";

                var columnsToHide = new[] { "idTransport", "idCooperative", "idClient" };
                foreach (var column in columnsToHide)
                {
                    if (dgvTransportData.Columns.Contains(column))
                        dgvTransportData.Columns[column].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de transporte: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private async Task listOwners()
        {
            try
            {
                var listOwners = await _tvoAPIService.GetAsync<List<ClientDTO>>("Client/ListClients");

                var ownersWithFullName = listOwners.Select(owner => new
                {
                    FullName = $"{owner.firstName} {owner.lastName}",
                    owner.idClient
                }).ToList();

                mcbClientsTransportData.DataSource = ownersWithFullName;
                mcbClientsTransportData.DisplayMember = "FullName";
                mcbClientsTransportData.ValueMember = "idClient";
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

                txtIdTransportData.Text = row.Cells["idTransportData"].Value?.ToString() ?? "";
                txtPlateTransportData.Text = row.Cells["Plate"].Value?.ToString() ?? "";
                txtChassisTransportData.Text = row.Cells["Chassis"].Value?.ToString() ?? "";
                txtNumTransportData.Text = row.Cells["Number"].Value?.ToString() ?? "";

                mcbTypeTransTransportData.SelectedValue = row.Cells["idTransport"].Value ?? -1;
                mcbCoopTransData.SelectedValue = row.Cells["idCooperative"].Value ?? -1;
                mcbClientsTransportData.SelectedValue = row.Cells["idClient"].Value ?? -1;

                if (mcbTypeTransTransportData.SelectedValue == null || (int)mcbTypeTransTransportData.SelectedValue == -1)
                    mcbTypeTransTransportData.SelectedIndex = -1;

                if (mcbCoopTransData.SelectedValue == null || (int)mcbCoopTransData.SelectedValue == -1)
                    mcbCoopTransData.SelectedIndex = -1;

                if (mcbClientsTransportData.SelectedValue == null || (int)mcbClientsTransportData.SelectedValue == -1)
                    mcbClientsTransportData.SelectedIndex = -1;
            }
        }

        private void clearFieldsTransportData()
        {
            txtIdTransportData.Clear();
            txtPlateTransportData.Clear();
            txtChassisTransportData.Clear();
            txtNumTransportData.Clear();
            mcbTypeTransTransportData.SelectedIndex = -1;
            mcbCoopTransData.SelectedIndex = -1;
            mcbClientsTransportData.SelectedIndex = -1;
        }

        private async void btnAddTransportData_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtPlateTransportData.Text) ||
                string.IsNullOrWhiteSpace(txtChassisTransportData.Text) ||
                string.IsNullOrWhiteSpace(txtNumTransportData.Text))
            {
                MessageBox.Show("Placa, chasis y número son campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de formato de placa (6-8 caracteres alfanuméricos)
            if (!Validator.IsValidPlate(txtPlateTransportData.Text))
            {
                MessageBox.Show("La placa debe tener entre 6 y 8 caracteres alfanuméricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de chasis único
            bool chassisExists = await _tvoAPIService.IsChassisExists("TransportData/CheckChassisExists", txtChassisTransportData.Text);
            if (chassisExists)
            {
                MessageBox.Show("El número de chasis ya está registrado en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de número (debe ser numérico y mayor a 0)
            if (!Validator.ContainsOnlyNumbers(txtNumTransportData.Text) || !int.TryParse(txtNumTransportData.Text, out int numValue) || numValue <= 0)
            {
                MessageBox.Show("El número debe ser un valor numérico mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newTransportData = new TransportDataDTO
            {
                plate = txtPlateTransportData.Text,
                chassis = txtChassisTransportData.Text,
                num = numValue, // Usamos el valor ya parseado
                idTransport = mcbTypeTransTransportData.SelectedIndex == -1 ? null : (int?)mcbTypeTransTransportData.SelectedValue,
                idCooperative = mcbCoopTransData.SelectedIndex == -1 ? null : (int?)mcbCoopTransData.SelectedValue,
                idClient = mcbClientsTransportData.SelectedIndex == -1 ? null : (int?)mcbClientsTransportData.SelectedValue
            };

            try
            {
                await _tvoAPIService.insertObject(newTransportData, "TransportData/InsertTransportData", "transportData");
                await loadTransportData();
                clearFieldsTransportData();
                MessageBox.Show("Datos del vehículo registrados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudieron registrar los datos del vehículo. Detalle: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private async void btnEditTransportData_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtIdTransportData.Text) ||
                string.IsNullOrWhiteSpace(txtPlateTransportData.Text) ||
                string.IsNullOrWhiteSpace(txtChassisTransportData.Text) ||
                string.IsNullOrWhiteSpace(txtNumTransportData.Text))
            {
                MessageBox.Show("ID, placa, chasis y número son campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de ID (debe ser numérico y mayor a 0)
            if (!Validator.ContainsOnlyNumbers(txtIdTransportData.Text) || !int.TryParse(txtIdTransportData.Text, out int idValue) || idValue <= 0)
            {
                MessageBox.Show("El ID debe ser un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de formato de placa (6-8 caracteres alfanuméricos)
            if (!Validator.IsValidPlate(txtPlateTransportData.Text))
            {
                MessageBox.Show("La placa debe tener entre 6 y 8 caracteres alfanuméricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de chasis único (verificando que no exista en otros registros)
            bool chassisExists = await _tvoAPIService.IsChassisExists("TransportData/CheckChassisExists", txtChassisTransportData.Text);
            if (chassisExists)
            {
                MessageBox.Show("El número de chasis ya está registrado en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de número (debe ser numérico y mayor a 0)
            if (!Validator.ContainsOnlyNumbers(txtNumTransportData.Text) || !int.TryParse(txtNumTransportData.Text, out int numValue) || numValue <= 0)
            {
                MessageBox.Show("El número debe ser un valor numérico mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var updatedTransportData = new TransportDataDTO
            {
                idTransportData = idValue,
                plate = txtPlateTransportData.Text,
                chassis = txtChassisTransportData.Text,
                num = numValue,
                idTransport = mcbTypeTransTransportData.SelectedIndex == -1 ? null : (int?)mcbTypeTransTransportData.SelectedValue,
                idCooperative = mcbCoopTransData.SelectedIndex == -1 ? null : (int?)mcbCoopTransData.SelectedValue,
                idClient = mcbClientsTransportData.SelectedIndex == -1 ? null : (int?)mcbClientsTransportData.SelectedValue
            };

            try
            {
                await _tvoAPIService.updateObject(updatedTransportData, "TransportData/UpdateTransportData", "transportData");
                await loadTransportData();
                clearFieldsTransportData();
                MessageBox.Show("Datos del vehículo actualizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudieron actualizar los datos del vehículo. Detalle: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnClearTransportData_Click(object sender, EventArgs e)
        {
            clearFieldsTransportData();
        }

        private async void mcbClientsTransportData_SelectedIndexChanged(object sender, EventArgs e)
        {
            await listOwners();
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
                    mcbEmployeeWO.SelectedIndex = -1;
                }
                if (row.Cells["idOrderStatus"].Value != null)
                {
                    mcbOrderStatus.SelectedValue = row.Cells["idOrderStatus"].Value;
                }
                else
                {
                    mcbOrderStatus.SelectedIndex = -1;
                }
                if (DateTime.TryParse(row.Cells["expires"].Value.ToString(), out DateTime expires))
                {
                    dtpExpireWO.Value = expires;
                }
                else
                {
                    dtpExpireWO.Value = DateTime.Now;
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            FRMLogin loginForm = new FRMLogin();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private async void btnViewDeatils_Click(object sender, EventArgs e)
        {
            try
            {
                // Corregir estas dos líneas
                string idwoText = txtIDWOBudget.Text;
                if (string.IsNullOrEmpty(idwoText))
                {
                    MessageBox.Show("Por favor ingrese la OT del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idwo = int.Parse(idwoText);

                // El resto del método permanece exactamente igual
                var budgetsTask = _tvoAPIService.SearchBudgetWithidwo("WorkOrder/SearchBudgetWithidwo", idwo);
                var totalBudgetTask = _tvoAPIService.GetTotalBudgetByidwo("WorkOrder/GetTotalBudgetByidwo", idwo);

                await Task.WhenAll(budgetsTask, totalBudgetTask);

                var budgets = await budgetsTask;
                var totalBudget = await totalBudgetTask;

                if (budgets == null || !budgets.Any())
                {
                    MessageBox.Show("No se encontraron presupuestos para el NUI ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtTotalBudget.Text = totalBudget?.ToString("C2") ?? "$0.00";

                var firstBudget = budgets.First();
                txtIdNUIClientBudget.Text = firstBudget.clientNui;
                txtOrderStatus.Text = firstBudget.orderStatus;
                txtClientBudget.Text = firstBudget.clientName;
                txtBrandBudget.Text = firstBudget.vehicleBrand;
                txtModelBudget.Text = firstBudget.vehicleModel;
                txtPlateBudget.Text = firstBudget.vehiclePlate;
                txtExpiresDate.Text = firstBudget.expires.ToString("dd/MM/yyyy");

                dgvDeatilsBudget.SuspendLayout();
                dgvDeatilsBudget.AutoGenerateColumns = false;
                dgvDeatilsBudget.DataSource = null;
                dgvDeatilsBudget.Columns.Clear();

                dgvDeatilsBudget.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "idOrderDetails",
                    HeaderText = "ID Detalle",
                    Name = "colIdOrderDetails",
                    Width = 80
                });

                dgvDeatilsBudget.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "idService",
                    HeaderText = "ID Servicio",
                    Name = "colIdService",
                    Width = 80
                });

                dgvDeatilsBudget.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "descriptionServices",
                    HeaderText = "Descripción",
                    Name = "colDescription",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dgvDeatilsBudget.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "price",
                    HeaderText = "Precio",
                    Name = "colPrice",
                    DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Font = new Font(dgvDeatilsBudget.Font, FontStyle.Bold)
                    },
                    Width = 100
                });

                dgvDeatilsBudget.DataSource = budgets;
                dgvDeatilsBudget.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvDeatilsBudget.ReadOnly = true;
                dgvDeatilsBudget.ResumeLayout();

                if (totalBudget > 1000)
                {
                    txtTotalBudget.BackColor = Color.LightGoldenrodYellow;
                    txtTotalBudget.Font = new Font(txtTotalBudget.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void btnClearBudget_Click(object sender, EventArgs e)
        {
            txtIDWOBudget.Clear();
            txtIdNUIClientBudget.Clear();
            txtClientBudget.Clear();
            txtPlateBudget.Clear();
            txtOrderStatus.Clear();
            txtBrandBudget.Clear();
            txtModelBudget.Clear();
            txtTotalBudget.Clear();
            txtExpiresDate.Clear();
            if (dgvDeatilsBudget.DataSource != null)
            {
                dgvDeatilsBudget.DataSource = new List<SearchBudgetDTO>();
            }
            dgvDeatilsBudget.ClearSelection();
        }

        private void btnInsertDetailsOT_Click(object sender, EventArgs e)
        {
            FRMOrderDetails frmOrderDetails = new FRMOrderDetails();
            frmOrderDetails.Show();
        }

        private void btnAddBudgetOT_Click(object sender, EventArgs e)
        {
            FRMBudget fmrBudget = new FRMBudget();
            fmrBudget.Show();
        }
    }
}
