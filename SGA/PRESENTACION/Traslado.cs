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
    public partial class Traslado : Form
    {
        public Traslado()
        {
            InitializeComponent();
            PanelHelper.SetRoundPanel(panel2, 20);
            PanelHelper.SetRoundPanel(panel3, 20);
            PanelHelper.SetRoundPanel(panel4, 20);
            PanelHelper.SetRoundPanel(panel5, 20);
            PanelHelper.SetRoundPanel(panel6, 20);

        }

        private void Traslado_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
