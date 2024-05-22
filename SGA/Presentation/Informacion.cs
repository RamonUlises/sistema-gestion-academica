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
            PanelHelper.SetRoundPanel(panel3, 20);
            PanelHelper.SetRoundPanel(panel4, 20);
            PanelHelper.SetRoundPanel(panel5, 20);
            PanelHelper.SetRoundPanel(panel6, 20);
            PanelHelper.SetRoundPanel(panel7, 20);
            PanelHelper.SetRoundPanel(panel8, 20);
            PanelHelper.SetRoundPanel(panel9, 20);
            PanelHelper.SetRoundPanel(panel10, 20);
            PanelHelper.SetRoundPanel(panel11, 20);
            PanelHelper.SetRoundPanel(panel12, 20);
            PanelHelper.SetRoundPanel(panel13, 20);

            // Establecer el color de fondo del panel con una transparencia
         panel3.BackColor = Color.FromArgb(128, Color.Black); // Opacidad al 50%
           
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
