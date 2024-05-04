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
    public partial class comprobante : Form
    {
        public comprobante()
        {
            InitializeComponent();
        }

        private void comprobante_Load(object sender, EventArgs e)
        {

        }

        private void mbButton1_Click(object sender, EventArgs e)
        {
            Datos_académicos frm = new Datos_académicos();
            frm.Show();
            this.Hide();
        }
    }
}
