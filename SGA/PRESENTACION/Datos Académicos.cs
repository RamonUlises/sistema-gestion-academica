using SGA.Clases;
using SGA.MBControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;


namespace SGA.PRESENTACION
{
    public partial class Datos_académicos : Form
    {
        public Datos_académicos()
        {
            InitializeComponent();
            customizarDiseno();
            PanelHelper.SetRoundPanel(panel2, 25);
            PanelHelper.SetRoundPanel(panel3, 25);
            PanelHelper.SetRoundPanel(panel4, 25);
            PanelHelper.SetRoundPanel(panel4, 25);
            PanelHelper.SetRoundPanel(panel5, 25);
            PanelHelper.SetRoundPanel(panel6, 25);
            PanelHelper.SetRoundPanel(panel7, 25);
            PanelHelper.SetRoundPanel(panel8, 25);
            PanelHelper.SetRoundPanel(panel9, 25);
            PanelHelper.SetRoundPanel(panel10, 25);
            PanelHelper.SetRoundPanel(panel11, 25);
            PanelHelper.SetRoundPanel(panel12, 25);
            PanelHelper.SetRoundPanel(panel13, 25);
            PanelHelper.SetRoundPanel(panel14, 10);
            PanelHelper.SetRoundPanel(panel15, 10);
            PanelHelper.SetRoundPanel(panel16, 10);
            PanelHelper.SetRoundPanel(panel17, 10);
            PanelHelper.SetRoundPanel(panel18, 25);
            PanelHelper.SetRoundPanel(panel19, 25);
            PanelHelper.SetRoundPanel(panel20, 25);
            PanelHelper.SetRoundPanel(panel21, 25);
            PanelHelper.SetRoundPanel(panel22, 25);
            PanelHelper.SetRoundPanel(panel23, 25);
            PanelHelper.SetRoundPanel(panel24, 25);
            PanelHelper.SetRoundPanel(panel25, 25);
            PanelHelper.SetRoundPanel(panel26, 25);
            PanelHelper.SetRoundPanel(panel27, 25);
            PanelHelper.SetRoundPanel(panel28, 25);
            PanelHelper.SetRoundPanel(panel29, 25);

            DateTime fecha = DateTime.Now;
            txtFechaMatriculaEstudianteDatosAcademicos.Text = fecha.ToString("dd-MM-yyyy");
            txtFechaMatriculaEstudianteDatosAcademicos.Enabled = false;


            cbGradoDatosAcademicos.Items.Add("7");
            cbGradoDatosAcademicos.Items.Add("8");
            cbGradoDatosAcademicos.Items.Add("9");
            cbGradoDatosAcademicos.Items.Add("10");
            cbGradoDatosAcademicos.Items.Add("11");

            cbSeccionDatosAcademicos.Items.Add("A");
            cbSeccionDatosAcademicos.Items.Add("B");
            cbSeccionDatosAcademicos.Items.Add("C");
            cbSeccionDatosAcademicos.Items.Add("D");
            cbSeccionDatosAcademicos.Items.Add("E");
            cbSeccionDatosAcademicos.Items.Add("F");

            cbTurnoDatosAcademicos.Items.Add("Matutino");
            cbTurnoDatosAcademicos.Items.Add("Vespertino");
            cbTurnoDatosAcademicos.Items.Add("Nocturno");
            cbTurnoDatosAcademicos.Items.Add("Sabatino");
            cbTurnoDatosAcademicos.Items.Add("Dominical");
            cbTurnoDatosAcademicos.Items.Add("Diurno");
            cbTurnoDatosAcademicos.Items.Add("Quincenal");
        }
        private void customizarDiseno()
        {
            panel12.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panel12.Visible == true)
                panel12.Visible = false;
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


        private void panelEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Datos_académicos_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mbButton1_Click(object sender, EventArgs e)
        {
          showSubMenu(panel12);
        }

        private void mbButton2_Click(object sender, EventArgs e)
        {
          hideSubMenu();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarDatosAcademicos_Click(object sender, EventArgs e)
        {
            ClassDatosAcademicos datosAcademicos = new ClassDatosAcademicos();
            datosAcademicos.FechaMatricula = txtFechaMatriculaEstudianteDatosAcademicos.Text;
            datosAcademicos.CodigoEstudiante = txtCodigoEstudianteDatosAcademicos.Text;
            datosAcademicos.NombreCentroEducativo = txtNombreCentroDatosAcademicos.Text;
            datosAcademicos.NivelEducativo = txtNivelEducativoDatosAcademicos.Text;
            datosAcademicos.Modalidad = cbModalidadDatosAcademicos.Texts;
            datosAcademicos.Turno = cbTurnoDatosAcademicos.Texts;
            datosAcademicos.Grado = cbGradoDatosAcademicos.Text;
            datosAcademicos.Seccion = cbSeccionDatosAcademicos.Text;

            ValidarResultados validarResultados = datosAcademicos.ValidarCamposVacios();
            if (validarResultados != null)
            {
                MessageBox.Show(validarResultados.message);
                return;
            }

            string repitente = repitenteValidation();
            if (repitente == "Error")
            {
                return;
            }

            datosAcademicos.Repitente = repitente == "Si";

            MessageBox.Show("Datos guardados correctamente");
        }

        public string repitenteValidation()
        {
            if(chRepitenteSiDatosAcademicos.Checked == true && chRepitenteNODatosAcademicos.Checked == true)
            {
                MessageBox.Show("Seleccione solo una opción de repitente");
                return "Error";
            }
            if(chRepitenteSiDatosAcademicos.Checked == false && chRepitenteNODatosAcademicos.Checked == false)
            {
                MessageBox.Show("Seleccione una opción de repitente");
                return "Error";
            }
            if(chRepitenteSiDatosAcademicos.Checked == true)
            {
                return "Si";
            }
            if(chRepitenteNODatosAcademicos.Checked == true)
            {
                return "No";
            }
            
            
            return "Error";
        }
    }
}
