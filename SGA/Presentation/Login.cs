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

namespace SGA.PRESENTACION
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            PanelHelper.SetRoundPanel(panel2, 10);
            PanelHelper.SetRoundPanel(panel3, 10);

            // Establecer el color de fondo del panel con una transparencia
            //panel2.BackColor = Color.FromArgb(50, Color.FromArgb(102, 0, 102)); // Opacidad al 50%

            //panel3.BackColor = Color.FromArgb(20, Color.FromArgb(34, 33, 74)); // Opacidad al 50%
            //mbButton2.BackColor = Color.FromArgb(150, Color.FromArgb(34, 33, 74));
      

        }

        private void btnGuardarMatricula_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox1__TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // Dibuja un borde personalizado alrededor del Panel
            ControlPaint.DrawBorder(e.Graphics, panel3.ClientRectangle, Color.Orange, ButtonBorderStyle.Solid);
           
        }

        private void mbTexbox1__TextChanged_1(object sender, EventArgs e)
        {
 
        }

        private void mbButton2_Click(object sender, EventArgs e)
        {
        
        }

        private void mbButton1_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox2__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
