namespace UIWinTVO.Views
{
    partial class FRMLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMLogin));
            button1 = new Button();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtbLoginMail = new MaterialSkin.Controls.MaterialTextBox2();
            txtLoginPassword = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            btnLogin = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Image = Properties.Resources.logo_Taller_Oleas_login;
            button1.Location = new Point(73, 88);
            button1.Name = "button1";
            button1.Size = new Size(232, 92);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(137, 205);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(125, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Ingrese su correo:";
            // 
            // txtbLoginMail
            // 
            txtbLoginMail.AnimateReadOnly = false;
            txtbLoginMail.BackgroundImageLayout = ImageLayout.None;
            txtbLoginMail.CharacterCasing = CharacterCasing.Normal;
            txtbLoginMail.Depth = 0;
            txtbLoginMail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtbLoginMail.HideSelection = true;
            txtbLoginMail.LeadingIcon = null;
            txtbLoginMail.Location = new Point(73, 227);
            txtbLoginMail.MaxLength = 32767;
            txtbLoginMail.MouseState = MaterialSkin.MouseState.OUT;
            txtbLoginMail.Name = "txtbLoginMail";
            txtbLoginMail.PasswordChar = '\0';
            txtbLoginMail.PrefixSuffixText = null;
            txtbLoginMail.ReadOnly = false;
            txtbLoginMail.RightToLeft = RightToLeft.No;
            txtbLoginMail.SelectedText = "";
            txtbLoginMail.SelectionLength = 0;
            txtbLoginMail.SelectionStart = 0;
            txtbLoginMail.ShortcutsEnabled = true;
            txtbLoginMail.Size = new Size(250, 48);
            txtbLoginMail.TabIndex = 2;
            txtbLoginMail.TabStop = false;
            txtbLoginMail.Text = "example@tested.com";
            txtbLoginMail.TextAlign = HorizontalAlignment.Center;
            txtbLoginMail.TrailingIcon = null;
            txtbLoginMail.UseSystemPasswordChar = false;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.AnimateReadOnly = false;
            txtLoginPassword.BackgroundImageLayout = ImageLayout.None;
            txtLoginPassword.CharacterCasing = CharacterCasing.Normal;
            txtLoginPassword.Depth = 0;
            txtLoginPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtLoginPassword.HideSelection = true;
            txtLoginPassword.LeadingIcon = null;
            txtLoginPassword.Location = new Point(73, 314);
            txtLoginPassword.MaxLength = 32767;
            txtLoginPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.PasswordChar = '\0';
            txtLoginPassword.PrefixSuffixText = null;
            txtLoginPassword.ReadOnly = false;
            txtLoginPassword.RightToLeft = RightToLeft.No;
            txtLoginPassword.SelectedText = "";
            txtLoginPassword.SelectionLength = 0;
            txtLoginPassword.SelectionStart = 0;
            txtLoginPassword.ShortcutsEnabled = true;
            txtLoginPassword.Size = new Size(250, 48);
            txtLoginPassword.TabIndex = 4;
            txtLoginPassword.TabStop = false;
            txtLoginPassword.Text = "**************";
            txtLoginPassword.TextAlign = HorizontalAlignment.Center;
            txtLoginPassword.TrailingIcon = null;
            txtLoginPassword.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(156, 292);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(86, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Contraseña:";
            // 
            // btnLogin
            // 
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogin.Depth = 0;
            btnLogin.HighEmphasis = true;
            btnLogin.Icon = Properties.Resources.login;
            btnLogin.Image = Properties.Resources.login;
            btnLogin.Location = new Point(137, 392);
            btnLogin.Margin = new Padding(4, 6, 4, 6);
            btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.NoAccentTextColor = Color.Empty;
            btnLogin.Size = new Size(119, 36);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Ingresar";
            btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogin.UseAccentColor = false;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // FRMLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 489);
            Controls.Add(btnLogin);
            Controls.Add(txtLoginPassword);
            Controls.Add(materialLabel2);
            Controls.Add(txtbLoginMail);
            Controls.Add(materialLabel1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 txtbLoginMail;
        private MaterialSkin.Controls.MaterialTextBox2 txtLoginPassword;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton btnLogin;
    }
}