using SGA.Clases;
using SGA.MBControl;
using SGA.PRESENTACION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SGA
{
    public partial class Continuidad : Form
    {

        private PrintDocument printDocument;
        private Panel panelToPrint;

        private int marginX = 55;
        private int marginY = 160;
        public Continuidad()
        {
            InitializeComponent();
            PanelHelper.SetRoundPanel(panel2, 10);
            PanelHelper.SetRoundPanel(panel4, 10);
            PanelHelper.SetRoundPanel(panel5, 10);
            PanelHelper.SetRoundPanel(panel8, 10);
            PanelHelper.SetRoundPanel(panel9, 10);
            PanelHelper.SetRoundPanel(panel10, 10);
            PanelHelper.SetRoundPanel(panel12, 10);
            PanelHelper.SetRoundPanel(panel13, 10);
            PanelHelper.SetRoundPanel(panel14, 10);
            PanelHelper.SetRoundPanel(panel15, 10);
            PanelHelper.SetRoundPanel(panel16, 10);
            PanelHelper.SetRoundPanel(panel17, 10);
            PanelHelper.SetRoundPanel(panel18, 10);
            PanelHelper.SetRoundPanel(panel19, 10);
            PanelHelper.SetRoundPanel(panel20, 10);
            PanelHelper.SetRoundPanel(panel21, 10);
            PanelHelper.SetRoundPanel(panel22, 10);
            PanelHelper.SetRoundPanel(panel23, 10);
            PanelHelper.SetRoundPanel(panel24, 10);
            PanelHelper.SetRoundPanel(panel25, 10);
            PanelHelper.SetRoundPanel(panel26, 10);
            customizarDiseno();

            btnGuardarReingreso.Cursor = Cursors.Hand;
            btnBuscarCodigoAlumnoReingreso.Cursor = Cursors.Hand;

            LlenarModalidad();
            LlenarGrados();
            LlenarTurnos();
            LenarSecciones();

            txtNombresAlumnoReingreso.Enabled = false;
            cbGradoReingreso.Enabled = false;
            cbSeccionReingreso.Enabled = false;
            cbTurnoReingreso.Enabled = false;
            mbModalidadReingreso.Enabled = false;

            this.KeyPreview = true;

            this.KeyDown += new KeyEventHandler(Continuidad_KeyDown);

            // Asignar el panel que deseas imprimir (reemplaza 'panel11' con el nombre de tu panel)
            panelToPrint = panel11;

            // Inicializar PrintDocument
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);

            // Configurar la impresión en orientación horizontal
            printDocument.DefaultPageSettings.Landscape = true;

            txtCodigoAlumnoReingreso.Focus();
        }

        private void Continuidad_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BuscarCodigoAlumno();
            }   
        }

        public void LenarSecciones()
        {
            Controllers.ControllerSecciones controllerSecciones = new Controllers.ControllerSecciones();

            string[] secciones = controllerSecciones.ObtenerSecciones();

            foreach (string seccion in secciones)
            {
                cbSeccionReingreso.Items.Add(seccion);
            }
        }
        public void LlenarTurnos()
        {
            Controllers.ControllerTurnos controllerTurnos = new Controllers.ControllerTurnos();

            string[] turnos = controllerTurnos.ObtenerTurnos();

            foreach (string turno in turnos)
            {
                cbTurnoReingreso.Items.Add(turno);
            }
        }
        public void LlenarGrados()
        {
            Controllers.ControllerGrado controllerGrado = new Controllers.ControllerGrado();

            string[] grados = controllerGrado.ObtenerGrados();

            foreach (string grado in grados)
            {
                cbGradoReingreso.Items.Add(grado);
            }
        }
        public void LlenarModalidad()
        {
            Controllers.ControllerModalidad controllerModalidad = new Controllers.ControllerModalidad();

            string[] modalidades = controllerModalidad.ObtenerModalidades();

            foreach (string modalidad in modalidades)
            {
                mbModalidadReingreso.Items.Add(modalidad);
            }
        }
        private void btnGuardarReingreso_Click(object sender, EventArgs e)
        {

            ClassReingreso reingreso = new ClassReingreso();
            reingreso.CodigoAlumno = txtCodigoAlumnoReingreso.Text;
            reingreso.NombreAlumno = txtNombresAlumnoReingreso.Text;
            reingreso.Modalidad = mbModalidadReingreso.Texts;
            reingreso.Turno = cbTurnoReingreso.Texts;
            reingreso.Grado = cbGradoReingreso.Texts;
            reingreso.Seccion = cbSeccionReingreso.Texts;

            var validacion = reingreso.ValidarEspacios();

            if (!validacion.result)
            {
                MessageBox.Show(validacion.message);
                return;
            }

            string mensaje = new Controllers.ControllerContinuidad().RealizarReingreso(reingreso);

            if (MessageBox.Show("¿Desea imprimir el comprobante?", mensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                showSubMenu(panel11);
                LlenarComprobante(reingreso);
            }
            LimpiarCajas();
        }

        public void LlenarComprobante(ClassReingreso reingreso)
        {
            txtCodigoComprobante.Enabled = false;
            txtNombreAlumnoComprobante.Enabled = false;
            txtModalidadComprobante.Enabled = false;
            txtTurnoComprobante.Enabled = false;
            txtGradoComprobante.Enabled = false;
            txtSeccionComprobante.Enabled = false;
            txtCentroComprobante.Enabled = false;
            txtCodigoCentroComprobante.Enabled = false;


            txtCodigoComprobante.Text = reingreso.CodigoAlumno;
            txtNombreAlumnoComprobante.Text = reingreso.NombreAlumno;
            txtModalidadComprobante.Text = reingreso.Modalidad;
            txtTurnoComprobante.Text = reingreso.Turno;
            txtGradoComprobante.Text = reingreso.Grado;
            txtSeccionComprobante.Text = reingreso.Seccion;
            txtCentroComprobante.Text = "Instituto Nacional Reino de Suecia";
            txtCodigoCentroComprobante.Text = "9841";
        }
        private void customizarDiseno()
        {
            panel11.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panel11.Visible == true)
                panel11.Visible = false;
        }

        private void showSubMenu(System.Windows.Forms.Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();

                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        private void Reingreso_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbButton1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel11);
        }

        private void mbButton5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void mbComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }
        //private void CapturePanelScreen()
        //{
        //    memoryImage = new Bitmap(panel11.Width, panel11.Height);
        //    panel11.DrawToBitmap(memoryImage, new Rectangle(0, 0, panel11.Width, panel11.Height));
        //}
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Ajustar las dimensiones para capturar solo la parte del panel que deseas imprimir
            int captureWidth = panelToPrint.Width - 2 * marginX;
            int captureHeight = panelToPrint.Height - marginY;

            // Capturar el contenido del panel en una imagen
            Bitmap bitmap = new Bitmap(captureWidth, captureHeight);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(panelToPrint.PointToScreen(new Point(marginX, 10)), new Point(0, 0), bitmap.Size);
            }

            // Ajustar la imagen al tamaño de la página manteniendo la relación de aspecto
            float panelAspectRatio = (float)bitmap.Width / bitmap.Height;
            float pageAspectRatio = (float)e.PageBounds.Width / e.PageBounds.Height;

            float scaleWidth, scaleHeight;
            
            if (panelAspectRatio > pageAspectRatio)
            {
                scaleWidth = e.PageBounds.Width;
                scaleHeight = e.PageBounds.Width / panelAspectRatio;
            }
            else
            {
                scaleWidth = e.PageBounds.Height * panelAspectRatio;
                scaleHeight = e.PageBounds.Height;
            }

            // Centrar la imagen en la página
            float offsetX = (e.PageBounds.Width - scaleWidth) / 2;
            float offsetY = (e.PageBounds.Height - scaleHeight) / 2;

            // Dibujar la imagen en el documento de impresión
            e.Graphics.DrawImage(bitmap, offsetX, offsetY, scaleWidth, scaleHeight);
        
        }
        private void mbButton4_Click(object sender, EventArgs e)
        {
            // Mostrar el diálogo de impresión
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        public void LimpiarCajas()
        {
            txtCodigoAlumnoReingreso.Text = "";
            txtNombresAlumnoReingreso.Text = "";
            mbModalidadReingreso.SelectedItem = null;
            cbTurnoReingreso.SelectedItem = null;
            cbGradoReingreso.SelectedItem = null;
            cbSeccionReingreso.SelectedItem = null;

            txtCodigoAlumnoReingreso.Enabled = true;
            cbGradoReingreso.Enabled = false;
            cbSeccionReingreso.Enabled = false;
            cbTurnoReingreso.Enabled = false;
            mbModalidadReingreso.Enabled = false;

            txtCodigoAlumnoReingreso.Focus();

        }
        private void mbButton2_Click(object sender, EventArgs e)
        {
            bool res = MessageBox.Show("¿Desea eliminar los datos de las cajas?", "Limpiar cajas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

            if (!res) return;

            LimpiarCajas();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BuscarCodigoAlumno()
        {
            if (txtCodigoAlumnoReingreso.Text == "")
            {
                MessageBox.Show("Ingrese el código del alumno");
                return;
            }

            Controllers.ControllerEstudiante controllerEstudiante = new Controllers.ControllerEstudiante();

            string nombreEstudiante = controllerEstudiante.ObtenerDatosEstudiante(txtCodigoAlumnoReingreso.Text);

            if (nombreEstudiante == "Estudiante no encontrado")
            {
                MessageBox.Show(nombreEstudiante);
                return;
            }

            txtNombresAlumnoReingreso.Text = nombreEstudiante;
            txtCodigoAlumnoReingreso.Enabled = false;
            cbGradoReingreso.Enabled = true;
            cbSeccionReingreso.Enabled = true;
            cbTurnoReingreso.Enabled = true;
            mbModalidadReingreso.Enabled = true;
        }

        private void btnBuscarCodigoAlumnoReingreso_Click(object sender, EventArgs e)
        {
            BuscarCodigoAlumno();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox7__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox4__TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreAlumnoComprobante__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
