using SGA.Clases;
using SGA.Connection;
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
using MySql.Data.MySqlClient;

namespace SGA
{
    public partial class Matrícula : Form
    {
       
        public Matrícula()
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
            PanelHelper.SetRoundPanel(panel44, 10);

            DateTime fecha = DateTime.Now;
            txtFechaMatricula.Text = fecha.ToString("dd-MM-yyyy");

            LlenarPaises();
            LlenarEtnias();
            LlenarLenguas();
            LlenarDiscapacidades();

            cbPaisNacimentoMatricula.OnSelectedIndexChanged += new EventHandler(cbPaisNacimentoMatricula_SelectedIndexChanged);

            txtDepartamentoMatricula.Items.Clear();

            txtDepartamentoMatricula.OnSelectedIndexChanged += new EventHandler(txtDepartamentoMatricula_SelectedIndexChanged);

            txtMuniciopioMatricula.Enabled = false;
            txtMuniciopioMatricula.Items.Clear();

            LlenarDepartamentos(4);
        }
        public void LlenarFormularioPrueba()
        {
            txt1NombreMatricula.Text = "Ramón";
            txt2NombreMatricula.Text = "Ulises";
            txt1ApellidoMatricula.Text = "Hernández";
            txt2ApellidoMatricula.Text = "Talavera";
            txtCedulaMatricula.Text = "161-230505-1003V";
            txtFechaNacimientoMatricula.Text = "23-05-2005";
            txtPesoMatricula.Text = "50";
            txtTallaMatricula.Text = "160";
            txtTelefonoMatricula.Text = "5781-0634";
            txtBarrioMatricula.Text = "Betania";
            TxtDireccionMatricula.Text = "Monasterio, 2c al oeste";
            chPartidaNacimeintoSi.Checked = true;
            chSexoMasMatricula.Checked = true;

            txtNombresApellidosTutorMatricula.Text = "Ruth Carmen Talavera Centeno";
            txtCedulaTutorMatricula.Text = "161-230505-1007V";
            txtTelefonoTutorMatricula.Text = "8708-8407";
        }
        public void LlenarDiscapacidades()
        {
            Controllers.ControllerDiscapacidad controller = new Controllers.ControllerDiscapacidad();

            string[] discapacidades = controller.ObtenerDiscapacidades();

            if (discapacidades.Length == 0)
            {
                MessageBox.Show("Error al cargar las discapacidades: " + discapacidades[0]);
                return;
            }

            txtDiscapacidadMatricula.Items.Clear();
            foreach (string discapacidad in discapacidades)
            {
                txtDiscapacidadMatricula.Items.Add(discapacidad);
            }
        }
        public void LlenarLenguas()
        {
            Controllers.ControllerLenguaMaterna controller = new Controllers.ControllerLenguaMaterna();

            string[] lenguas = controller.ObtenerLenguas();

            if (lenguas.Length == 0)
            {
                MessageBox.Show("Error al cargar las lenguas: " + lenguas[0]);
                return;
            }

            txtLenguaMaternaMatricula.Items.Clear();
            foreach (string lengua in lenguas)
            {
                txtLenguaMaternaMatricula.Items.Add(lengua);
            }
        }
        public void LlenarEtnias()
        {
            Controllers.ControllerEtnias controller = new Controllers.ControllerEtnias();

            string[] etnias = controller.ObtenerEtnias();

            if (etnias.Length == 0)
            {
                MessageBox.Show("Error al cargar las etnias: " + etnias[0]);
                return;
            }

            cbEtniaMatricula.Items.Clear();
            foreach (string etnia in etnias)
            {
                cbEtniaMatricula.Items.Add(etnia);
            }
        }
        public void txtDepartamentoMatricula_SelectedIndexChanged(object sender, EventArgs e)
        {     
            if (txtDepartamentoMatricula.Texts == "" || txtDepartamentoMatricula.Texts == null)
            {
                return;
            }
            Controllers.ControllerDepartamentos controller = new Controllers.ControllerDepartamentos();

            int departamento = controller.ObtenerIdDepartamento(txtDepartamentoMatricula.Texts);
            LlenarMunicipios(departamento);                
        }

        public void LlenarMunicipios(int departamento)
        {
            Controllers.ControllerMunicipios controller = new Controllers.ControllerMunicipios();

            string[] municipios = controller.ObtenerMunicipios(departamento);

            if (municipios.Length == 0)
            {
                MessageBox.Show("Error al cargar los municipios: " + municipios[0]);
                return;
            }

            txtMuniciopioMatricula.Items.Clear();
            txtMuniciopioMatricula.Enabled = true;

            foreach (string municipio in municipios)
            {
                txtMuniciopioMatricula.Items.Add(municipio);
            }
        }

        public void cbPaisNacimentoMatricula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbPaisNacimentoMatricula.Texts == "" || cbPaisNacimentoMatricula.Texts == null)
            {
                return;
            }
            Controllers.ControllerPais controller = new Controllers.ControllerPais();
            int pais = controller.ObtenerPaisPorNombre(cbPaisNacimentoMatricula.Texts);
            LlenarNacionalidad(pais);        
        }   
        public void LlenarDepartamentos(int pais)
        {
            Controllers.ControllerDepartamentos controller = new Controllers.ControllerDepartamentos();

            string[] departamentos = controller.ObtenerDepartamentos(pais);


                if (departamentos.Length == 0)
                {
                    MessageBox.Show("Error al cargar los departamentos: " + departamentos[0]);
                    return;
                }

                txtDepartamentoMatricula.Items.Clear();
                txtDepartamentoMatricula.Enabled = true;
                foreach (string departamento in departamentos)
                {
                    txtDepartamentoMatricula.Items.Add(departamento);
                }

        }
        public void LlenarNacionalidad(int pais)
        {
            Controllers.ControllerPais controller = new Controllers.ControllerPais();

            if(pais == 0)
            {
                MessageBox.Show("Error al cargar la nacionalidad: " + pais);
                return;
            }
            string nacionalidad = controller.ObtenerNacionalidad(pais);

            if (nacionalidad == "")
            {
                MessageBox.Show("Error al cargar la nacionalidad: " + nacionalidad);
                return;
            }

            cbNacionalidadMatricula.Text = nacionalidad;
        }       
        public void LlenarPaises()
        {
           Controllers.ControllerPais controller = new Controllers.ControllerPais();

            string[] paises = controller.ObtenerPaises();

            if (paises.Length == 1)
            {
                MessageBox.Show("Error al cargar los paises: " + paises[0]);
                return;
            }

            cbPaisNacimentoMatricula.Items.Clear();
            foreach (string pais in paises)
            {
                cbPaisNacimentoMatricula.Items.Add(pais);
            }
        }
        public string checkedPartidaNacimiento()
        {
            if (chPartidaNacimeintoSi.Checked == true && ChParitdaNacimientoNo.Checked == true) 
            {
               MessageBox.Show("Seleccione solo un tipo de partida de nacimiento");
                return "error";
            } else if (ChParitdaNacimientoNo.Checked == true)
            {
                return "false";
            }
            else if (chPartidaNacimeintoSi.Checked == true)
            {
                return "true";
            }
            else
            {
                MessageBox.Show("Seleccione si el estudiante posee partida de nacimiento");
                return "error";
            }
        }

        public string checkedSexo()
        {
            if(chSexoFemMatricula.Checked == true && chSexoMasMatricula.Checked == true)
            {
                MessageBox.Show("Seleccione solo un tipo de sexo");
                return "";
            }else if (chSexoFemMatricula.Checked == true)
            {
                return "Femenino";
            }
            else if (chSexoMasMatricula.Checked == true)
            {
                return "Masculino";
            }
            else
            {
                MessageBox.Show("Seleccione el sexo del estudiante");
                return "";
            }
        }
        private void btnGuardarMatricula_Click(object sender, EventArgs e)
        {


            ClassEstudiantes estudiante = new ClassEstudiantes();

            // VALIDACION DE CEDULA
            estudiante.Cedula = txtCedulaMatricula.Text;

            var resultCedula = estudiante.ValidarCedula();
            if (!resultCedula.result)
            {
                MessageBox.Show(resultCedula.message);
                return;
            }

            // VALIDACIONES DE NOMBRES Y APELLIDOS
            estudiante.Nombre1 = txt1NombreMatricula.Text;
            estudiante.Nombre2 = txt2NombreMatricula.Text;

            var resultNombre = estudiante.ValidarNombres();
            if (!resultNombre.result)
            {
                MessageBox.Show(resultNombre.message);
                return;
            }

            estudiante.Apellido1 = txt1ApellidoMatricula.Text;
            estudiante.Apellido2 = txt2ApellidoMatricula.Text;

            var resultApellido = estudiante.ValidarApellidos();
            if (!resultApellido.result)
            {
                MessageBox.Show(resultApellido.message);
                return;
            }

            // VALIDACION DE PARTIDA DE NACIMIENTO
            string resPart = checkedPartidaNacimiento();
            if (resPart == "error") return;
            estudiante.PartidaNacimiento = resPart == "true";

            // VALIDACION DE FECHA DE NACIMIENTO
            estudiante.FechaNacimiento = txtFechaNacimientoMatricula.Text;

            var resultFecha = estudiante.ValidarFechaNacimiento();
            if (!resultFecha.result)
            {
                MessageBox.Show(resultFecha.message);
                return;
            }

            // VALIDACION DE SEXO
            string resSexo = checkedSexo();
            if (resSexo == "") return;
            estudiante.Sexo = checkedSexo();

            // VALIDACION DE PESO Y TALLA
            string pattern = @"^\d+(\.\d+)?$";

            if (!Regex.IsMatch(txtPesoMatricula.Text, pattern))
            {
                MessageBox.Show("El peso debe ser un número");
                return;
            }

            if (!Regex.IsMatch(txtTallaMatricula.Text, pattern))
            {
                MessageBox.Show("La talla debe ser un número");
                return;
            }

            estudiante.Peso = Double.Parse(txtPesoMatricula.Text);
            estudiante.Talla = Double.Parse(txtTallaMatricula.Text);

            // VALIDACION DE TELEFONO

            estudiante.Telefono = txtTelefonoMatricula.Text;
            var resTelefono = estudiante.ValidarTelefono();
            if (!resTelefono.result)
            {
                MessageBox.Show(resTelefono.message);
                return;
            }

            // VALIDAR ESPACIOS VACIOS
            estudiante.Pais = cbPaisNacimentoMatricula.Texts;
            estudiante.Nacionalidad = cbNacionalidadMatricula.Text;
            estudiante.Departamento = txtDepartamentoMatricula.Texts;
            estudiante.Municipio = txtMuniciopioMatricula.Texts;
            estudiante.Barrio = txtBarrioMatricula.Text;
            estudiante.Direccion = TxtDireccionMatricula.Text;
            estudiante.Etnia = cbEtniaMatricula.Texts;
            estudiante.ComunidadIndigena = txtComunidadIndigenaMatricula.Text;
            estudiante.TerritorioIndigena = txtTerritorioIndigenaMatricula.Text;
            estudiante.Discapacidad = txtDiscapacidadMatricula.Texts;
            estudiante.Lengua = txtLenguaMaternaMatricula.Texts;
            estudiante.NombresTutor = txtNombresApellidosTutorMatricula.Text;
            estudiante.CedulaTutor = txtCedulaTutorMatricula.Text;
            estudiante.TelefonoTutor = txtTelefonoTutorMatricula.Text;

            var res = estudiante.ValidarEspacios();
            if (!res.result)
            {
                MessageBox.Show(res.message);
                return;
            }


            // VALIDAR NOMBERS DEL TUTOR


            var resultNombreTutor = estudiante.ValidarNombresTutor();
            if (!resultNombreTutor.result)
            {
                MessageBox.Show(resultNombreTutor.message);
                return;
            }

            // VALIDAR CEDULA DEL TUTOR


            var resultCedulaTutor = estudiante.ValidarCedulaTutor();
            if (!resultCedulaTutor.result)
            {
                MessageBox.Show(resultCedulaTutor.message);
                return;
            }

            // VALIDAR TELEFONO DEL TUTOR


            var resultTelefonoTutor = estudiante.ValidarTelefono();
            if (!resultTelefonoTutor.result)
            {
                MessageBox.Show(resultTelefonoTutor.message);
                return;
            }

            DateTime fecha = DateTime.Now;
            estudiante.FechaMatricula = fecha.ToString("dd-MM-yyyy");

            Controllers.ControllerEstudiante controller = new Controllers.ControllerEstudiante();

            string result = controller.AgregarEstudinante(estudiante);
            MessageBox.Show(result);

            string patternnn = @"\b" + Regex.Escape("código temporal del estudiante") + @"\b";

            if(Regex.IsMatch(result, patternnn))
            {
                LimpiarCampos();
            }

        }

        private void Matrícula_Load(object sender, EventArgs e)
        {

        }

        private void mbComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox18__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox17__TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void mbTexbox5__TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox14__TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox13__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox15__TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbComboBox1_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox16__TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel21_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox18__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void mbTexbox19__TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox12__TextChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {
        }

        private void mbTexbox9__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox4__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void cbNacionalidadMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt2ApellidoMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPaisNacimentoMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void txt2NombreMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtTallaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void chSexoMasMatricula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPesoMAtricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox7__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txt1ApellidoMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txt1NombreMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCedulaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox20__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            
        }

        private void mbTexbox4__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtCodigoEstudianteSINFOMtricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefonoTutorMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void txtCedulaTutorMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label28_Click_1(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void txtNombresApellidosTutorMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void panel26_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel23_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click_1(object sender, EventArgs e)
        {

        }

        private void cbNacionalidadMatricula_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txt2ApellidoMatricula__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cbPaisNacimentoMatricula_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void panel24_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label32_Click_1(object sender, EventArgs e)
        {

        }

        private void txt2NombreMatricula__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel25_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label33_Click_1(object sender, EventArgs e)
        {

        }

        private void panel11_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void panel12_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void panel13_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTallaMatricula__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel10_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void chSexoMasMatricula_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void txtPesoMatricula__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel8_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void mbTexbox7__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel9_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void panel7_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void txt1ApellidoMatricula__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void txt1NombreMatricula__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void txtCedulaMatricula__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label30_Click_1(object sender, EventArgs e)
        {

        }

        private void label29_Click_1(object sender, EventArgs e)
        {

        }

        private void mbTexbox20__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtFechaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        public void LimpiarCampos()
        {
            txtCedulaMatricula.Text = "";
            txt1NombreMatricula.Text = "";
            txt2NombreMatricula.Text = "";
            txt1ApellidoMatricula.Text = "";
            txt2ApellidoMatricula.Text = "";
            txtFechaNacimientoMatricula.Text = "";
            chPartidaNacimeintoSi.Checked = false;
            ChParitdaNacimientoNo.Checked = false;
            chSexoFemMatricula.Checked = false;
            chSexoMasMatricula.Checked = false;
            txtPesoMatricula.Text = "";
            txtTallaMatricula.Text = "";
            txtTelefonoMatricula.Text = "";
            cbPaisNacimentoMatricula.SelectedItem = null;
            txtDepartamentoMatricula.SelectedItem = null;
            txtMuniciopioMatricula.SelectedItem = null;
            cbNacionalidadMatricula.Text = "";
            txtBarrioMatricula.Text = "";
            TxtDireccionMatricula.Text = "";
            cbEtniaMatricula.SelectedItem = null;
            txtComunidadIndigenaMatricula.Text = "";
            txtTerritorioIndigenaMatricula.Text = "";
            txtDiscapacidadMatricula.SelectedItem = null;
            txtLenguaMaternaMatricula.SelectedItem = null;
            txtNombresApellidosTutorMatricula.Text = "";
            txtCedulaTutorMatricula.Text = "";
            txtTelefonoTutorMatricula.Text = "";
        }

        private void mbButton1_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txt1NombreMatricula.Focus();
        }
    }
}