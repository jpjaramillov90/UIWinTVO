namespace UIWinTVO.Views
{
    partial class FRMBudget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMBudget));
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            btnClearBudget = new MaterialSkin.Controls.MaterialButton();
            btnEditBudget = new MaterialSkin.Controls.MaterialButton();
            btnAddBudget = new MaterialSkin.Controls.MaterialButton();
            dgvBudgets = new DataGridView();
            txtComentsBudget = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel17 = new MaterialSkin.Controls.MaterialLabel();
            txtIdWOBudget = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel18 = new MaterialSkin.Controls.MaterialLabel();
            txtIDBudget = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            mcbPlateTransDataBudget = new MaterialSkin.Controls.MaterialComboBox();
            mcbBudgetStatementBudget = new MaterialSkin.Controls.MaterialComboBox();
            mcbBrandsBudget = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvBudgets).BeginInit();
            SuspendLayout();
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(32, 417);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(97, 19);
            materialLabel9.TabIndex = 70;
            materialLabel9.Text = "Presupuestos";
            // 
            // btnClearBudget
            // 
            btnClearBudget.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClearBudget.BackColor = Color.Red;
            btnClearBudget.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClearBudget.Depth = 0;
            btnClearBudget.ForeColor = Color.Red;
            btnClearBudget.HighEmphasis = true;
            btnClearBudget.Icon = Properties.Resources.delete;
            btnClearBudget.Location = new Point(811, 184);
            btnClearBudget.Margin = new Padding(4, 6, 4, 6);
            btnClearBudget.MouseState = MaterialSkin.MouseState.HOVER;
            btnClearBudget.Name = "btnClearBudget";
            btnClearBudget.NoAccentTextColor = Color.Empty;
            btnClearBudget.Size = new Size(107, 36);
            btnClearBudget.TabIndex = 69;
            btnClearBudget.Text = "Limpiar";
            btnClearBudget.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClearBudget.UseAccentColor = false;
            btnClearBudget.UseVisualStyleBackColor = false;
            btnClearBudget.Click += btnClearBudget_Click;
            // 
            // btnEditBudget
            // 
            btnEditBudget.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditBudget.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditBudget.Depth = 0;
            btnEditBudget.HighEmphasis = true;
            btnEditBudget.Icon = Properties.Resources.edit;
            btnEditBudget.Location = new Point(811, 138);
            btnEditBudget.Margin = new Padding(4, 6, 4, 6);
            btnEditBudget.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditBudget.Name = "btnEditBudget";
            btnEditBudget.NoAccentTextColor = Color.Empty;
            btnEditBudget.Size = new Size(127, 36);
            btnEditBudget.TabIndex = 68;
            btnEditBudget.Text = "Modificar";
            btnEditBudget.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditBudget.UseAccentColor = false;
            btnEditBudget.UseVisualStyleBackColor = true;
            btnEditBudget.Click += btnEditBudget_Click;
            // 
            // btnAddBudget
            // 
            btnAddBudget.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddBudget.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddBudget.Depth = 0;
            btnAddBudget.HighEmphasis = true;
            btnAddBudget.Icon = Properties.Resources.add;
            btnAddBudget.Location = new Point(811, 90);
            btnAddBudget.Margin = new Padding(4, 6, 4, 6);
            btnAddBudget.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddBudget.Name = "btnAddBudget";
            btnAddBudget.NoAccentTextColor = Color.Empty;
            btnAddBudget.Size = new Size(116, 36);
            btnAddBudget.TabIndex = 67;
            btnAddBudget.Text = "Agregar";
            btnAddBudget.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddBudget.UseAccentColor = false;
            btnAddBudget.UseVisualStyleBackColor = true;
            btnAddBudget.Click += btnAddBudget_Click;
            // 
            // dgvBudgets
            // 
            dgvBudgets.AllowUserToAddRows = false;
            dgvBudgets.AllowUserToDeleteRows = false;
            dgvBudgets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBudgets.Location = new Point(28, 440);
            dgvBudgets.Name = "dgvBudgets";
            dgvBudgets.ReadOnly = true;
            dgvBudgets.Size = new Size(945, 235);
            dgvBudgets.TabIndex = 66;
            dgvBudgets.CellContentClick += dgvBudgets_CellContentClick;
            // 
            // txtComentsBudget
            // 
            txtComentsBudget.AnimateReadOnly = false;
            txtComentsBudget.BorderStyle = BorderStyle.None;
            txtComentsBudget.Depth = 0;
            txtComentsBudget.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtComentsBudget.ForeColor = Color.Transparent;
            txtComentsBudget.LeadingIcon = null;
            txtComentsBudget.Location = new Point(587, 303);
            txtComentsBudget.MaxLength = 50;
            txtComentsBudget.MouseState = MaterialSkin.MouseState.OUT;
            txtComentsBudget.Multiline = false;
            txtComentsBudget.Name = "txtComentsBudget";
            txtComentsBudget.Size = new Size(386, 50);
            txtComentsBudget.TabIndex = 61;
            txtComentsBudget.Text = "";
            txtComentsBudget.TrailingIcon = null;
            // 
            // materialLabel12
            // 
            materialLabel12.AutoSize = true;
            materialLabel12.Depth = 0;
            materialLabel12.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel12.ForeColor = Color.Transparent;
            materialLabel12.Location = new Point(486, 323);
            materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel12.Name = "materialLabel12";
            materialLabel12.Size = new Size(95, 19);
            materialLabel12.TabIndex = 60;
            materialLabel12.Text = "Comentarios:";
            // 
            // materialLabel13
            // 
            materialLabel13.AutoSize = true;
            materialLabel13.Depth = 0;
            materialLabel13.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel13.ForeColor = Color.Transparent;
            materialLabel13.Location = new Point(531, 251);
            materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel13.Name = "materialLabel13";
            materialLabel13.Size = new Size(50, 19);
            materialLabel13.TabIndex = 58;
            materialLabel13.Text = "Marca:";
            // 
            // materialLabel16
            // 
            materialLabel16.AutoSize = true;
            materialLabel16.Depth = 0;
            materialLabel16.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel16.ForeColor = Color.Transparent;
            materialLabel16.Location = new Point(37, 323);
            materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel16.Name = "materialLabel16";
            materialLabel16.Size = new Size(146, 19);
            materialLabel16.TabIndex = 53;
            materialLabel16.Text = "Estado Presupuesto:";
            // 
            // materialLabel17
            // 
            materialLabel17.AutoSize = true;
            materialLabel17.Depth = 0;
            materialLabel17.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel17.ForeColor = Color.Transparent;
            materialLabel17.Location = new Point(138, 251);
            materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel17.Name = "materialLabel17";
            materialLabel17.Size = new Size(45, 19);
            materialLabel17.TabIndex = 51;
            materialLabel17.Text = "Placa:";
            // 
            // txtIdWOBudget
            // 
            txtIdWOBudget.AnimateReadOnly = false;
            txtIdWOBudget.BorderStyle = BorderStyle.None;
            txtIdWOBudget.Depth = 0;
            txtIdWOBudget.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIdWOBudget.ForeColor = Color.Transparent;
            txtIdWOBudget.LeadingIcon = null;
            txtIdWOBudget.Location = new Point(189, 170);
            txtIdWOBudget.MaxLength = 50;
            txtIdWOBudget.MouseState = MaterialSkin.MouseState.OUT;
            txtIdWOBudget.Multiline = false;
            txtIdWOBudget.Name = "txtIdWOBudget";
            txtIdWOBudget.Size = new Size(136, 50);
            txtIdWOBudget.TabIndex = 50;
            txtIdWOBudget.Text = "";
            txtIdWOBudget.TrailingIcon = null;
            // 
            // materialLabel18
            // 
            materialLabel18.AutoSize = true;
            materialLabel18.Depth = 0;
            materialLabel18.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel18.ForeColor = Color.Transparent;
            materialLabel18.Location = new Point(138, 187);
            materialLabel18.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel18.Name = "materialLabel18";
            materialLabel18.Size = new Size(43, 19);
            materialLabel18.TabIndex = 49;
            materialLabel18.Text = "Id OT:";
            // 
            // txtIDBudget
            // 
            txtIDBudget.AnimateReadOnly = false;
            txtIDBudget.BorderStyle = BorderStyle.None;
            txtIDBudget.Depth = 0;
            txtIDBudget.Enabled = false;
            txtIDBudget.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIDBudget.ForeColor = Color.Transparent;
            txtIDBudget.LeadingIcon = null;
            txtIDBudget.Location = new Point(189, 98);
            txtIDBudget.MaxLength = 50;
            txtIDBudget.MouseState = MaterialSkin.MouseState.OUT;
            txtIDBudget.Multiline = false;
            txtIDBudget.Name = "txtIDBudget";
            txtIDBudget.Size = new Size(136, 50);
            txtIDBudget.TabIndex = 72;
            txtIDBudget.Text = "";
            txtIDBudget.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.ForeColor = Color.Transparent;
            materialLabel1.Location = new Point(71, 116);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(110, 19);
            materialLabel1.TabIndex = 71;
            materialLabel1.Text = "Id Presupuesto:";
            // 
            // mcbPlateTransDataBudget
            // 
            mcbPlateTransDataBudget.AutoResize = false;
            mcbPlateTransDataBudget.BackColor = Color.FromArgb(255, 255, 255);
            mcbPlateTransDataBudget.Depth = 0;
            mcbPlateTransDataBudget.DrawMode = DrawMode.OwnerDrawVariable;
            mcbPlateTransDataBudget.DropDownHeight = 174;
            mcbPlateTransDataBudget.DropDownStyle = ComboBoxStyle.DropDownList;
            mcbPlateTransDataBudget.DropDownWidth = 121;
            mcbPlateTransDataBudget.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            mcbPlateTransDataBudget.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcbPlateTransDataBudget.FormattingEnabled = true;
            mcbPlateTransDataBudget.IntegralHeight = false;
            mcbPlateTransDataBudget.ItemHeight = 43;
            mcbPlateTransDataBudget.Location = new Point(190, 240);
            mcbPlateTransDataBudget.MaxDropDownItems = 4;
            mcbPlateTransDataBudget.MouseState = MaterialSkin.MouseState.OUT;
            mcbPlateTransDataBudget.Name = "mcbPlateTransDataBudget";
            mcbPlateTransDataBudget.Size = new Size(191, 49);
            mcbPlateTransDataBudget.StartIndex = 0;
            mcbPlateTransDataBudget.TabIndex = 73;
            // 
            // mcbBudgetStatementBudget
            // 
            mcbBudgetStatementBudget.AutoResize = false;
            mcbBudgetStatementBudget.BackColor = Color.FromArgb(255, 255, 255);
            mcbBudgetStatementBudget.Depth = 0;
            mcbBudgetStatementBudget.DrawMode = DrawMode.OwnerDrawVariable;
            mcbBudgetStatementBudget.DropDownHeight = 174;
            mcbBudgetStatementBudget.DropDownStyle = ComboBoxStyle.DropDownList;
            mcbBudgetStatementBudget.DropDownWidth = 121;
            mcbBudgetStatementBudget.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            mcbBudgetStatementBudget.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcbBudgetStatementBudget.FormattingEnabled = true;
            mcbBudgetStatementBudget.IntegralHeight = false;
            mcbBudgetStatementBudget.ItemHeight = 43;
            mcbBudgetStatementBudget.Location = new Point(190, 304);
            mcbBudgetStatementBudget.MaxDropDownItems = 4;
            mcbBudgetStatementBudget.MouseState = MaterialSkin.MouseState.OUT;
            mcbBudgetStatementBudget.Name = "mcbBudgetStatementBudget";
            mcbBudgetStatementBudget.Size = new Size(254, 49);
            mcbBudgetStatementBudget.StartIndex = 0;
            mcbBudgetStatementBudget.TabIndex = 74;
            // 
            // mcbBrandsBudget
            // 
            mcbBrandsBudget.AutoResize = false;
            mcbBrandsBudget.BackColor = Color.FromArgb(255, 255, 255);
            mcbBrandsBudget.Depth = 0;
            mcbBrandsBudget.DrawMode = DrawMode.OwnerDrawVariable;
            mcbBrandsBudget.DropDownHeight = 174;
            mcbBrandsBudget.DropDownStyle = ComboBoxStyle.DropDownList;
            mcbBrandsBudget.DropDownWidth = 121;
            mcbBrandsBudget.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            mcbBrandsBudget.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcbBrandsBudget.FormattingEnabled = true;
            mcbBrandsBudget.IntegralHeight = false;
            mcbBrandsBudget.ItemHeight = 43;
            mcbBrandsBudget.Location = new Point(587, 240);
            mcbBrandsBudget.MaxDropDownItems = 4;
            mcbBrandsBudget.MouseState = MaterialSkin.MouseState.OUT;
            mcbBrandsBudget.Name = "mcbBrandsBudget";
            mcbBrandsBudget.Size = new Size(191, 49);
            mcbBrandsBudget.StartIndex = 0;
            mcbBrandsBudget.TabIndex = 75;
            // 
            // FRMBudget
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(mcbBrandsBudget);
            Controls.Add(mcbBudgetStatementBudget);
            Controls.Add(mcbPlateTransDataBudget);
            Controls.Add(txtIDBudget);
            Controls.Add(materialLabel1);
            Controls.Add(materialLabel9);
            Controls.Add(btnClearBudget);
            Controls.Add(btnEditBudget);
            Controls.Add(btnAddBudget);
            Controls.Add(dgvBudgets);
            Controls.Add(txtComentsBudget);
            Controls.Add(materialLabel12);
            Controls.Add(materialLabel13);
            Controls.Add(materialLabel16);
            Controls.Add(materialLabel17);
            Controls.Add(txtIdWOBudget);
            Controls.Add(materialLabel18);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMBudget";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Presupuesto";
            Load += FRMBudget_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBudgets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialButton btnClearBudget;
        private MaterialSkin.Controls.MaterialButton btnEditBudget;
        private MaterialSkin.Controls.MaterialButton btnAddBudget;
        private DataGridView dgvBudgets;
        private MaterialSkin.Controls.MaterialTextBox txtComentsBudget;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        private MaterialSkin.Controls.MaterialLabel materialLabel17;
        private MaterialSkin.Controls.MaterialTextBox txtIdWOBudget;
        private MaterialSkin.Controls.MaterialLabel materialLabel18;
        private MaterialSkin.Controls.MaterialTextBox txtIDBudget;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox mcbPlateTransDataBudget;
        private MaterialSkin.Controls.MaterialComboBox mcbBudgetStatementBudget;
        private MaterialSkin.Controls.MaterialComboBox mcbBrandsBudget;
    }
}