namespace UIWinTVO.Views
{
    partial class FRMOrderDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMOrderDetails));
            btnClearOrderDetails = new MaterialSkin.Controls.MaterialButton();
            btnAddDetails = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtIdOTOrderDetails = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            mcbServiceDescriptionOrderDetails = new MaterialSkin.Controls.MaterialComboBox();
            dgvDetailsOrderDetails = new DataGridView();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)dgvDetailsOrderDetails).BeginInit();
            SuspendLayout();
            // 
            // btnClearOrderDetails
            // 
            btnClearOrderDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClearOrderDetails.BackColor = Color.Red;
            btnClearOrderDetails.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClearOrderDetails.Depth = 0;
            btnClearOrderDetails.ForeColor = Color.Red;
            btnClearOrderDetails.HighEmphasis = true;
            btnClearOrderDetails.Icon = Properties.Resources.delete;
            btnClearOrderDetails.Location = new Point(521, 127);
            btnClearOrderDetails.Margin = new Padding(4, 6, 4, 6);
            btnClearOrderDetails.MouseState = MaterialSkin.MouseState.HOVER;
            btnClearOrderDetails.Name = "btnClearOrderDetails";
            btnClearOrderDetails.NoAccentTextColor = Color.Empty;
            btnClearOrderDetails.Size = new Size(107, 36);
            btnClearOrderDetails.TabIndex = 26;
            btnClearOrderDetails.Text = "Limpiar";
            btnClearOrderDetails.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClearOrderDetails.UseAccentColor = false;
            btnClearOrderDetails.UseVisualStyleBackColor = false;
            btnClearOrderDetails.Click += btnClearOrderDetails_Click;
            // 
            // btnAddDetails
            // 
            btnAddDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddDetails.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddDetails.Depth = 0;
            btnAddDetails.HighEmphasis = true;
            btnAddDetails.Icon = Properties.Resources.add;
            btnAddDetails.Location = new Point(521, 79);
            btnAddDetails.Margin = new Padding(4, 6, 4, 6);
            btnAddDetails.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddDetails.Name = "btnAddDetails";
            btnAddDetails.NoAccentTextColor = Color.Empty;
            btnAddDetails.Size = new Size(116, 36);
            btnAddDetails.TabIndex = 24;
            btnAddDetails.Text = "Agregar";
            btnAddDetails.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddDetails.UseAccentColor = false;
            btnAddDetails.UseVisualStyleBackColor = true;
            btnAddDetails.Click += btnAddDetails_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(50, 96);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(45, 19);
            materialLabel1.TabIndex = 27;
            materialLabel1.Text = "ID OT:";
            // 
            // txtIdOTOrderDetails
            // 
            txtIdOTOrderDetails.AnimateReadOnly = false;
            txtIdOTOrderDetails.BorderStyle = BorderStyle.None;
            txtIdOTOrderDetails.Depth = 0;
            txtIdOTOrderDetails.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIdOTOrderDetails.LeadingIcon = null;
            txtIdOTOrderDetails.Location = new Point(101, 79);
            txtIdOTOrderDetails.MaxLength = 50;
            txtIdOTOrderDetails.MouseState = MaterialSkin.MouseState.OUT;
            txtIdOTOrderDetails.Multiline = false;
            txtIdOTOrderDetails.Name = "txtIdOTOrderDetails";
            txtIdOTOrderDetails.Size = new Size(79, 50);
            txtIdOTOrderDetails.TabIndex = 28;
            txtIdOTOrderDetails.Text = "";
            txtIdOTOrderDetails.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(34, 158);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(61, 19);
            materialLabel2.TabIndex = 29;
            materialLabel2.Text = "Servicio:";
            // 
            // mcbServiceDescriptionOrderDetails
            // 
            mcbServiceDescriptionOrderDetails.AutoResize = false;
            mcbServiceDescriptionOrderDetails.BackColor = Color.FromArgb(255, 255, 255);
            mcbServiceDescriptionOrderDetails.Depth = 0;
            mcbServiceDescriptionOrderDetails.DrawMode = DrawMode.OwnerDrawVariable;
            mcbServiceDescriptionOrderDetails.DropDownHeight = 174;
            mcbServiceDescriptionOrderDetails.DropDownStyle = ComboBoxStyle.DropDownList;
            mcbServiceDescriptionOrderDetails.DropDownWidth = 121;
            mcbServiceDescriptionOrderDetails.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            mcbServiceDescriptionOrderDetails.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcbServiceDescriptionOrderDetails.FormattingEnabled = true;
            mcbServiceDescriptionOrderDetails.IntegralHeight = false;
            mcbServiceDescriptionOrderDetails.ItemHeight = 43;
            mcbServiceDescriptionOrderDetails.Location = new Point(101, 142);
            mcbServiceDescriptionOrderDetails.MaxDropDownItems = 4;
            mcbServiceDescriptionOrderDetails.MouseState = MaterialSkin.MouseState.OUT;
            mcbServiceDescriptionOrderDetails.Name = "mcbServiceDescriptionOrderDetails";
            mcbServiceDescriptionOrderDetails.Size = new Size(371, 49);
            mcbServiceDescriptionOrderDetails.StartIndex = 0;
            mcbServiceDescriptionOrderDetails.TabIndex = 30;
            // 
            // dgvDetailsOrderDetails
            // 
            dgvDetailsOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailsOrderDetails.Location = new Point(34, 265);
            dgvDetailsOrderDetails.Name = "dgvDetailsOrderDetails";
            dgvDetailsOrderDetails.Size = new Size(730, 179);
            dgvDetailsOrderDetails.TabIndex = 31;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(36, 245);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(201, 19);
            materialLabel3.TabIndex = 32;
            materialLabel3.Text = "Servicios asociados a la OT:";
            // 
            // FRMOrderDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(materialLabel3);
            Controls.Add(dgvDetailsOrderDetails);
            Controls.Add(mcbServiceDescriptionOrderDetails);
            Controls.Add(materialLabel2);
            Controls.Add(txtIdOTOrderDetails);
            Controls.Add(materialLabel1);
            Controls.Add(btnClearOrderDetails);
            Controls.Add(btnAddDetails);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMOrderDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de OT";
            ((System.ComponentModel.ISupportInitialize)dgvDetailsOrderDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnClearOrderDetails;
        private MaterialSkin.Controls.MaterialButton btnAddDetails;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox txtIdOTOrderDetails;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox mcbServiceDescriptionOrderDetails;
        private DataGridView dgvDetailsOrderDetails;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}