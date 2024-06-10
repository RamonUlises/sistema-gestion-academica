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
            Panel panel = new Panel()
            {
                Width = 1000,
                Height = 600,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(235, 239, 242)
            };

            // Bordes del panel (opcional)
            Panel panelBorde4 = new Panel
            {
                Width = 975,
                Height = 10,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.Black,
                Location = new Point(10, 580)
            };
            Panel panelBorder3 = new Panel
            {
                Width = 975,
                Height = 10,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.Black,
                Location = new Point(10, 10)
            };
            Panel panelBorde2 = new Panel
            {
                Width = 10,
                Height = 580,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.Black,
                Location = new Point(975, 10)
            };
            Panel panelBorde = new Panel
            {
                Width = 10,
                Height = 580,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.Black,
                Location = new Point(10, 10)
            };

            panel.Controls.Add(panelBorde);
            panel.Controls.Add(panelBorde2);
            panel.Controls.Add(panelBorder3);
            panel.Controls.Add(panelBorde4);

            PanelHelper.SetRoundPanel(panel, 10);

            estudiante.FechaNacimiento = ConvertirFecha(estudiante.FechaNacimiento);
            string PartidaNacimiento = (estudiante.PartidaNacimiento == true) ? "Si" : "No";
            string repite = (estudiante.Repitente == false) ? "No" : "Si";

            // Agregar las etiquetas al panel
            panel.Controls.Add(CrearRichLabel(100, 30, "Nombre", estudiante.Nombres));
            panel.Controls.Add(CrearRichLabel(550, 30, "Cedula", estudiante.Cedula));
            panel.Controls.Add(CrearRichLabel(100, 55, "Fecha Nacimiento", estudiante.FechaNacimiento));
            panel.Controls.Add(CrearRichLabel(550, 55, "Direccion", estudiante.Direccion));
            panel.Controls.Add(CrearRichLabel(100, 80, "Telefono", estudiante.Telefono));
            panel.Controls.Add(CrearRichLabel(550, 80, "Partida de Nacimiento", PartidaNacimiento));
            panel.Controls.Add(CrearRichLabel(100, 105, "Fecha de Matricula", ConvertirFecha(estudiante.FechaMatricula)));
            panel.Controls.Add(CrearRichLabel(550, 105, "Barrio", estudiante.Barrio));
            panel.Controls.Add(CrearRichLabel(100, 130, "Peso", estudiante.Peso + "Kg"));
            panel.Controls.Add(CrearRichLabel(550, 130, "Talla", estudiante.Talla + "m"));
            panel.Controls.Add(CrearRichLabel(100, 155, "Territorio Indigena", estudiante.TerritorioIndigena));
            panel.Controls.Add(CrearRichLabel(550, 155, "Comunidad Indigena", estudiante.ComunidadIndigena));
            panel.Controls.Add(CrearRichLabel(100, 180, "Sexo", estudiante.Sexo));
            panel.Controls.Add(CrearRichLabel(550, 180, "Pais", estudiante.Pais));
            panel.Controls.Add(CrearRichLabel(100, 205, "Departamento", estudiante.Departamento));
            panel.Controls.Add(CrearRichLabel(550, 205, "Municipio", estudiante.Municipio));
            panel.Controls.Add(CrearRichLabel(100, 230, "Nacionalidad", estudiante.Nacionalidad));
            panel.Controls.Add(CrearRichLabel(550, 230, "Etnia", estudiante.Etnia));
            panel.Controls.Add(CrearRichLabel(100, 255, "Lengua Materna", estudiante.LenguaMaterna));
            panel.Controls.Add(CrearRichLabel(550, 255, "Discapacidad", estudiante.Discapacidad));
            panel.Controls.Add(CrearRichLabel(100, 280, "Tutor", estudiante.NombresTutor));
            panel.Controls.Add(CrearRichLabel(550, 280, "Cedula Tutor", estudiante.CedulaTutor));
            panel.Controls.Add(CrearRichLabel(100, 305, "Telefono Tutor", estudiante.TelefonoTutor));
            panel.Controls.Add(CrearRichLabel(550, 305, "Codigo Estudiante", estudiante.CodigoEstudiante));
            panel.Controls.Add(CrearRichLabel(100, 330, "Fecha Matricula Academica", ConvertirFecha(estudiante.FechaMatriculaAcademica)));
            panel.Controls.Add(CrearRichLabel(550, 330, "Nivel Educativo", estudiante.NivelEducativo));
            panel.Controls.Add(CrearRichLabel(100, 355, "Repitente", repite));
            panel.Controls.Add(CrearRichLabel(550, 355, "Modalidad", estudiante.Modalidad));
            panel.Controls.Add(CrearRichLabel(100, 380, "Grado", estudiante.Grado));
            panel.Controls.Add(CrearRichLabel(550, 380, "Seccion", estudiante.Seccion));
            panel.Controls.Add(CrearRichLabel(100, 405, "Turno", estudiante.Turno));
            panel.Controls.Add(CrearRichLabel(100, 435, "Centro Educativo", estudiante.CentroEducativo));

            MBButton btnEditar = new MBButton()
            {
                Text = "Editar",
                Size = new Size(120, 50),
                Location = new Point(420, 500),
                BackgroundColor = Color.FromArgb(1, 111, 185),
                TextColor = Color.White,
                BorderRadius = 15
            };

            btnEditar.Click += (sender, e) =>
            {
                MostrarComprobanteTraslado(estudiante.Id);
                
            };

            panel.Controls.Add(btnEditar);

            return panel;
        }

       

        public RichTextBox CrearRichLabel(int x, int y, string nombre, string texto)
        {
            RichTextBox rtb = new RichTextBox
            {
                Location = new Point(x, y),
                Size = new Size(450, 20),
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(235, 239, 242),
                ReadOnly = true
            };

            // Agregar el texto en negrita
            rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
            rtb.AppendText($"{nombre}:");

            // Agregar el texto normal
            rtb.SelectionFont = new Font(rtb.Font, FontStyle.Regular);
            rtb.AppendText($" {texto}");

            return rtb;
        }

        public string ConvertirFecha(string fecha)
        {
            string[] fechaArray = fecha.Split(' ');

            return fechaArray[0];
        }
      
        public void MostrarComprobanteTraslado(int id)
        {

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
