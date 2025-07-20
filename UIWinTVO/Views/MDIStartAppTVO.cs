using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MetroFramework;
using MetroFramework.Components;

namespace UIWinTVO.Views
{
    public partial class MDIStartAppTVO : MetroFramework.Forms.MetroForm
    {
        private int childFormNumber = 0;

        public MDIStartAppTVO()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void MDIStartAppTVO_Load(object sender, EventArgs e)
        {
            // 1. Configurar el estilo del formulario (versión corregida)
            this.StyleManager = new MetroFramework.Components.MetroStyleManager(this.Container);
            this.StyleManager.Theme = MetroFramework.MetroThemeStyle.Light;

            // En versiones recientes de MetroFramework, usa MetroColorStyle en lugar de Custom
            this.StyleManager.Style = MetroFramework.MetroColorStyle.Blue; // Puedes usar cualquier estilo predefinido

            // 2. Crear un degradado personalizado para la barra de título/borde
            var gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, 0), // Dirección horizontal
                Color.FromArgb(255, 0, 0),      // Rojo
                Color.FromArgb(135, 206, 235)); // Azul claro

            // Configurar puntos intermedios del degradado
            var colorBlend = new System.Drawing.Drawing2D.ColorBlend();
            colorBlend.Colors = new Color[] {
                Color.FromArgb(255, 0, 0),      // rgb(255, 0, 0)
                Color.FromArgb(24, 33, 75),     // rgb(24, 33, 75)
                Color.FromArgb(30, 93, 119),   // rgb(30, 93, 119)
                Color.FromArgb(135, 206, 235)  // rgb(135, 206, 235)
            };
            colorBlend.Positions = new float[] { 0f, 0.33f, 0.66f, 1f };
            gradientBrush.InterpolationColors = colorBlend;

            // 3. Aplicar el degradado al formulario
            this.TransparencyKey = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibujar el degradado en la parte superior del formulario (barra de título)
            var gradientRect = new Rectangle(0, 0, this.Width, 5); // Ajusta la altura según necesites
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                gradientRect.Location,
                new Point(gradientRect.Right, gradientRect.Top),
                Color.FromArgb(255, 0, 0),
                Color.FromArgb(135, 206, 235)))
            {
                var colorBlend = new System.Drawing.Drawing2D.ColorBlend();
                colorBlend.Colors = new Color[] {
                    Color.FromArgb(255, 0, 0),
                    Color.FromArgb(24, 33, 75),
                    Color.FromArgb(30, 93, 119),
                    Color.FromArgb(135, 206, 235)
                };
                colorBlend.Positions = new float[] { 0f, 0.33f, 0.66f, 1f };
                brush.InterpolationColors = colorBlend;

                e.Graphics.FillRectangle(brush, gradientRect);
            }
        }
    }
}
