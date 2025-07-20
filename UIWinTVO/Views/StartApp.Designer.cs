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
            tabPage3 = new TabPage();
            AssetsIcons = new ImageList(components);
            MTCStartapp.SuspendLayout();
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
            MTCStartapp.Size = new Size(1194, 783);
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
            tabPage2.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage2.ImageKey = "CLIENTS.png";
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1186, 740);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Clientes";
            tabPage2.UseVisualStyleBackColor = true;
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
            // StartApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 850);
            Controls.Add(MTCStartapp);
            DrawerTabControl = MTCStartapp;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StartApp";
            Text = "Taller Villalba Oleas";
            MTCStartapp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MTCStartapp;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ImageList AssetsIcons;
    }
}