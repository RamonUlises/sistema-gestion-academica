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
            customizarDiseno();
            PanelHelper.SetRoundPanel(panel2, 20);
            PanelHelper.SetRoundPanel(panel3, 20);
            PanelHelper.SetRoundPanel(panel4, 20);
            PanelHelper.SetRoundPanel(panel5, 20);
            PanelHelper.SetRoundPanel(panel6, 20);

        }
        private void customizarDiseno()
        {
            panel7.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panel7.Visible == true)
                panel7.Visible = false;
        }
        private void showSubMenu(System.Windows.Forms.Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void Traslado_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox13__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox17__TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarMatricula_Click(object sender, EventArgs e)
        {

        }

        private void mbButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnComprobanteTraslado_Click(object sender, EventArgs e)
        {
          
        }

        private void mbButton2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnComprobanteTraslado_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panel7);

        }

        private void btnComprobanteTraslado_Click_2(object sender, EventArgs e)
        {
            showSubMenu(panel7);
        }

        private void btnComprobanteTraslado_Click_3(object sender, EventArgs e)
        {
            showSubMenu(panel7);
        }
    }
}
