using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.MBControl
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string title, string message)
        {
            InitializeComponent();
            lblTitle.Text = message;
            lblMessage.Text = message;

            this.StartPosition = FormStartPosition.CenterScreen;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
        }
        public static DialogResult Show(string message, string title)
        {
            using (CustomMessageBox customMessageBox = new CustomMessageBox(message, title))
            {
                return customMessageBox.ShowDialog();
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            
        }
        private void CustomMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void btnYes_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
