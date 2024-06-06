﻿using SGA.Clases;
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
            PanelHelper.SetRoundPanel(panel2, 10);
            PanelHelper.SetRoundPanel(panel3, 10);
            PanelHelper.SetRoundPanel(panel4, 10);
            PanelHelper.SetRoundPanel(panel4, 10);
            PanelHelper.SetRoundPanel(panel5, 10);
            PanelHelper.SetRoundPanel(panel6, 10);
            PanelHelper.SetRoundPanel(panel7, 10);
            PanelHelper.SetRoundPanel(panel8, 10);
            PanelHelper.SetRoundPanel(panel9, 10);
            PanelHelper.SetRoundPanel(panel10, 10);
            PanelHelper.SetRoundPanel(panel11, 10);
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
            PanelHelper.SetRoundPanel(panel27, 10);
            PanelHelper.SetRoundPanel(panel28, 10);
            PanelHelper.SetRoundPanel(panel29, 10);

            DateTime fecha = DateTime.Now;
            txtFechaMatriculaEstudianteDatosAcademicos.Text = fecha.ToString("dd-MM-yyyy");
            txtFechaMatriculaEstudianteDatosAcademicos.Enabled = false;


            LlenarModalidades();
            LlenarTurno();
            LlenarGrados();
            LlenarSecciones();
            LlenarCentros();
            CamposEnable(false);
        }
        private void LlenarCentros()
        {
            Controllers.ControllerCentros controller = new Controllers.ControllerCentros();

            string[] centros = controller.ObtenerCentros();

            foreach (string centro in centros)
            {
                txtNombreCentroDatosAcademicos.Items.Add(centro);
            }
        }
        private void CamposEnable(bool res)
        {
            txtCodigoEstudianteDatosAcademicos.Enabled = res;
            txtNombreCentroDatosAcademicos.Enabled = res;
            txtNivelEducativoDatosAcademicos.Enabled = res;
            cbModalidadDatosAcademicos.Enabled = res;
            cbTurnoDatosAcademicos.Enabled = res;
            cbGradoDatosAcademicos.Enabled = res;
            cbSeccionDatosAcademicos.Enabled = res;
            chRepitenteSiDatosAcademicos.Enabled = res;
            chRepitenteNODatosAcademicos.Enabled = res;
        }
        private void LlenarSecciones()
        {
            Controllers.ControllerSecciones controller = new Controllers.ControllerSecciones();

            string[] secciones = controller.ObtenerSecciones();

            foreach (string seccion in secciones)
            {
                cbSeccionDatosAcademicos.Items.Add(seccion);
            }
        }
        private void LlenarGrados()
        {
            Controllers.ControllerGrado controller = new Controllers.ControllerGrado();

            string[] grados = controller.ObtenerGrados();

            foreach (string grado in grados)
            {
                cbGradoDatosAcademicos.Items.Add(grado);
            }
        }
        private void LlenarTurno()
        {
            Controllers.ControllerTurnos controller = new Controllers.ControllerTurnos();

            string[] turnos = controller.ObtenerTurnos();

            foreach (string turno in turnos)
            {
                cbTurnoDatosAcademicos.Items.Add(turno);
            }
        }
        private void LlenarModalidades()
        {
            Controllers.ControllerModalidad controller = new Controllers.ControllerModalidad();

            string[] modalidades = controller.ObtenerModalidades();

            foreach (string modalidad in modalidades)
            {
                cbModalidadDatosAcademicos.Items.Add(modalidad);
            }
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
            datosAcademicos.NombreCentroEducativo = txtNombreCentroDatosAcademicos.Texts;
            datosAcademicos.NivelEducativo = txtNivelEducativoDatosAcademicos.Text;
            datosAcademicos.Modalidad = cbModalidadDatosAcademicos.Texts;
            datosAcademicos.Turno = cbTurnoDatosAcademicos.Texts;
            datosAcademicos.Grado = cbGradoDatosAcademicos.Texts;
            datosAcademicos.Seccion = cbSeccionDatosAcademicos.Texts;

            var validarResultados = datosAcademicos.ValidarCamposVacios();
            if (validarResultados.result == false)
            {
                MessageBox.Show(validarResultados.message);
                return;
            }

            var resultado2 = datosAcademicos.ValidarCodigoEstudiante();
            if(resultado2.result == false)
            {
                MessageBox.Show(resultado2.message);
                return;
            }

            string repitente = repitenteValidation();
            if (repitente == "Error")
            {
                return;
            }

            datosAcademicos.Repitente = repitente == "Si";

            Controllers.ControllerDatosAcademicos controller = new Controllers.ControllerDatosAcademicos();

            string resultado = controller.AgregarDatosAcademicos(datosAcademicos, Convert.ToInt32(txtCodigoTemporalEstudiante.Text));

            if(resultado == "Datos académicos agregados correctamente")
            {
                bool res = MessageBox.Show("Desea imprimir el comprobante", resultado, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                if (res)
                {
                    showSubMenu(panel12);
                }
                LimpiarCajas();
                CamposEnable(false);
            }
            else
            {
                MessageBox.Show(resultado);
            }
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

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LimpiarCajas()
        {
            txtCodigoEstudianteDatosAcademicos.Text = "";
            txtNombreCentroDatosAcademicos.SelectedItem = null;
            txtNivelEducativoDatosAcademicos.Text = "";
            cbModalidadDatosAcademicos.SelectedItem = null;
            cbTurnoDatosAcademicos.SelectedItem = null;
            cbGradoDatosAcademicos.SelectedItem = null;
            cbSeccionDatosAcademicos.SelectedItem = null;
            chRepitenteSiDatosAcademicos.Checked = false;
            chRepitenteNODatosAcademicos.Checked = false;
            txtCodigoTemporalEstudiante.Text = "";
            txtNombresDelEstudiante.Text = "";
            
            txtCodigoTemporalEstudiante.Enabled = true;
        }
        private void mbButton4_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbTurnoDatosAcademicos_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCodigoEstudianteDatosAcademicos__TextChanged(object sender, EventArgs e)
        {

        }

        private void cbModalidadDatosAcademicos_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbGradoDatosAcademicos_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox5__TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNivelEducativoDatosAcademicos__TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSeccionDatosAcademicos_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreCentroDatosAcademicos__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chRepitenteNODatosAcademicos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chRepitenteSiDatosAcademicos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void mbBuscarEstudiante_Click(object sender, EventArgs e)
        {
            txtNombresDelEstudiante.Text = "";
            if(txtCodigoTemporalEstudiante.Text == "")
            {
                MessageBox.Show("Ingrese un código de estudiante");
                return;
            }

            Controllers.ControllerEstudiante controller = new Controllers.ControllerEstudiante();

            string pattern = @"^\d+(\.\d+)?$";

            if (!Regex.IsMatch(txtCodigoTemporalEstudiante.Text, pattern))
            {
                MessageBox.Show("El código temporal debe ser un número");
                return;
            }

            string nombresEstudiantes = controller.obtenerNombresEstudiante(Convert.ToInt32(txtCodigoTemporalEstudiante.Text));

            if(nombresEstudiantes == "Estudiante no encontrado")
            {
                MessageBox.Show("Estudiante no encontrado");
                return;
            }

            txtNombresDelEstudiante.Text = nombresEstudiantes;
            txtCodigoTemporalEstudiante.Enabled = false;

            CamposEnable(true);

        }
    }
}
