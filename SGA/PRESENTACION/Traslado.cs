﻿using SGA.MBControl;
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
         
            PanelHelper.SetRoundPanel(panel2, 10);
            PanelHelper.SetRoundPanel(panel3, 10);
            PanelHelper.SetRoundPanel(panel4, 10);
            PanelHelper.SetRoundPanel(panel5, 10);
            PanelHelper.SetRoundPanel(panel6, 10);
            PanelHelper.SetRoundPanel(panel7, 10);
            PanelHelper.SetRoundPanel(panel8, 10);
            PanelHelper.SetRoundPanel(panel9, 10);
            PanelHelper.SetRoundPanel(panel10, 10);
            PanelHelper.SetRoundPanel(panel11, 10);
            PanelHelper.SetRoundPanel(panel12, 10);
            PanelHelper.SetRoundPanel(panel13, 10);
            PanelHelper.SetRoundPanel(panel14, 10);
            PanelHelper.SetRoundPanel(panel15, 10);
            PanelHelper.SetRoundPanel(panel16, 10);
            PanelHelper.SetRoundPanel(panel17, 10);
            PanelHelper.SetRoundPanel(panel18, 10);
            PanelHelper.SetRoundPanel(panel19, 10);
            PanelHelper.SetRoundPanel(panel20, 10);
            PanelHelper.SetRoundPanel(panel21, 10);
            PanelHelper.SetRoundPanel(panel22, 10);
            PanelHelper.SetRoundPanel(panel23, 10);
            PanelHelper.SetRoundPanel(panel24, 10);
            PanelHelper.SetRoundPanel(panel25, 10);
            PanelHelper.SetRoundPanel(panel26, 10);
            PanelHelper.SetRoundPanel(panel27, 10);
            PanelHelper.SetRoundPanel(panel28, 10);
            PanelHelper.SetRoundPanel(panel29, 10);
            PanelHelper.SetRoundPanel(panel30, 10);
            PanelHelper.SetRoundPanel(panel31, 10);
            PanelHelper.SetRoundPanel(panel32, 10);
            PanelHelper.SetRoundPanel(panel33, 10);
            PanelHelper.SetRoundPanel(panel34, 10);
            PanelHelper.SetRoundPanel(panel35, 10);
            PanelHelper.SetRoundPanel(panel36, 10);
            PanelHelper.SetRoundPanel(panel37, 10);
            PanelHelper.SetRoundPanel(panel38, 10);
            PanelHelper.SetRoundPanel(panel39, 10);
            PanelHelper.SetRoundPanel(panel40, 10);
            PanelHelper.SetRoundPanel(panel41, 10);
            PanelHelper.SetRoundPanel(panel42, 10);
            PanelHelper.SetRoundPanel(panel43, 10);

           

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
            mbComboBox1.Visible = true;
            panel43.Visible = true;
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
            mbComboBox1.Visible = false;
            panel43.Visible = false;

        }

        private void btnBuscarCodigoUnicoTraslado_Click(object sender, EventArgs e)
        {
          
        }

     
    }
}
