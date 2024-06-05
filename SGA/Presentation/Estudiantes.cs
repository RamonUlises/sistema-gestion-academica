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
    public partial class Estudiantes : Form
    {
        List<Clases.ClassGetEstudiantes> estudiantes = new List<Clases.ClassGetEstudiantes>();

        public Estudiantes()
        {
            InitializeComponent();

            MostrarEstudiantes();
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
            


            Label nombreLabel = new Label
            {
                Text = $"Nombres: {estudiante.Nombres}",
                Location = new Point(10, 10),
                AutoSize = true,
               
                
            };

            PanelHelper.SetRoundPanel(panel, 10);
            Label cedulanombre = new Label
            {
                Text = $"Cedula: {estudiante.Cedula}",
                Location = new Point(400, 10),
                AutoSize = true
            };

            estudiante.FechaNacimiento = ConvertirFecha(estudiante.FechaNacimiento);

            Label fechanacimineto = new Label
            {
                Text = $"Fecha Nacimineto: {estudiante.FechaNacimiento}",
                Location = new Point(10, 35),
                AutoSize = true
            };

            Label direccion = new Label
            {
                Location = new Point(400, 35),
                Text = $"Dirección: {estudiante.Direccion}",
                AutoSize = true
            };

             Label telefono = new Label
             {
                Location = new Point(10, 60),
                Text = $"Telefono: {estudiante.Telefono}",
                AutoSize = true
             };

            Label partidanacimiento = new Label
            {
                Location = new Point(400, 60),
                Text = $"Partida de Nacimiento: {estudiante.PartidaNacimiento}",
                AutoSize = true
            };

            Label fechamatricula = new Label
            {
                Location = new Point(10, 85),
                Text = $"Fecha de Matricula: {ConvertirFecha(estudiante.FechaMatricula)}",
                AutoSize = true
            };
            

            Label barrio = new Label
            {
                Location = new Point(400, 85),
                Text = $"Barrio: {estudiante.Barrio}",
                AutoSize = true
            };

            Label peso = new Label
            {
                Location = new Point(10, 110),
                Text = $"Peso: {estudiante.Peso}Kg",
                AutoSize = true
            };

            Label talla = new Label
            {
                Location = new Point(400, 110),
                Text = $"Talla: {estudiante.Talla}m",
                AutoSize = true
            };

            Label territorioindigena = new Label
            {
                Location = new Point(10, 135),
                Text = $"Territorio Indigena: {estudiante.TerritorioIndigena}",
                AutoSize = true
            };

            Label comunidadindigena = new Label
            {
                Location = new Point(400, 135),
                Text = $"Comunidad Indigena: {estudiante.ComunidadIndigena}",
                AutoSize = true
            };

            Label sexo = new Label
            {
                Location = new Point(10, 160),
                Text = $"Sexo: {estudiante.Sexo}",
                AutoSize = true
            };

            Label pais = new Label
            {
                Location = new Point(400, 160),
                Text = $"Pais: {estudiante.Pais}",
                AutoSize = true
            };

            Label departamento = new Label
            {
                Location = new Point(10, 185),
                Text = $"Departamento: {estudiante.Departamento}",
                AutoSize = true
            };

            Label municipio = new Label
            {
                Location = new Point(400, 185),
                Text = $"Municipio: {estudiante.Municipio}",
                AutoSize = true
            };

            Label nacionalidad = new Label
            {
                Location = new Point(10, 210),
                Text = $"Nacionalidad: {estudiante.Nacionalidad}",
                AutoSize = true
            };

            Label etnia = new Label
            {
                Location = new Point(400, 210),
                Text = $"Etnia: {estudiante.Etnia}",
                AutoSize = true
            };

            Label lengua = new Label
            {
                Location = new Point(10, 235),
                Text = $"Lengua Materna: {estudiante.LenguaMaterna}",
                AutoSize = true
            };

            Label discapacidad = new Label
            {
                Location = new Point(400, 235),
                Text = $"Discapacidad: {estudiante.Discapacidad}",
                AutoSize = true
            };

            Label tutor = new Label
            {
                Location = new Point(10, 260),
                Text = $"Tutor: {estudiante.NombresTutor}",
                AutoSize = true
            };

            Label cedulatutor = new Label
            {
                Location = new Point(400, 260),
                Text = $"Cedula Tutor: {estudiante.CedulaTutor}",
                AutoSize = true
            };

            Label telefonotutor = new Label
            {
                Location = new Point(10, 285),
                Text = $"Telefono Tutor: {estudiante.TelefonoTutor}",
                AutoSize = true
            };

            Label codigoestudiante = new Label
            {
                Location = new Point(400, 285),
                Text = $"Codigo Estudiante: {estudiante.CodigoEstudiante}",
                AutoSize = true
            };

            Label fechamatriculaacademica = new Label
            {
                Location = new Point(10, 310),
                Text = $"Fecha Matricula Academica: {ConvertirFecha(estudiante.FechaMatriculaAcademica)}",
                AutoSize = true
            };

            Label niveleducativo = new Label
            {
                Location = new Point(400, 310),
                Text = $"Nivel Educativo: {estudiante.NivelEducativo}",
                AutoSize = true
            };

            Label repitente = new Label
            {
                Location = new Point(10, 335),
                Text = $"Repitente: {estudiante.Repitente}",
                AutoSize = true
            };

            Label modalidad = new Label
            {
                Location = new Point(400, 335),
                Text = $"Modalidad: {estudiante.Modalidad}",
                AutoSize = true
            };

            Label grado = new Label
            {
                Location = new Point(10, 360),
                Text = $"Grado: {estudiante.Grado}",
                AutoSize = true
            };

            Label seccion = new Label
            {
                Location = new Point(400, 360),
                Text = $"Seccion: {estudiante.Seccion}",
                AutoSize = true
            };

            Label turno = new Label
            {
                Location = new Point(10, 385),
                Text = $"Turno: {estudiante.Turno}",
                AutoSize = true
            };

            Label centroeducativo = new Label
            {
                Location = new Point(10, 415),
                Text = $"Centro Educativo: {estudiante.CentroEducativo}",
                AutoSize = true
            };

         panel.Controls.Add(nombreLabel);
            panel.Controls.Add(cedulanombre);
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
    }
}
