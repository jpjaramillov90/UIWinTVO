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
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
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
            tabPage3 = new TabPage();
            AssetsIcons = new ImageList(components);
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            MTCStartapp.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // MTCStartapp
            // 
            MTCStartapp.Controls.Add(tabPage1);
            MTCStartapp.Controls.Add(tabPage2);
            MTCStartapp.Controls.Add(tabPage3);
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
            // tabPage1
            // 
            tabPage1.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.ImageKey = "home.png";
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1186, 740);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(materialLabel5);
            tabPage2.Controls.Add(mbtnClearClient);
            tabPage2.Controls.Add(mbtnEditClient);
            tabPage2.Controls.Add(mbtnAddClient);
            tabPage2.Controls.Add(dgvClients);
            tabPage2.Controls.Add(mcbStatusClient);
            tabPage2.Controls.Add(txtPasswordClient);
            tabPage2.Controls.Add(labelPasswordClient);
            tabPage2.Controls.Add(txtAddressClient);
            tabPage2.Controls.Add(materialLabel6);
            tabPage2.Controls.Add(txtMailClient);
            tabPage2.Controls.Add(materialLabel7);
            tabPage2.Controls.Add(txtPhoneClient);
            tabPage2.Controls.Add(materialLabel8);
            tabPage2.Controls.Add(materialLabel4);
            tabPage2.Controls.Add(txtLastNameClient);
            tabPage2.Controls.Add(materialLabel3);
            tabPage2.Controls.Add(txtFirstNameClient);
            tabPage2.Controls.Add(materialLabel2);
            tabPage2.Controls.Add(txtNUIClient);
            tabPage2.Controls.Add(materialLabel1);
            tabPage2.Controls.Add(txtIdClient);
            tabPage2.Controls.Add(mLbIdClient);
            tabPage2.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage2.ImageKey = "CLIENTS.png";
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1186, 790);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Clientes";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
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
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 39);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1186, 740);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // AssetsIcons
            // 
            AssetsIcons.ColorDepth = ColorDepth.Depth32Bit;
            AssetsIcons.ImageStream = (ImageListStreamer)resources.GetObject("AssetsIcons.ImageStream");
            AssetsIcons.TransparentColor = Color.Transparent;
            AssetsIcons.Images.SetKeyName(0, "CLIENTS.png");
            AssetsIcons.Images.SetKeyName(1, "home.png");
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
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MTCStartapp;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
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
    }
}