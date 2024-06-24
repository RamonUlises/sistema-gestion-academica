using Org.BouncyCastle.Pqc.Crypto.Frodo;
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
       public string contrasena = "123456789";
        public string usuario = "admin";
        public Login()
        {
            InitializeComponent();
            //PanelHelper.SetRoundPanel(panel2, 10);
            //PanelHelper.SetRoundPanel(panel3, 10);

            // Establecer el color de fondo del panel con una transparencia
            //panel2.BackColor = Color.FromArgb(50, Color.FromArgb(102, 0, 102)); // Opacidad al 50%

            //panel3.BackColor = Color.FromArgb(20, Color.FromArgb(34, 33, 74)); // Opacidad al 50%
            //mbButton2.BackColor = Color.FromArgb(150, Color.FromArgb(34, 33, 74));
      

            // poner el formulario en el centro de la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            //Agregar evento al form al toca la tecla Enter

            this.KeyPreview = true;

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);


            txtUsuarioLogin.Focus();

            // LlenarLogin();
        }

        private void LlenarLogin()
        {
            txtUsuarioLogin.Text = "admin";
            txtcontrasenaLogin.Text = "123456789";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidarUsuario();
            }
        }


        private void ValidarUsuario()
        {
            //Validar usuario y contraseña
            if (txtcontrasenaLogin.Text != contrasena || txtUsuarioLogin.Text != usuario)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //cerrar formulario
            this.Close();
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
            //ControlPaint.DrawBorder(e.Graphics, panel3.ClientRectangle, Color.Orange, ButtonBorderStyle.Solid);
           
        }

        private void mbTexbox1__TextChanged_1(object sender, EventArgs e)
        {
 
        }

        private void mbButton2_Click(object sender, EventArgs e)
        {
            Form1 frmPrincipal = new Form1();
            frmPrincipal.Show();
            this.Hide();

        }

        private void mbButton1_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox2__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbButton1_Click_1(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
