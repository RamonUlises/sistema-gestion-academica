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

        public Bitmap CaptureFormImage()
        {
            Bitmap bm = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bm, new Rectangle(0, 0, this.Width, this.Height));
            return bm;
        }

        private Bitmap formImage;

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            if (formImage != null)
            {
                float aspectRatio = (float)formImage.Width / formImage.Height;
                int printWidth = e.PageBounds.Width;
                int printHeight = (int)(e.PageBounds.Width / aspectRatio);

                if (printHeight > e.PageBounds.Height)
                {
                    printHeight = e.PageBounds.Height;
                    printWidth = (int)(e.PageBounds.Height * aspectRatio);
                }

                int x = (e.PageBounds.Width - printWidth) / 2;
                int y = (e.PageBounds.Height - printHeight) / 2;
                e.Graphics.DrawImage(formImage, x, y, printWidth, printHeight);
            }
        }
        private void mbButton4_Click(object sender, EventArgs e)
        {
            formImage = CaptureFormImage();

            PrintDocument printDocument1 = new PrintDocument();

            printDocument1 = new PrintDocument();
            printDocument1.DefaultPageSettings.Landscape = true;
            PrinterSettings ps = new PrinterSettings();

            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
                  
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

        private void btnBuscarCodigoAlumnoReingreso_Click(object sender, EventArgs e)
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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox7__TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }
    }
}
