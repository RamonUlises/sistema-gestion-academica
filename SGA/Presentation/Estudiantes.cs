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
            Controllers.ControllerEstudiante controllerEstudiantes = new Controllers.ControllerEstudiante();
            InitializeComponent();

            estudiantes = controllerEstudiantes.ObtenerEstudiantes();

            MessageBox.Show(estudiantes[1].Grado);
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
    }
}
