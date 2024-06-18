using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Presentation
{
    public partial class Editar_Estudiante : Form
    {

        public Editar_Estudiante(Clases.ITEstudiantes estudiante)
        {
            InitializeComponent();
            // quitar bordes al formulario
            this.FormBorderStyle = FormBorderStyle.None;
            // hacer que el formulario aparesca en el centro.
            this.StartPosition = FormStartPosition.CenterScreen;
            // crearle un sombreado al borde del formulario
            this.pnlEditar.Paint += new PaintEventHandler(DrawRoundedRectangle);

            LlenarEstudiante(estudiante);
        }

        private void LlenarEstudiante(Clases.ITEstudiantes estudiante)
        {
            MessageBox.Show(estudiante.Nombres);
        }

        private void DrawRoundedRectangle(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlEditar.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        private void Editar_Estudiante_Load(object sender, EventArgs e)
        {

        }

        private void pnlEditar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbButton3_Click(object sender, EventArgs e)
        {
            bool response = MessageBox.Show("¿Está seguro que desea cancelar la edición del estudiante?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            
            if(response) this.Close();
        }

        private void panel72_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbButton4_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarMatricula_Click(object sender, EventArgs e)
        {

        }

        private void txtLenguaMaternaMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel77_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }

        private void txtDiscapacidadMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel76_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label91_Click(object sender, EventArgs e)
        {

        }

        private void label92_Click(object sender, EventArgs e)
        {

        }

        private void cbEtniaMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel73_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void cbNacionalidadMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDepartamentoMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMuniciopioMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPaisNacimentoMatricula_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBarrioMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel59_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void panel60_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void panel61_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void panel74_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label89_Click(object sender, EventArgs e)
        {

        }

        private void panel75_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label90_Click(object sender, EventArgs e)
        {

        }

        private void txtComunidadIndigenaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel58_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void txtTerritorioIndigenaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel57_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox28__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel53_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void chSexoMasMatricula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chSexoFemMatricula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox29__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel54_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox30__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel55_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void ChParitdaNacimientoNo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chPartidaNacimeintoSi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox42__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel70_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label80_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox6__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox7__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox8__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox9__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox10__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox12__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox13__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void panel46_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void panel47_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox24__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel48_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void panel49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox27__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel52_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox31__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel56_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox32__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel62_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void TxtDireccionMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel63_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox38__TextChanged(object sender, EventArgs e)
        {

        }

        private void mbTexbox39__TextChanged(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox40__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel64_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaNacimientoMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel65_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void panel66_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void txt2NombreMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel67_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void panel68_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void txt1NombreMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel69_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void panel71_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void mbTexbox41__TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaMatricula__TextChanged(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label86_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }
    }
}
