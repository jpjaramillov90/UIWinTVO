namespace UIWinTVO.Views
{
    partial class StartApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartApp));
            MTCStartapp = new MaterialSkin.Controls.MaterialTabControl();
            Home = new TabPage();
            materialFloatingActionButton3 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialFloatingActionButton2 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            label3 = new Label();
            label4 = new Label();
            materialProgressBar2 = new MaterialSkin.Controls.MaterialProgressBar();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            label5 = new Label();
            label6 = new Label();
            materialProgressBar3 = new MaterialSkin.Controls.MaterialProgressBar();
            materialFloatingActionButton1 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            button1 = new Button();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            label2 = new Label();
            materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            label1 = new Label();
            Clients = new TabPage();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            mbtnClearClient = new MaterialSkin.Controls.MaterialButton();
            mbtnEditClient = new MaterialSkin.Controls.MaterialButton();
            mbtnAddClient = new MaterialSkin.Controls.MaterialButton();
            dgvClients = new DataGridView();
            mcbStatusClient = new MaterialSkin.Controls.MaterialComboBox();
            txtPasswordClient = new MaterialSkin.Controls.MaterialTextBox();
            labelPasswordClient = new MaterialSkin.Controls.MaterialLabel();
            txtAddressClient = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            txtMailClient = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            txtPhoneClient = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            txtLastNameClient = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            txtFirstNameClient = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            txtNUIClient = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtIdClient = new MaterialSkin.Controls.MaterialTextBox();
            mLbIdClient = new MaterialSkin.Controls.MaterialLabel();
            Employee = new TabPage();
            AssetsIcons = new ImageList(components);
            Budgets = new TabPage();
            MTCStartapp.SuspendLayout();
            Home.SuspendLayout();
            materialCard3.SuspendLayout();
            materialCard2.SuspendLayout();
            materialCard1.SuspendLayout();
            Clients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // MTCStartapp
            // 
            MTCStartapp.Controls.Add(Home);
            MTCStartapp.Controls.Add(Clients);
            MTCStartapp.Controls.Add(Employee);
            MTCStartapp.Controls.Add(Budgets);
            MTCStartapp.Depth = 0;
            MTCStartapp.Dock = DockStyle.Fill;
            MTCStartapp.ImageList = AssetsIcons;
            MTCStartapp.Location = new Point(3, 64);
            MTCStartapp.MouseState = MaterialSkin.MouseState.HOVER;
            MTCStartapp.Multiline = true;
            MTCStartapp.Name = "MTCStartapp";
            MTCStartapp.SelectedIndex = 0;
            MTCStartapp.Size = new Size(1194, 833);
            MTCStartapp.TabIndex = 0;
            // 
            // Home
            // 
            Home.Controls.Add(materialFloatingActionButton3);
            Home.Controls.Add(materialFloatingActionButton2);
            Home.Controls.Add(materialCard3);
            Home.Controls.Add(materialCard2);
            Home.Controls.Add(materialFloatingActionButton1);
            Home.Controls.Add(button1);
            Home.Controls.Add(materialCard1);
            Home.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Home.ImageKey = "home.png";
            Home.Location = new Point(4, 39);
            Home.Name = "Home";
            Home.Padding = new Padding(3);
            Home.Size = new Size(1186, 790);
            Home.TabIndex = 0;
            Home.Text = "Home";
            Home.UseVisualStyleBackColor = true;
            // 
            // materialFloatingActionButton3
            // 
            materialFloatingActionButton3.Depth = 0;
            materialFloatingActionButton3.Icon = Properties.Resources.satisfaction1;
            materialFloatingActionButton3.Image = Properties.Resources.satisfaction1;
            materialFloatingActionButton3.Location = new Point(687, 623);
            materialFloatingActionButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton3.Name = "materialFloatingActionButton3";
            materialFloatingActionButton3.Size = new Size(98, 93);
            materialFloatingActionButton3.TabIndex = 5;
            materialFloatingActionButton3.Text = "materialFloatingActionButton3";
            materialFloatingActionButton3.UseVisualStyleBackColor = true;
            // 
            // materialFloatingActionButton2
            // 
            materialFloatingActionButton2.Depth = 0;
            materialFloatingActionButton2.Icon = Properties.Resources.satisfaction;
            materialFloatingActionButton2.Image = Properties.Resources.satisfaction;
            materialFloatingActionButton2.Location = new Point(1044, 484);
            materialFloatingActionButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton2.Name = "materialFloatingActionButton2";
            materialFloatingActionButton2.Size = new Size(98, 93);
            materialFloatingActionButton2.TabIndex = 5;
            materialFloatingActionButton2.Text = "materialFloatingActionButton2";
            materialFloatingActionButton2.UseVisualStyleBackColor = true;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.BackgroundImage = Properties.Resources.logo_Taller_Oleas;
            materialCard3.BackgroundImageLayout = ImageLayout.Center;
            materialCard3.Controls.Add(label3);
            materialCard3.Controls.Add(label4);
            materialCard3.Controls.Add(materialProgressBar2);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(431, 590);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(285, 126);
            materialCard3.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 78);
            label3.Name = "label3";
            label3.Size = new Size(90, 13);
            label3.TabIndex = 5;
            label3.Text = "2453 Atenciones";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Roboto", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 33);
            label4.Name = "label4";
            label4.Size = new Size(186, 23);
            label4.TabIndex = 3;
            label4.Text = "Clientes Satisfechos";
            // 
            // materialProgressBar2
            // 
            materialProgressBar2.Depth = 0;
            materialProgressBar2.Location = new Point(17, 70);
            materialProgressBar2.MouseState = MaterialSkin.MouseState.HOVER;
            materialProgressBar2.Name = "materialProgressBar2";
            materialProgressBar2.Size = new Size(220, 5);
            materialProgressBar2.TabIndex = 4;
            materialProgressBar2.Value = 95;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.BackgroundImage = Properties.Resources.logo_Taller_Oleas;
            materialCard2.BackgroundImageLayout = ImageLayout.Center;
            materialCard2.Controls.Add(label5);
            materialCard2.Controls.Add(label6);
            materialCard2.Controls.Add(materialProgressBar3);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(788, 451);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(285, 126);
            materialCard2.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Roboto", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 78);
            label5.Name = "label5";
            label5.Size = new Size(33, 13);
            label5.TabIndex = 8;
            label5.Text = "100%";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Roboto", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(27, 33);
            label6.Name = "label6";
            label6.Size = new Size(170, 23);
            label6.TabIndex = 6;
            label6.Text = "Entregas a Tiempo";
            // 
            // materialProgressBar3
            // 
            materialProgressBar3.Depth = 0;
            materialProgressBar3.Location = new Point(27, 70);
            materialProgressBar3.MouseState = MaterialSkin.MouseState.HOVER;
            materialProgressBar3.Name = "materialProgressBar3";
            materialProgressBar3.Size = new Size(220, 5);
            materialProgressBar3.TabIndex = 7;
            materialProgressBar3.Value = 100;
            // 
            // materialFloatingActionButton1
            // 
            materialFloatingActionButton1.Depth = 0;
            materialFloatingActionButton1.Icon = Properties.Resources.check;
            materialFloatingActionButton1.Image = Properties.Resources.check;
            materialFloatingActionButton1.Location = new Point(328, 484);
            materialFloatingActionButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton1.Name = "materialFloatingActionButton1";
            materialFloatingActionButton1.Size = new Size(98, 93);
            materialFloatingActionButton1.TabIndex = 3;
            materialFloatingActionButton1.Text = "materialFloatingActionButton1";
            materialFloatingActionButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.logo_Taller_Oleas;
            button1.Location = new Point(212, 64);
            button1.Name = "button1";
            button1.Size = new Size(741, 350);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.BackgroundImage = Properties.Resources.logo_Taller_Oleas;
            materialCard1.BackgroundImageLayout = ImageLayout.Center;
            materialCard1.Controls.Add(label2);
            materialCard1.Controls.Add(materialProgressBar1);
            materialCard1.Controls.Add(label1);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(72, 451);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(285, 126);
            materialCard1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 78);
            label2.Name = "label2";
            label2.Size = new Size(33, 13);
            label2.TabIndex = 2;
            label2.Text = "100%";
            // 
            // materialProgressBar1
            // 
            materialProgressBar1.Depth = 0;
            materialProgressBar1.Location = new Point(17, 70);
            materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialProgressBar1.Name = "materialProgressBar1";
            materialProgressBar1.Size = new Size(220, 5);
            materialProgressBar1.TabIndex = 1;
            materialProgressBar1.Value = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 33);
            label1.Name = "label1";
            label1.Size = new Size(184, 23);
            label1.TabIndex = 0;
            label1.Text = "Trabajo Garantizado";
            // 
            // Clients
            // 
            Clients.Controls.Add(materialLabel5);
            Clients.Controls.Add(mbtnClearClient);
            Clients.Controls.Add(mbtnEditClient);
            Clients.Controls.Add(mbtnAddClient);
            Clients.Controls.Add(dgvClients);
            Clients.Controls.Add(mcbStatusClient);
            Clients.Controls.Add(txtPasswordClient);
            Clients.Controls.Add(labelPasswordClient);
            Clients.Controls.Add(txtAddressClient);
            Clients.Controls.Add(materialLabel6);
            Clients.Controls.Add(txtMailClient);
            Clients.Controls.Add(materialLabel7);
            Clients.Controls.Add(txtPhoneClient);
            Clients.Controls.Add(materialLabel8);
            Clients.Controls.Add(materialLabel4);
            Clients.Controls.Add(txtLastNameClient);
            Clients.Controls.Add(materialLabel3);
            Clients.Controls.Add(txtFirstNameClient);
            Clients.Controls.Add(materialLabel2);
            Clients.Controls.Add(txtNUIClient);
            Clients.Controls.Add(materialLabel1);
            Clients.Controls.Add(txtIdClient);
            Clients.Controls.Add(mLbIdClient);
            Clients.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Clients.ImageKey = "CLIENTS.png";
            Clients.Location = new Point(4, 39);
            Clients.Name = "Clients";
            Clients.Padding = new Padding(3);
            Clients.Size = new Size(1186, 790);
            Clients.TabIndex = 1;
            Clients.Text = "Clientes";
            Clients.UseVisualStyleBackColor = true;
            Clients.Click += tabPage2_Click;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(37, 394);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(135, 19);
            materialLabel5.TabIndex = 24;
            materialLabel5.Text = "Listado de Clientes";
            // 
            // mbtnClearClient
            // 
            mbtnClearClient.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mbtnClearClient.BackColor = Color.Red;
            mbtnClearClient.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mbtnClearClient.Depth = 0;
            mbtnClearClient.ForeColor = Color.Red;
            mbtnClearClient.HighEmphasis = true;
            mbtnClearClient.Icon = Properties.Resources.delete;
            mbtnClearClient.Location = new Point(951, 163);
            mbtnClearClient.Margin = new Padding(4, 6, 4, 6);
            mbtnClearClient.MouseState = MaterialSkin.MouseState.HOVER;
            mbtnClearClient.Name = "mbtnClearClient";
            mbtnClearClient.NoAccentTextColor = Color.Empty;
            mbtnClearClient.Size = new Size(107, 36);
            mbtnClearClient.TabIndex = 23;
            mbtnClearClient.Text = "Limpiar";
            mbtnClearClient.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mbtnClearClient.UseAccentColor = false;
            mbtnClearClient.UseVisualStyleBackColor = false;
            // 
            // mbtnEditClient
            // 
            mbtnEditClient.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mbtnEditClient.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mbtnEditClient.Depth = 0;
            mbtnEditClient.HighEmphasis = true;
            mbtnEditClient.Icon = Properties.Resources.edit;
            mbtnEditClient.Location = new Point(951, 106);
            mbtnEditClient.Margin = new Padding(4, 6, 4, 6);
            mbtnEditClient.MouseState = MaterialSkin.MouseState.HOVER;
            mbtnEditClient.Name = "mbtnEditClient";
            mbtnEditClient.NoAccentTextColor = Color.Empty;
            mbtnEditClient.Size = new Size(127, 36);
            mbtnEditClient.TabIndex = 22;
            mbtnEditClient.Text = "Modificar";
            mbtnEditClient.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mbtnEditClient.UseAccentColor = false;
            mbtnEditClient.UseVisualStyleBackColor = true;
            // 
            // mbtnAddClient
            // 
            mbtnAddClient.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mbtnAddClient.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mbtnAddClient.Depth = 0;
            mbtnAddClient.HighEmphasis = true;
            mbtnAddClient.Icon = Properties.Resources.add;
            mbtnAddClient.Location = new Point(951, 49);
            mbtnAddClient.Margin = new Padding(4, 6, 4, 6);
            mbtnAddClient.MouseState = MaterialSkin.MouseState.HOVER;
            mbtnAddClient.Name = "mbtnAddClient";
            mbtnAddClient.NoAccentTextColor = Color.Empty;
            mbtnAddClient.Size = new Size(116, 36);
            mbtnAddClient.TabIndex = 21;
            mbtnAddClient.Text = "Agregar";
            mbtnAddClient.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mbtnAddClient.UseAccentColor = false;
            mbtnAddClient.UseVisualStyleBackColor = true;
            mbtnAddClient.Click += mbtnAddClient_Click;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(33, 417);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.Size = new Size(1130, 373);
            dgvClients.TabIndex = 20;
            // 
            // mcbStatusClient
            // 
            mcbStatusClient.AutoResize = false;
            mcbStatusClient.BackColor = Color.FromArgb(255, 255, 255);
            mcbStatusClient.Depth = 0;
            mcbStatusClient.DrawMode = DrawMode.OwnerDrawVariable;
            mcbStatusClient.DropDownHeight = 174;
            mcbStatusClient.DropDownStyle = ComboBoxStyle.DropDownList;
            mcbStatusClient.DropDownWidth = 121;
            mcbStatusClient.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            mcbStatusClient.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcbStatusClient.FormattingEnabled = true;
            mcbStatusClient.IntegralHeight = false;
            mcbStatusClient.ItemHeight = 43;
            mcbStatusClient.Location = new Point(172, 300);
            mcbStatusClient.MaxDropDownItems = 4;
            mcbStatusClient.MouseState = MaterialSkin.MouseState.OUT;
            mcbStatusClient.Name = "mcbStatusClient";
            mcbStatusClient.Size = new Size(272, 49);
            mcbStatusClient.StartIndex = 0;
            mcbStatusClient.TabIndex = 19;
            // 
            // txtPasswordClient
            // 
            txtPasswordClient.AnimateReadOnly = false;
            txtPasswordClient.BorderStyle = BorderStyle.None;
            txtPasswordClient.Depth = 0;
            txtPasswordClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPasswordClient.ForeColor = Color.Transparent;
            txtPasswordClient.LeadingIcon = null;
            txtPasswordClient.Location = new Point(600, 299);
            txtPasswordClient.MaxLength = 50;
            txtPasswordClient.MouseState = MaterialSkin.MouseState.OUT;
            txtPasswordClient.Multiline = false;
            txtPasswordClient.Name = "txtPasswordClient";
            txtPasswordClient.Size = new Size(271, 50);
            txtPasswordClient.TabIndex = 18;
            txtPasswordClient.Text = "";
            txtPasswordClient.TrailingIcon = null;
            // 
            // labelPasswordClient
            // 
            labelPasswordClient.AutoSize = true;
            labelPasswordClient.Depth = 0;
            labelPasswordClient.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelPasswordClient.ForeColor = Color.Transparent;
            labelPasswordClient.Location = new Point(492, 315);
            labelPasswordClient.MouseState = MaterialSkin.MouseState.HOVER;
            labelPasswordClient.Name = "labelPasswordClient";
            labelPasswordClient.Size = new Size(86, 19);
            labelPasswordClient.TabIndex = 17;
            labelPasswordClient.Text = "Contraseña:";
            // 
            // txtAddressClient
            // 
            txtAddressClient.AnimateReadOnly = false;
            txtAddressClient.BorderStyle = BorderStyle.None;
            txtAddressClient.Depth = 0;
            txtAddressClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAddressClient.ForeColor = Color.Transparent;
            txtAddressClient.LeadingIcon = null;
            txtAddressClient.Location = new Point(600, 229);
            txtAddressClient.MaxLength = 50;
            txtAddressClient.MouseState = MaterialSkin.MouseState.OUT;
            txtAddressClient.Multiline = false;
            txtAddressClient.Name = "txtAddressClient";
            txtAddressClient.Size = new Size(271, 50);
            txtAddressClient.TabIndex = 16;
            txtAddressClient.Text = "";
            txtAddressClient.TrailingIcon = null;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.ForeColor = Color.Transparent;
            materialLabel6.Location = new Point(507, 245);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(71, 19);
            materialLabel6.TabIndex = 15;
            materialLabel6.Text = "Dirección:";
            // 
            // txtMailClient
            // 
            txtMailClient.AnimateReadOnly = false;
            txtMailClient.BorderStyle = BorderStyle.None;
            txtMailClient.Depth = 0;
            txtMailClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMailClient.ForeColor = Color.Transparent;
            txtMailClient.LeadingIcon = null;
            txtMailClient.Location = new Point(600, 158);
            txtMailClient.MaxLength = 50;
            txtMailClient.MouseState = MaterialSkin.MouseState.OUT;
            txtMailClient.Multiline = false;
            txtMailClient.Name = "txtMailClient";
            txtMailClient.Size = new Size(271, 50);
            txtMailClient.TabIndex = 14;
            txtMailClient.Text = "";
            txtMailClient.TrailingIcon = null;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.ForeColor = Color.Transparent;
            materialLabel7.Location = new Point(527, 178);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(51, 19);
            materialLabel7.TabIndex = 13;
            materialLabel7.Text = "Correo:";
            // 
            // txtPhoneClient
            // 
            txtPhoneClient.AnimateReadOnly = false;
            txtPhoneClient.BorderStyle = BorderStyle.None;
            txtPhoneClient.Depth = 0;
            txtPhoneClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhoneClient.ForeColor = Color.Transparent;
            txtPhoneClient.LeadingIcon = null;
            txtPhoneClient.Location = new Point(600, 90);
            txtPhoneClient.MaxLength = 50;
            txtPhoneClient.MouseState = MaterialSkin.MouseState.OUT;
            txtPhoneClient.Multiline = false;
            txtPhoneClient.Name = "txtPhoneClient";
            txtPhoneClient.Size = new Size(271, 50);
            txtPhoneClient.TabIndex = 12;
            txtPhoneClient.Text = "";
            txtPhoneClient.TrailingIcon = null;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.ForeColor = Color.Transparent;
            materialLabel8.Location = new Point(510, 106);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(68, 19);
            materialLabel8.TabIndex = 11;
            materialLabel8.Text = "Teléfono:";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.ForeColor = Color.Transparent;
            materialLabel4.Location = new Point(86, 315);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(54, 19);
            materialLabel4.TabIndex = 9;
            materialLabel4.Text = "Estado:";
            // 
            // txtLastNameClient
            // 
            txtLastNameClient.AnimateReadOnly = false;
            txtLastNameClient.BorderStyle = BorderStyle.None;
            txtLastNameClient.Depth = 0;
            txtLastNameClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtLastNameClient.ForeColor = Color.Transparent;
            txtLastNameClient.LeadingIcon = null;
            txtLastNameClient.Location = new Point(173, 229);
            txtLastNameClient.MaxLength = 50;
            txtLastNameClient.MouseState = MaterialSkin.MouseState.OUT;
            txtLastNameClient.Multiline = false;
            txtLastNameClient.Name = "txtLastNameClient";
            txtLastNameClient.Size = new Size(271, 50);
            txtLastNameClient.TabIndex = 8;
            txtLastNameClient.Text = "";
            txtLastNameClient.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.ForeColor = Color.Transparent;
            materialLabel3.Location = new Point(78, 245);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(62, 19);
            materialLabel3.TabIndex = 7;
            materialLabel3.Text = "Apellido:";
            // 
            // txtFirstNameClient
            // 
            txtFirstNameClient.AnimateReadOnly = false;
            txtFirstNameClient.BorderStyle = BorderStyle.None;
            txtFirstNameClient.Depth = 0;
            txtFirstNameClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFirstNameClient.ForeColor = Color.Transparent;
            txtFirstNameClient.LeadingIcon = null;
            txtFirstNameClient.Location = new Point(173, 158);
            txtFirstNameClient.MaxLength = 50;
            txtFirstNameClient.MouseState = MaterialSkin.MouseState.OUT;
            txtFirstNameClient.Multiline = false;
            txtFirstNameClient.Name = "txtFirstNameClient";
            txtFirstNameClient.Size = new Size(271, 50);
            txtFirstNameClient.TabIndex = 6;
            txtFirstNameClient.Text = "";
            txtFirstNameClient.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.ForeColor = Color.Transparent;
            materialLabel2.Location = new Point(79, 178);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(61, 19);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "Nombre:";
            // 
            // txtNUIClient
            // 
            txtNUIClient.AnimateReadOnly = false;
            txtNUIClient.BorderStyle = BorderStyle.None;
            txtNUIClient.Depth = 0;
            txtNUIClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNUIClient.ForeColor = Color.Transparent;
            txtNUIClient.LeadingIcon = null;
            txtNUIClient.Location = new Point(173, 90);
            txtNUIClient.MaxLength = 50;
            txtNUIClient.MouseState = MaterialSkin.MouseState.OUT;
            txtNUIClient.Multiline = false;
            txtNUIClient.Name = "txtNUIClient";
            txtNUIClient.Size = new Size(271, 50);
            txtNUIClient.TabIndex = 4;
            txtNUIClient.Text = "";
            txtNUIClient.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.ForeColor = Color.Transparent;
            materialLabel1.Location = new Point(110, 106);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(30, 19);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "NUI:";
            // 
            // txtIdClient
            // 
            txtIdClient.AnimateReadOnly = false;
            txtIdClient.BorderStyle = BorderStyle.None;
            txtIdClient.Depth = 0;
            txtIdClient.Enabled = false;
            txtIdClient.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIdClient.ForeColor = Color.Transparent;
            txtIdClient.LeadingIcon = null;
            txtIdClient.Location = new Point(173, 20);
            txtIdClient.MaxLength = 50;
            txtIdClient.MouseState = MaterialSkin.MouseState.OUT;
            txtIdClient.Multiline = false;
            txtIdClient.Name = "txtIdClient";
            txtIdClient.Size = new Size(105, 50);
            txtIdClient.TabIndex = 2;
            txtIdClient.Text = "";
            txtIdClient.TrailingIcon = null;
            // 
            // mLbIdClient
            // 
            mLbIdClient.AutoSize = true;
            mLbIdClient.Depth = 0;
            mLbIdClient.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            mLbIdClient.ForeColor = Color.Transparent;
            mLbIdClient.Location = new Point(65, 36);
            mLbIdClient.MouseState = MaterialSkin.MouseState.HOVER;
            mLbIdClient.Name = "mLbIdClient";
            mLbIdClient.Size = new Size(75, 19);
            mLbIdClient.TabIndex = 0;
            mLbIdClient.Text = "Id CLiente:";
            // 
            // Employee
            // 
            Employee.ImageKey = "employee.png";
            Employee.Location = new Point(4, 39);
            Employee.Name = "Employee";
            Employee.Size = new Size(1186, 790);
            Employee.TabIndex = 2;
            Employee.Text = "Empleados";
            Employee.UseVisualStyleBackColor = true;
            // 
            // AssetsIcons
            // 
            AssetsIcons.ColorDepth = ColorDepth.Depth32Bit;
            AssetsIcons.ImageStream = (ImageListStreamer)resources.GetObject("AssetsIcons.ImageStream");
            AssetsIcons.TransparentColor = Color.Transparent;
            AssetsIcons.Images.SetKeyName(0, "CLIENTS.png");
            AssetsIcons.Images.SetKeyName(1, "home.png");
            AssetsIcons.Images.SetKeyName(2, "check.png");
            AssetsIcons.Images.SetKeyName(3, "satisfaction.png");
            AssetsIcons.Images.SetKeyName(4, "satisfaction1.png");
            AssetsIcons.Images.SetKeyName(5, "brands.png");
            AssetsIcons.Images.SetKeyName(6, "budget.png");
            AssetsIcons.Images.SetKeyName(7, "employee.png");
            AssetsIcons.Images.SetKeyName(8, "models.png");
            AssetsIcons.Images.SetKeyName(9, "services.png");
            AssetsIcons.Images.SetKeyName(10, "specialties.png");
            AssetsIcons.Images.SetKeyName(11, "workOrder.png");
            // 
            // Budgets
            // 
            Budgets.ImageKey = "budget.png";
            Budgets.Location = new Point(4, 39);
            Budgets.Name = "Budgets";
            Budgets.Padding = new Padding(3);
            Budgets.Size = new Size(1186, 790);
            Budgets.TabIndex = 3;
            Budgets.Text = "Presupuesto";
            Budgets.UseVisualStyleBackColor = true;
            // 
            // StartApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 900);
            Controls.Add(MTCStartapp);
            DrawerTabControl = MTCStartapp;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StartApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Taller Villalba Oleas";
            MTCStartapp.ResumeLayout(false);
            Home.ResumeLayout(false);
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            Clients.ResumeLayout(false);
            Clients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MTCStartapp;
        private TabPage Home;
        private TabPage Clients;
        private TabPage Employee;
        private ImageList AssetsIcons;
        private MaterialSkin.Controls.MaterialLabel mLbIdClient;
        private MaterialSkin.Controls.MaterialTextBox txtIdClient;
        private MaterialSkin.Controls.MaterialTextBox txtFirstNameClient;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox txtNUIClient;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox txtPasswordClient;
        private MaterialSkin.Controls.MaterialLabel labelPasswordClient;
        private MaterialSkin.Controls.MaterialTextBox txtAddressClient;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox txtMailClient;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialTextBox txtPhoneClient;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox txtLastNameClient;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialComboBox mcbStatusClient;
        private MaterialSkin.Controls.MaterialButton mbtnClearClient;
        private MaterialSkin.Controls.MaterialButton mbtnEditClient;
        private MaterialSkin.Controls.MaterialButton mbtnAddClient;
        private DataGridView dgvClients;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Button button1;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton1;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton3;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton2;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private Label label1;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private Label label3;
        private Label label4;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar2;
        private Label label5;
        private Label label6;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar3;
        private Label label2;
        private TabPage Budgets;
    }
}