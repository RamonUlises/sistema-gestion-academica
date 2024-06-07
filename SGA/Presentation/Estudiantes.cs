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
using System.Windows.Forms;

namespace SGA
{
    public partial class Estudiantes : Form
    {
        List<Clases.ClassGetEstudiantes> estudiantes = new List<Clases.ClassGetEstudiantes>();

        private Timer typingTimer;
        public Estudiantes()
        {
            InitializeComponent();
            MostrarEstudiantes();

            typingTimer = new Timer();
            typingTimer.Interval = 2000;
            typingTimer.Tick += TypingTimer_Tick;

            txtBuscarEstudiantes._TextChanged += new EventHandler(this.txtBuscarEstudiantes_TextChanged);
        }

        public void txtBuscarEstudiantes_TextChanged(object sender, EventArgs e)
        {
            typingTimer.Stop();
            typingTimer.Start();
        }

        public void TypingTimer_Tick(object sender, EventArgs e)
        {
            typingTimer.Stop();

            BuscarEstudiantes(txtBuscarEstudiantes.Text);
        }

        public void BuscarEstudiantes(string texto)
        {
            flowLayoutPanel1.Controls.Clear();

            if(texto == "")
            {
                MostrarEstudiantes();
                return;
            }

            estudiantes = new Controllers.ControllerDatosAcademicos().BuscarEstudiantesIndex(texto);

            if(estudiantes.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados");
                return;
            }

            foreach (Clases.ITEstudiantes estudiante in estudiantes)
            {
                Panel Card = CrearCard(estudiante);
                flowLayoutPanel1.Controls.Add(Card);
            }
        }
        public void MostrarEstudiantes()
        {
            estudiantes = new Controllers.ControllerEstudiante().ObtenerEstudiantes();

            foreach(Clases.ITEstudiantes estudiante in estudiantes)
            {
                Panel Card = CrearCard(estudiante);
                flowLayoutPanel1.Controls.Add(Card);
            }
        }

        public Panel CrearCard(Clases.ITEstudiantes estudiante)
        {

            Panel panelBorde = new Panel()
            {
                Width = 10,
                Height = 580,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.Black,
                Location = new Point(10, 10)
            };

            Panel panel = new Panel()
            {
                Width = 1000,
                Height = 600,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor  = Color.FromArgb (235, 239, 242),             
            };
            
            panel.Controls.Add(panelBorde);
            PanelHelper.SetRoundPanel(panel, 10);
            
            estudiante.FechaNacimiento = ConvertirFecha(estudiante.FechaNacimiento);
            string PartidaNacimiento = (estudiante.PartidaNacimiento == true) ? "Si" : "No";
            string repite = (estudiante.Repitente == false) ? "No" : "Si";

            Label nombreEstudiante = CrearLabel(10, 10, "Nombre", estudiante.Nombres);
            Label cedula = CrearLabel(400, 10, "Cedula", estudiante.Cedula);
            Label fechanacimineto = CrearLabel(10, 35, "Fecha Nacimineto", estudiante.FechaNacimiento);
            Label direccion = CrearLabel(400, 35, "Direccion", estudiante.Direccion);
            Label telefono = CrearLabel(10, 60, "Telefono", estudiante.Telefono);
            Label partidanacimiento = CrearLabel(400, 60, "Partida de Nacimiento", PartidaNacimiento);
            Label fechamatricula = CrearLabel(10, 85, "Fecha de Matricula", ConvertirFecha(estudiante.FechaMatricula));
            Label barrio = CrearLabel(400, 85, "Barrio", estudiante.Barrio);
            Label peso = CrearLabel(10, 110, "Peso", estudiante.Peso + "Kg");
            Label talla = CrearLabel(400, 110, "Talla", estudiante.Talla + "m");
            Label territorioindigena = CrearLabel(10, 135, "Territorio Indigena", estudiante.TerritorioIndigena);
            Label comunidadindigena = CrearLabel(400, 135, "Comunidad Indigena", estudiante.ComunidadIndigena);
            Label sexo = CrearLabel(10, 160, "Sexo", estudiante.Sexo);
            Label pais = CrearLabel(400, 160, "Pais", estudiante.Pais);
            Label departamento = CrearLabel(10, 185, "Departamento", estudiante.Departamento);
            Label municipio = CrearLabel(400, 185, "Municipio", estudiante.Municipio);
            Label nacionalidad = CrearLabel(10, 210, "Nacionalidad", estudiante.Nacionalidad);
            Label etnia = CrearLabel(400, 210, "Etnia", estudiante.Etnia);
            Label lengua = CrearLabel(10, 235, "Lengua Materna", estudiante.LenguaMaterna);
            Label discapacidad = CrearLabel(400, 235, "Discapacidad", estudiante.Discapacidad);
            Label tutor = CrearLabel(10, 260, "Tutor", estudiante.NombresTutor);
            Label cedulatutor = CrearLabel(400, 260, "Cedula Tutor", estudiante.CedulaTutor);
            Label telefonotutor = CrearLabel(10, 285, "Telefono Tutor", estudiante.TelefonoTutor);
            Label codigoestudiante = CrearLabel(400, 285, "Codigo Estudiante", estudiante.CodigoEstudiante);
            Label fechamatriculaacademica = CrearLabel(10, 310, "Fecha Matricula Academica", ConvertirFecha(estudiante.FechaMatriculaAcademica));
            Label niveleducativo = CrearLabel(400, 310, "Nivel Educativo", estudiante.NivelEducativo);
            Label repitente = CrearLabel(10, 335, "Repitente", repite);
            Label modalidad = CrearLabel(400, 335, "Modalidad", estudiante.Modalidad);
            Label grado = CrearLabel(10, 360, "Grado", estudiante.Grado);
            Label seccion = CrearLabel(400, 360, "Seccion", estudiante.Seccion);
            Label turno = CrearLabel(10, 385, "Turno", estudiante.Turno);
            Label centroeducativo = CrearLabel(10, 415, "Centro Educativo", estudiante.CentroEducativo);

            MBButton btnEditar = new MBButton()
            {
                Text = "Editar",
                Size = new Size(100, 40),
                Location = new Point(10, 450),
                BackgroundColor = Color.FromArgb(1, 111, 185),
                TextColor = Color.White,
                BorderRadius = 10
            };

            btnEditar.Click += (sender, e) =>
            {
                MostrarComprobanteTraslado(estudiante.Id);
            };

            panel.Controls.Add(btnEditar);

            panel.Controls.Add(nombreEstudiante);
            panel.Controls.Add(cedula);
            panel.Controls.Add(fechanacimineto);
            panel.Controls.Add(direccion);
            panel.Controls.Add(telefono);
            panel.Controls.Add(partidanacimiento);
            panel.Controls.Add(fechamatricula);
            panel.Controls.Add(barrio);
            panel.Controls.Add(peso);
            panel.Controls.Add(talla);
            panel.Controls.Add(territorioindigena);
            panel.Controls.Add(comunidadindigena);
            panel.Controls.Add(sexo);
            panel.Controls.Add(pais);
            panel.Controls.Add(departamento);
            panel.Controls.Add(municipio);
            panel.Controls.Add(nacionalidad);
            panel.Controls.Add(etnia);
            panel.Controls.Add(lengua);
            panel.Controls.Add(discapacidad);
            panel.Controls.Add(tutor);
            panel.Controls.Add(cedulatutor);
            panel.Controls.Add(telefonotutor);
            panel.Controls.Add(codigoestudiante);
            panel.Controls.Add(fechamatriculaacademica);
            panel.Controls.Add(niveleducativo);
            panel.Controls.Add(repitente);
            panel.Controls.Add(modalidad);
            panel.Controls.Add(grado);
            panel.Controls.Add(seccion);
            panel.Controls.Add(turno);
            panel.Controls.Add(centroeducativo);
            
            return panel;
        }
        public void MostrarComprobanteTraslado(int id)
        {
            
        }
        public Label CrearLabel(int x, int y, string nombre, string texto)
        {
            Label label = new Label
            {
                Location = new Point(x, y),
                Text = $"{nombre}: {texto}",
                AutoSize = true
            };

            return label;
        }

        public string ConvertirFecha(string fecha)
        {
            string[] fechaArray = fecha.Split(' ');
            
            return fechaArray[0];
        }
        private void Estudiantes_Load(object sender, EventArgs e)
        {

        }

        private void mbButton1_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox2__TextChanged(object sender, EventArgs e)
        {
          

        }

        private void mbComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mbComboBox1_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void mbComboBox1_OnSelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void mbTexbox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBuscarEstudiantes__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
