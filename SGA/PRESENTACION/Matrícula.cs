using SGA.MBControl;
using SGA.PRESENTACION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SGA
{
    public partial class Matrícula : Form
    {
        //fields
        private Form currentChildForm;
        private System.Windows.Forms.Label tituloFormulario;


        public Matrícula()
        {
            InitializeComponent();
            PanelHelper.SetRoundPanel(panel2, 25);
            PanelHelper.SetRoundPanel(panel3, 25);
            PanelHelper.SetRoundPanel(panel4, 25);
            PanelHelper.SetRoundPanel(panel5, 25);
            PanelHelper.SetRoundPanel(panel6, 25);  
            PanelHelper.SetRoundPanel(panel7, 25);
            PanelHelper.SetRoundPanel(panel8, 25);
            PanelHelper.SetRoundPanel(panel9, 25);
            PanelHelper.SetRoundPanel(panel10, 25);
            PanelHelper.SetRoundPanel(panel11, 25);
            PanelHelper.SetRoundPanel(panel12, 25);
            PanelHelper.SetRoundPanel(panel13, 25);
            PanelHelper.SetRoundPanel(panel14, 25);
            PanelHelper.SetRoundPanel(panel15, 25);
            PanelHelper.SetRoundPanel(panel16, 25);
            PanelHelper.SetRoundPanel(panel17, 25);
            PanelHelper.SetRoundPanel(panel18, 25);
            PanelHelper.SetRoundPanel(panel19, 25);
            PanelHelper.SetRoundPanel(panel20, 25);
            PanelHelper.SetRoundPanel(panel21, 25);
            PanelHelper.SetRoundPanel(panel22, 25);
            PanelHelper.SetRoundPanel(panel23, 25);
            PanelHelper.SetRoundPanel(panel24, 25);
            PanelHelper.SetRoundPanel(panel25, 25);
            PanelHelper.SetRoundPanel(panel26, 25);
        }
        //private void OpenChildForm(Form childForm)
        //{
        //    if (currentChildForm != null)
        //    {
        //        currentChildForm.Close();
        //    }
        //    currentChildForm = childForm;
        //    childForm.TopLevel = false;
        //    childForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    panel1.Controls.Add(childForm);
        //    panel1.Tag = childForm;
        //    childForm.BringToFront();
        //    childForm.Show();
        //    tituloFormulario.Text = childForm.Text;
            
        //}

        private void btnGuardarMatricula_Click(object sender, EventArgs e)
        {
            
        }

        private void Matrícula_Load(object sender, EventArgs e)
        {

        }

        private void mbComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox18__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox17__TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void mbTexbox5__TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox14__TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox13__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox15__TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbComboBox1_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox16__TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel21_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox18__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void mbTexbox19__TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox12__TextChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Datos_académicos frm = new Datos_académicos();
            frm.Show();
            this.Hide();

        }

        private void mbTexbox9__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void mbTexbox4__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void cbNacionalidadMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt2ApellidoMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPaisNacimentoMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void txt2NombreMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtTallaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void chSexoMasMatricula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPesoMAtricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox7__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txt1ApellidoMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txt1NombreMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCedulaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox20__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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