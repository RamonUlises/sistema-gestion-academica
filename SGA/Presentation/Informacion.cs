﻿using MiAplicacion;
using SGA.MBControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnManualUsuario_Click(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pdfFileName = "Manual de usuario_SCM.pdf";
            string pdfPath = Path.Combine(desktopPath, pdfFileName);
            try
            {
                Process.Start(new ProcessStartInfo(pdfPath)
                {UseShellExecute = true});
                }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el PDF: " + ex.Message);
            }
        }
    }
}
