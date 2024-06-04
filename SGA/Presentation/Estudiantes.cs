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
            Panel panel = new Panel()
            {
                Width = 750,
                Height = 600,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor  = Color.FromArgb (235, 239, 242) ,  
            };
            
            

            PanelHelper.SetRoundPanel(panel, 10);

            Label nombreLabel = new Label
            {
                Text = $"Nombres: {estudiante.Nombres}",
                Location = new Point(10, 15),
                AutoSize = true
            };

            Label cedulanombre = new Label
            {
                Text = $"Cedula: {estudiante.Cedula}",
                Location = new Point(10, 40),
                AutoSize = true
            };
            panel.Controls.Add(nombreLabel);
            panel.Controls.Add(cedulanombre);

            return panel;
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
