using SGA.Clases;
using SGA.MBControl;
using SGA.PRESENTACION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            PanelHelper.SetRoundPanel(panel3, 10);
            PanelHelper.SetRoundPanel(panel4, 10);
            PanelHelper.SetRoundPanel(panel5, 10);
            PanelHelper.SetRoundPanel(panel6, 10);
            PanelHelper.SetRoundPanel(panel7, 10);
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
            reingreso.CodigoUnico = txtCodigoUnicoReingreso.Text;
            reingreso.CodigoCentro = txtCodigoCentroReingreso.Text;
            reingreso.Centro = txtCentroReingreso.Text;
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
            
            MessageBox.Show(reingreso.Modalidad);

            string mensaje = new Controllers.ControllerContinuidad().RealizarReingreso(reingreso);

            MessageBox.Show(mensaje);
            LimpiarCajas();
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

        private void mbButton4_Click(object sender, EventArgs e)
        {

        }

        public void LimpiarCajas()
        {
            txtCodigoAlumnoReingreso.Text = "";
            txtNombresAlumnoReingreso.Text = "";
            txtCodigoUnicoReingreso.Text = "";
            txtCodigoCentroReingreso.Text = "";
            txtCentroReingreso.Text = "";
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
    }
}
