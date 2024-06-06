namespace SGA
{
    partial class Estudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBuscarEstudiantes = new SGA.MBControl.MBTexbox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1664, 902);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 156);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1640, 734);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBuscarEstudiantes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1664, 150);
            this.panel2.TabIndex = 0;
            // 
            // txtBuscarEstudiantes
            // 
            this.txtBuscarEstudiantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarEstudiantes.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscarEstudiantes.BorderColor = System.Drawing.Color.Black;
            this.txtBuscarEstudiantes.BorderFocusColor = System.Drawing.Color.Black;
            this.txtBuscarEstudiantes.BorderRadius = 20;
            this.txtBuscarEstudiantes.BorderSize = 1;
            this.txtBuscarEstudiantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarEstudiantes.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarEstudiantes.Location = new System.Drawing.Point(470, 52);
            this.txtBuscarEstudiantes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscarEstudiantes.Multiline = false;
            this.txtBuscarEstudiantes.Name = "txtBuscarEstudiantes";
            this.txtBuscarEstudiantes.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBuscarEstudiantes.PasswordChar = false;
            this.txtBuscarEstudiantes.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtBuscarEstudiantes.PlaceholderText = "Buscar...";
            this.txtBuscarEstudiantes.Size = new System.Drawing.Size(854, 35);
            this.txtBuscarEstudiantes.TabIndex = 0;
            this.txtBuscarEstudiantes.UnderlineStyle = false;
            this.txtBuscarEstudiantes._TextChanged += new System.EventHandler(this.txtBuscarEstudiantes__TextChanged);
            // 
            // Estudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 902);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Estudiantes";
            this.Text = "Estudiantes";
            this.Load += new System.EventHandler(this.Estudiantes_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MBControl.MBTexbox txtBuscarEstudiantes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}