using MiAplicacion;
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
    public partial class Informacion : Form
    {
        public Informacion()
        {
            InitializeComponent();
            PanelHelper.SetRoundPanel(panel2, 20);
            // Establecer el color de fondo del panel con una transparencia
         panel3.BackColor = Color.FromArgb(128, Color.Black); // Opacidad al 50%
           
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
