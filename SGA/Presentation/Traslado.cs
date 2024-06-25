using SGA.Clases;
using SGA.MBControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA
{
    public partial class Traslado : Form
    {
        public Traslado()
        {
            InitializeComponent();
           
         
            PanelHelper.SetRoundPanel(panel2, 10);
            PanelHelper.SetRoundPanel(panel3, 10);
            PanelHelper.SetRoundPanel(panel4, 10);
            PanelHelper.SetRoundPanel(panel5, 10);
            PanelHelper.SetRoundPanel(panel6, 10);
       

            LlenarPeriodos();
            LlenarCentros();

            txtNombresEstudianteTraslado.Enabled = false;
            txtCentroOrigenTraslado.Enabled = false;
            txtFechaTraslado.Enabled = false;
            txtMotivoTaslado.Enabled = false;
            cbPeriodoTraslado.Enabled = false;

            txtCodigoUnicoEstudianteTraslado.Focus();
        }

        private void LlenarCentros()
        {
            Controllers.ControllerCentros controllerCentros = new Controllers.ControllerCentros();
            string[] centros = controllerCentros.ObtenerCentros();

            foreach (string centro in centros)
            {
                txtCentroOrigenTraslado.Items.Add(centro);
            }
        }

        private void LlenarPeriodos()
        {
            Controllers.ControllerPeriodos controllerPeriodos = new Controllers.ControllerPeriodos();
            string[] periodos = controllerPeriodos.ObtenerPeriodos();

            foreach (string periodo in periodos)
            {
                cbPeriodoTraslado.Items.Add(periodo);
            }
        }
     
       
        private void showSubMenu(System.Windows.Forms.Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
             
             
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
      

        private void Traslado_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox13__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox17__TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarMatricula_Click(object sender, EventArgs e)
        {

        }

        private void mbButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnComprobanteTraslado_Click(object sender, EventArgs e)
        {
          
        }

        private void mbButton2_Click(object sender, EventArgs e)
        {
          
        }

        private void btnComprobanteTraslado_Click_1(object sender, EventArgs e)
        {
            

        }

        private void btnComprobanteTraslado_Click_2(object sender, EventArgs e)
        {
            
        }

        private void btnComprobanteTraslado_Click_3(object sender, EventArgs e)
        {
            

        }

        private void btnBuscarCodigoUnicoTraslado_Click(object sender, EventArgs e)
        {
            if(txtCodigoUnicoEstudianteTraslado.Text == "")
            {
                MessageBox.Show("Por favor ingrese el código único del estudiante");
                return;
            }

            Controllers.ControllerEstudiante controllerEstudiante = new Controllers.ControllerEstudiante();

            string result = controllerEstudiante.ObtenerDatosEstudiante(txtCodigoUnicoEstudianteTraslado.Text);

            if (result == "Estudiante no encontrado")
            {
                MessageBox.Show(result);
                return;
            }

            txtNombresEstudianteTraslado.Text = result;

            txtCentroOrigenTraslado.Enabled = true;
            txtFechaTraslado.Enabled = true;
            txtMotivoTaslado.Enabled = true;
            cbPeriodoTraslado.Enabled = true;
            txtCodigoUnicoEstudianteTraslado.Enabled = false;
        }
        public void LimpiarCampos()
        {
            txtCodigoUnicoEstudianteTraslado.Text = "";
            txtNombresEstudianteTraslado.Text = "";
            txtCentroOrigenTraslado.Texts = null;
            txtFechaTraslado.Text = "";
            txtMotivoTaslado.Text = "";
            cbPeriodoTraslado.SelectedItem = null;

            txtCodigoUnicoEstudianteTraslado.Enabled = true;
            txtNombresEstudianteTraslado.Enabled = false;
            txtCentroOrigenTraslado.Enabled = false;
            txtFechaTraslado.Enabled = false;
            txtMotivoTaslado.Enabled = false;
            cbPeriodoTraslado.Enabled = false;

            txtCodigoUnicoEstudianteTraslado.Focus();
        }

        private void mbButton3_Click(object sender, EventArgs e)
        {
            bool res = MessageBox.Show("¿Desea eliminar los datos de las cajas?", "Limpiar cajas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

            if (!res) return;

            LimpiarCampos();
        }

        private bool ValidarMaxLength()
        {
            if(txtCodigoUnicoEstudianteTraslado.Text.Length > 20)
            {
                MessageBox.Show("El código único del estudiante no puede tener más de 20 caracteres");
                return false;
            }

            if (txtMotivoTaslado.Text.Length > 200)
            {
                MessageBox.Show("El motivo del traslado no puede tener más de 200 caracteres");
                return false;
            }

            return true;
        }

        private void btnGuardartraslado_Click_1(object sender, EventArgs e)
        {

            bool resultLength = ValidarMaxLength();

            if(!resultLength) return;

            ClassTraslado traslado = new ClassTraslado();
            traslado.CodigoEstudiante = txtCodigoUnicoEstudianteTraslado.Text;
            traslado.MotivoTraslado = txtMotivoTaslado.Text;
            traslado.FechaTraslado = txtFechaTraslado.Text;
            traslado.CentroOrigen = txtCentroOrigenTraslado.Texts;
            traslado.PeriodoTraslado = cbPeriodoTraslado.Texts;

            var response = traslado.ValidarCampos();

            if (!response.result)
            {
                MessageBox.Show(response.message);
                return;
            }

            var res = traslado.ValidarFecha();

            if (!res.result)
            {
                MessageBox.Show(res.message);
                return;
            }

            Controllers.ControllerTraslados controllerTraslados = new Controllers.ControllerTraslados();

            string result = controllerTraslados.AgregarTraslado(traslado);

            MessageBox.Show(result, "Registro exitoso");

            LimpiarCampos();
        }

        public void LlenarComprobante(string codigo)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox2__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
