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

namespace SGA.Presentation
{
    public partial class Editar_Estudiante : Form
    {
        int idEstudiante;
        public Editar_Estudiante(Clases.ITEstudiantes estudiante)
        {
            InitializeComponent();
            // quitar bordes al formulario
            this.FormBorderStyle = FormBorderStyle.None;
            // hacer que el formulario aparesca en el centro.
            this.StartPosition = FormStartPosition.CenterScreen;
            // crearle un sombreado al borde del formulario
            this.pnlEditar.Paint += new PaintEventHandler(DrawRoundedRectangle);
            // formulario del tamaño de la pantalla
            //this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);


            LlenarEstudiante(estudiante);
            idEstudiante = estudiante.Id;

            txtCodigoEstudiante.Enabled = false;
        }

        private void LlenarEstudiante(Clases.ITEstudiantes estudiante)
        {
            string[] nombres = estudiante.Nombres.Split(' ');
            txtCedula.Text = estudiante.Cedula;
            txtNombre1.Text = nombres[0];
            txtNombre2.Text = nombres[1];
            txtApellido1.Text = nombres[2];
            txtApellido2.Text = nombres[3];

            // Cambiar formato de fecha de / a -
            string newFecha = estudiante.FechaNacimiento.Replace("/", "-");

            txtFechaNacimiento.Text = newFecha;
            txtDireccion.Text = estudiante.Direccion;
            txtTelefono.Text = estudiante.Telefono;
            txtPeso.Text = estudiante.Peso.ToString();
            txtTalla.Text = estudiante.Talla.ToString();
            txtTerritorioIndigena.Text = estudiante.TerritorioIndigena;
            txtComunidadIndigena.Text = estudiante.ComunidadIndigena;
            txtNacionalidad.Text = estudiante.Nacionalidad;
            txtBarrio.Text = estudiante.Barrio;
            txtCodigoEstudiante.Text = estudiante.CodigoEstudiante;
            txtNivelEducativo.Text = estudiante.NivelEducativo;

            LlenarPartidaNacimiento(estudiante.PartidaNacimiento);
            LlenarSexoEstudiante(estudiante.Sexo);
            LlenarRepitente(estudiante.Repitente);

            cbPaisNacimento.Texts = estudiante.Pais;
            cbDepartamento.Texts = estudiante.Departamento;
            cbMunicipio.Texts = estudiante.Municipio;
            cbEtnia.Texts = estudiante.Etnia;
            cbDiscapacidad.Texts = estudiante.Discapacidad;
            cbLenguaMaterna.Texts = estudiante.LenguaMaterna;
            cbGrado.Texts = estudiante.Grado;
            cbSeccion.Texts = estudiante.Seccion;
            cbTurno.Texts = estudiante.Turno;
            cbModalidad.Texts = estudiante.Modalidad;
            cbCentroEducativo.Texts = estudiante.CentroEducativo;
            cbTurno.Texts = estudiante.Turno;

            LimpiarItemsComboBox();
            LlenarItemsComboBox();
        }
        private void LlenarItemsComboBox()
        {
            LlenarPais();
            LlenarDepartamento(4);
            //LlenarMunicipio();
            LlenarEtnia();
            LlenarDiscapacidad();
            LlenarLenguaMaterna();
            LlenarGrado();
            LlenarSeccion();
            LlenarTurno();
            LlenarModalidad();
            LlenarCentroEducativo();
            LlenarTurno();
        }
        private void LlenarPais()
        {
            string[] paises = new Controllers.ControllerPais().ObtenerPaises();

            foreach (string pais in paises)
            {
                cbPaisNacimento.Items.Add(pais);
            }
        }
        private void LlenarDepartamento(int id)
        {
            string[] departamentos = new Controllers.ControllerDepartamentos().ObtenerDepartamentos(id);

            foreach (string departamento in departamentos)
            {
                cbDepartamento.Items.Add(departamento);
            }
        }
        private void LlenarMunicipio(int id)
        {
            string[] municipios = new Controllers.ControllerMunicipios().ObtenerMunicipios(id);

            foreach (string municipio in municipios)
            {
                cbMunicipio.Items.Add(municipio);
            }
        }
        private void LlenarEtnia()
        {
            string[] etnias = new Controllers.ControllerEtnias().ObtenerEtnias();

            foreach (string etnia in etnias)
            {
                cbEtnia.Items.Add(etnia);
            }
        }
        private void LlenarDiscapacidad()
        {
            string[] discapacidades = new Controllers.ControllerDiscapacidad().ObtenerDiscapacidades();

            foreach (string discapacidad in discapacidades)
            {
                cbDiscapacidad.Items.Add(discapacidad);
            }
        }
        private void LlenarLenguaMaterna()
        {
            string[] lenguas = new Controllers.ControllerLenguaMaterna().ObtenerLenguas();

            foreach (string lengua in lenguas)
            {
                cbLenguaMaterna.Items.Add(lengua);
            }
        }
        private void LlenarGrado()
        {
            string[] grados = new Controllers.ControllerGrado().ObtenerGrados();

            foreach (string grado in grados)
            {
                cbGrado.Items.Add(grado);
            }
        }
        private void LlenarSeccion()
        {
            string[] secciones = new Controllers.ControllerSecciones().ObtenerSecciones();

            foreach (string seccion in secciones)
            {
                cbSeccion.Items.Add(seccion);
            }
        }
        private void LlenarTurno()
        {
            string[] turnos = new Controllers.ControllerTurnos().ObtenerTurnos();

            foreach (string turno in turnos)
            {
                cbTurno.Items.Add(turno);
            }
        }
        private void LlenarModalidad()
        {
            string[] modalidades = new Controllers.ControllerModalidad().ObtenerModalidades();

            foreach (string modalidad in modalidades)
            {
                cbModalidad.Items.Add(modalidad);
            }
        }
        private void LlenarCentroEducativo()
        {
            string[] centros = new Controllers.ControllerCentros().ObtenerCentros();

            foreach (string centro in centros)
            {
                cbCentroEducativo.Items.Add(centro);
            }
        }
        private void LimpiarItemsComboBox()
        {
            cbPaisNacimento.Items.Clear();
            cbDepartamento.Items.Clear();
            cbMunicipio.Items.Clear();
            cbEtnia.Items.Clear();
            cbDiscapacidad.Items.Clear();
            cbLenguaMaterna.Items.Clear();
            cbGrado.Items.Clear();
            cbSeccion.Items.Clear();
            cbTurno.Items.Clear();
            cbModalidad.Items.Clear();
            cbCentroEducativo.Items.Clear();
            cbTurno.Items.Clear();
        }

        public void LlenarRepitente(bool repitente)
        {
            if (repitente)
            {
                chRepitenteSi.Checked = true;
                chRepitenteNo.Checked = false;
            }
            else
            {
                chRepitenteSi.Checked = false;
                chRepitenteNo.Checked = true;
            }
        }
        public void LlenarSexoEstudiante(string sexo)
        {
            if (sexo == "Masculino")
            {
                chSexoMas.Checked = true;
                chSexoFem.Checked = false;
            }
            else
            {
                chSexoMas.Checked = false;
                chSexoFem.Checked = true;
            }
        }
        public void LlenarPartidaNacimiento(bool partidaNacimiento)
        {
            if (partidaNacimiento)
            {
                chPartidaNacimeintoSi.Checked = true;
                ChParitdaNacimientoNo.Checked = false;
            }
            else
            {
                chPartidaNacimeintoSi.Checked = false;
                ChParitdaNacimientoNo.Checked = true;
            }
        }
        private void DrawRoundedRectangle(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlEditar.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        private void Editar_Estudiante_Load(object sender, EventArgs e)
        {

        }

        private void pnlEditar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbButton3_Click(object sender, EventArgs e)
        {
            bool response = MessageBox.Show("¿Está seguro que desea cancelar la edición del estudiante?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            
            if(response) this.Close();
        }

        private void panel72_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbButton4_Click(object sender, EventArgs e)
        {

        }
        private bool ValidarPartidaNacimiento()
        {
            if(chPartidaNacimeintoSi.Checked && ChParitdaNacimientoNo.Checked)
            {
                MessageBox.Show("Debe seleccionar solo una opción para la partida de nacimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(chPartidaNacimeintoSi.Checked == false && ChParitdaNacimientoNo.Checked == false)
            {
                MessageBox.Show("Debe seleccionar una opción para la partida de nacimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool ValidarSexo()
        {
            if(chSexoMas.Checked && chSexoFem.Checked)
            {
                MessageBox.Show("Debe seleccionar solo una opción para el sexo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(chSexoMas.Checked == false && chSexoFem.Checked == false)
            {
                MessageBox.Show("Debe seleccionar una opción para el sexo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarLongitudEstudiante()
        {
            bool res;
            string pattern = @"^\d+(\.\d+)?$";


            if (txtNombre1.Text.Length > 100)
            {
                MessageBox.Show("El nombre no puede tener más de 100 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNombre2.Text.Length > 100)
            {
                MessageBox.Show("El segundo nombre no puede tener más de 100 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtApellido1.Text.Length > 100)
            {
                MessageBox.Show("El primer apellido no puede tener más de 100 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtApellido2.Text.Length > 100)
            {
                MessageBox.Show("El segundo apellido no puede tener más de 100 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCedula.Text.Length > 16)
            {
                MessageBox.Show("La cédula no puede tener más de 16 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(txtFechaNacimiento.Text.Length > 10)
            {
                MessageBox.Show("La fecha de nacimiento no puede tener más de 10 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDireccion.Text.Length > 200)
            {
                MessageBox.Show("La dirección no puede tener más de 200 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTelefono.Text.Length > 9)
            {
                MessageBox.Show("El teléfono no puede tener más de 9 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            res = ValidarPartidaNacimiento();
            if(!res) return false;

            res = ValidarSexo();
            if(!res) return false;

            if (txtPeso.Text.Length > 5)
            {
                MessageBox.Show("El peso no puede tener más de 5 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTalla.Text.Length > 5)
            {
                MessageBox.Show("La talla no puede tener más de 5 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(txtPeso.Text, pattern))
            {
                MessageBox.Show("El peso debe ser un número");
                return false;
            }

            if (!Regex.IsMatch(txtTalla.Text, pattern))
            {
                MessageBox.Show("La talla debe ser un número");
                return false;
            }

            if (txtTerritorioIndigena.Text.Length > 200)
            {
                MessageBox.Show("El territorio indígena no puede tener más de 200 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtComunidadIndigena.Text.Length > 200)
            {
                MessageBox.Show("La comunidad indígena no puede tener más de 200 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtBarrio.Text.Length > 100)
            {
                MessageBox.Show("El barrio no puede tener más de 100 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarEditarEstudiante()
        {
            if(txtNombre1.Text.Length > 0)
            {
                return true;
            }
            if(txtNombre2.Text.Length > 0)
            {
                return true;
            }
            if(txtApellido1.Text.Length > 0)
            {
                return true;
            }
            if(txtApellido2.Text.Length > 0)
            {
                return true;
            }
            if(txtCedula.Text.Length > 0)
            {
                return true;
            }
            if(txtFechaNacimiento.Text.Length > 0)
            {
                return true;
            }
            if(txtDireccion.Text.Length > 0)
            {
                return true;
            }
            if(txtTelefono.Text.Length > 0)
            {
                return true;
            }
            if(txtPeso.Text.Length > 0)
            {
                return true;
            }
            if(txtTalla.Text.Length > 0)
            {
                return true;
            }
            if(txtTerritorioIndigena.Text.Length > 0)
            {
                return true;
            }
            if(txtComunidadIndigena.Text.Length > 0)
            {
                return true;
            }
            if(txtBarrio.Text.Length > 0)
            {
                return true;
            }
            if(txtNacionalidad.Text.Length > 0)
            {
                return true;
            }
            if(cbPaisNacimento.Texts.Length > 0)
            {
                return true;
            }
            if(cbDepartamento.Texts.Length > 0)
            {
                return true;
            }
            if(cbMunicipio.Texts.Length > 0)
            {
                return true;
            }
            if(cbEtnia.Texts.Length > 0)
            {
                return true;
            }
            if(cbLenguaMaterna.Texts.Length > 0)
            {
                return true;
            }
            if(cbDiscapacidad.Texts.Length > 0)
            {
                return true;
            }
            if(chSexoMas.Checked || chSexoFem.Checked)
            {
                return true;
            }
            if(chPartidaNacimeintoSi.Checked || ChParitdaNacimientoNo.Checked)
            {
                return true;
            }


            return false;
        }
        private void btnGuardarMatricula_Click(object sender, EventArgs e)
        {

            Clases.ClassEstudiantes estudiante = new Clases.ClassEstudiantes();
            Clases.ClassDatosAcademicos datosAcademicos = new Clases.ClassDatosAcademicos();

            estudiante.Nombre1 = "No editar";
            datosAcademicos.CodigoEstudiante = "No editar";

            bool respo = ValidarEditarEstudiante();
            bool response;

            if (respo)
            {

                response = ValidarLongitudEstudiante();
                if (!response) return;

                estudiante.Nombre1 = txtNombre1.Text;
                estudiante.Nombre2 = txtNombre2.Text;
                estudiante.Apellido1 = txtApellido1.Text;
                estudiante.Apellido2 = txtApellido2.Text;
                estudiante.Cedula = txtCedula.Text;
                estudiante.PartidaNacimiento = chPartidaNacimeintoSi.Checked;
                estudiante.FechaNacimiento = txtFechaNacimiento.Text;
                estudiante.Telefono = txtTelefono.Text;
                estudiante.Direccion = txtDireccion.Text;
                estudiante.Barrio = txtBarrio.Text;
                estudiante.Peso = double.Parse(txtPeso.Text);
                estudiante.Talla = double.Parse(txtTalla.Text);
                estudiante.TerritorioIndigena = txtTerritorioIndigena.Text;
                estudiante.ComunidadIndigena = txtComunidadIndigena.Text;
                estudiante.Sexo = chSexoMas.Checked ? "Masculino" : "Femenino";
                estudiante.Pais = cbPaisNacimento.Texts;
                estudiante.Departamento = cbDepartamento.Texts;
                estudiante.Municipio = cbMunicipio.Texts;
                estudiante.Nacionalidad = txtNacionalidad.Text;
                estudiante.Etnia = cbEtnia.Texts;
                estudiante.Lengua = cbLenguaMaterna.Texts;
                estudiante.Discapacidad = cbDiscapacidad.Texts;
                estudiante.NombresTutor = "Hola";
                estudiante.CedulaTutor = "Hola";
                estudiante.TelefonoTutor = "Hola";

                var res = estudiante.ValidarNombres();
                if (res.result == false)
                {
                    MessageBox.Show(res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                res = estudiante.ValidarApellidos();
                if (res.result == false)
                {
                    MessageBox.Show(res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                res = estudiante.ValidarCedula();
                if (res.result == false)
                {
                    MessageBox.Show(res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                res = estudiante.ValidarTelefono();
                if (res.result == false)
                {
                    MessageBox.Show(res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                res = estudiante.ValidarEspacios();
                if (res.result == false)
                {
                    MessageBox.Show(res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                res = estudiante.ValidarPesoTalla();
                if (res.result == false)
                {
                    MessageBox.Show(res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                res = estudiante.ValidarFechaNacimiento();
                if (res.result == false)
                {
                    MessageBox.Show(res.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Validar Datos Academicos

            bool editarDatos = ValidarEditarDatos();

            if (editarDatos)
            {
                response = ValidarLongitudDatos();

                if (!response) return;

                datosAcademicos.CodigoEstudiante = txtCodigoEstudiante.Text;
                datosAcademicos.NivelEducativo = txtNivelEducativo.Text;
                datosAcademicos.Grado = cbGrado.Texts;
                datosAcademicos.Seccion = cbSeccion.Texts;
                datosAcademicos.Turno = cbTurno.Texts;
                datosAcademicos.Modalidad = cbModalidad.Texts;
                datosAcademicos.NombreCentroEducativo = cbCentroEducativo.Texts;
                datosAcademicos.Repitente = chRepitenteSi.Checked;

                var res2 = datosAcademicos.ValidarCamposVacios();
                if (res2.result == false)
                {
                    MessageBox.Show(res2.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                res2 = datosAcademicos.ValidarCodigoEstudiante();
                if (res2.result == false)
                {
                    MessageBox.Show(res2.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if(ValidarEditarDatos() == false && ValidarEditarEstudiante() == false)
            {
                MessageBox.Show("No se ha editado ningún campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string resultado = new Controllers.ControllerEstudiante().EditarEstudiante(estudiante, datosAcademicos, idEstudiante);

            if (resultado == "1")
            {
                MessageBox.Show("Estudiante editado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarEditarDatos()
        {
            if(txtCodigoEstudiante.Text.Length > 0)
            {
                return true;
            }
            if(txtNivelEducativo.Text.Length > 0)
            {
                return true;
            }
            if(cbGrado.Texts.Length > 0)
            {
                return true;
            }
            if(cbSeccion.Texts.Length > 0)
            {
                return true;
            }
            if(cbTurno.Texts.Length > 0)
            {
                return true;
            }
            if(cbModalidad.Texts.Length > 0)
            {
                return true;
            }
            if(cbCentroEducativo.Texts.Length > 0)
            {
                return true;
            }
            if(chRepitenteSi.Checked || chRepitenteNo.Checked)
            {
                return true;
            }

            return false;
        }

        private bool ValidarLongitudDatos()
        {
            if(txtCodigoEstudiante.Text.Length > 20)
            {
                MessageBox.Show("El código del estudiante no puede tener más de 20 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtNivelEducativo.Text.Length > 100)
            {
                MessageBox.Show("El nivel educativo no puede tener más de 100 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool res = ValidarRepitente();

            if(!res) return false;

            return true;
        }

        private bool ValidarRepitente()
        {
            if(chRepitenteSi.Checked && chRepitenteNo.Checked)
            {
                MessageBox.Show("Debe seleccionar solo una opción para repitente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(chRepitenteSi.Checked == false && chRepitenteNo.Checked == false)
            {
                MessageBox.Show("Debe seleccionar una opción para repitente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void txtLenguaMaternaMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel77_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }

        private void txtDiscapacidadMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel76_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label91_Click(object sender, EventArgs e)
        {

        }

        private void label92_Click(object sender, EventArgs e)
        {

        }

        private void cbEtniaMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel73_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void cbNacionalidadMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDepartamentoMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMuniciopioMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPaisNacimentoMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBarrioMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel59_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void panel60_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void panel61_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void panel74_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label89_Click(object sender, EventArgs e)
        {

        }

        private void panel75_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label90_Click(object sender, EventArgs e)
        {

        }

        private void txtComunidadIndigenaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel58_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void txtTerritorioIndigenaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel57_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox28__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel53_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void chSexoMasMatricula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chSexoFemMatricula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox29__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel54_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox30__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel55_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void ChParitdaNacimientoNo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chPartidaNacimeintoSi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox42__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel70_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label80_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox6__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox7__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox8__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox9__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox10__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox12__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox13__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void panel46_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void panel47_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox24__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel48_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void panel49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox27__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel52_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox31__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel56_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox32__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel62_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void TxtDireccionMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel63_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox38__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox39__TextChanged(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox40__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel64_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaNacimientoMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel65_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void panel66_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void txt2NombreMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel67_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void panel68_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void txt1NombreMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel69_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void panel71_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox41__TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label86_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void cbSeccion_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTurno_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCentroEducativo_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbGrado_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbModalidad_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
