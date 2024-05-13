namespace SGA.PRESENTACION
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mbButton2 = new SGA.MBControl.MBButton();
            this.mbTexbox2 = new SGA.MBControl.MBTexbox();
            this.mbTexbox1 = new SGA.MBControl.MBTexbox();
            this.mbButton1 = new SGA.MBControl.MBButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1682, 910);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(257, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1169, 695);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(618, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "¡Bienvenido al sistema de gestión académica! \r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(47, 164);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(189, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 108);
            this.label1.TabIndex = 2;
            this.label1.Text = "Instituto Nacional\nReino de Suecia - Estelí";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel3.Controls.Add(this.mbButton2);
            this.panel3.Controls.Add(this.mbTexbox2);
            this.panel3.Controls.Add(this.mbTexbox1);
            this.panel3.Controls.Add(this.mbButton1);
            this.panel3.Location = new System.Drawing.Point(672, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(403, 434);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // mbButton2
            // 
            this.mbButton2.BackColor = System.Drawing.Color.SeaShell;
            this.mbButton2.BackgroundColor = System.Drawing.Color.SeaShell;
            this.mbButton2.BorderColor = System.Drawing.Color.Transparent;
            this.mbButton2.BorderRadius = 10;
            this.mbButton2.BorderSize = 1;
            this.mbButton2.FlatAppearance.BorderSize = 0;
            this.mbButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbButton2.ForeColor = System.Drawing.Color.Black;
            this.mbButton2.Location = new System.Drawing.Point(110, 313);
            this.mbButton2.Name = "mbButton2";
            this.mbButton2.Size = new System.Drawing.Size(158, 40);
            this.mbButton2.TabIndex = 3;
            this.mbButton2.Text = "Iniciar ";
            this.mbButton2.TextColor = System.Drawing.Color.Black;
            this.mbButton2.UseVisualStyleBackColor = false;
            this.mbButton2.Click += new System.EventHandler(this.mbButton2_Click);
            // 
            // mbTexbox2
            // 
            this.mbTexbox2.BackColor = System.Drawing.Color.SeaShell;
            this.mbTexbox2.BorderColor = System.Drawing.Color.Transparent;
            this.mbTexbox2.BorderFocusColor = System.Drawing.Color.Transparent;
            this.mbTexbox2.BorderRadius = 10;
            this.mbTexbox2.BorderSize = 1;
            this.mbTexbox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mbTexbox2.ForeColor = System.Drawing.Color.Black;
            this.mbTexbox2.Location = new System.Drawing.Point(44, 202);
            this.mbTexbox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mbTexbox2.Multiline = false;
            this.mbTexbox2.Name = "mbTexbox2";
            this.mbTexbox2.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.mbTexbox2.PasswordChar = false;
            this.mbTexbox2.PlaceholderColor = System.Drawing.Color.Black;
            this.mbTexbox2.PlaceholderText = "Contraseña";
            this.mbTexbox2.Size = new System.Drawing.Size(301, 35);
            this.mbTexbox2.TabIndex = 2;
            this.mbTexbox2.UnderlineStyle = false;
            // 
            // mbTexbox1
            // 
            this.mbTexbox1.BackColor = System.Drawing.Color.SeaShell;
            this.mbTexbox1.BorderColor = System.Drawing.Color.Transparent;
            this.mbTexbox1.BorderFocusColor = System.Drawing.Color.Transparent;
            this.mbTexbox1.BorderRadius = 10;
            this.mbTexbox1.BorderSize = 1;
            this.mbTexbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mbTexbox1.ForeColor = System.Drawing.Color.Black;
            this.mbTexbox1.Location = new System.Drawing.Point(44, 136);
            this.mbTexbox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mbTexbox1.Multiline = true;
            this.mbTexbox1.Name = "mbTexbox1";
            this.mbTexbox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.mbTexbox1.PasswordChar = false;
            this.mbTexbox1.PlaceholderColor = System.Drawing.Color.Black;
            this.mbTexbox1.PlaceholderText = "Usuario";
            this.mbTexbox1.Size = new System.Drawing.Size(301, 35);
            this.mbTexbox1.TabIndex = 1;
            this.mbTexbox1.UnderlineStyle = false;
            this.mbTexbox1._TextChanged += new System.EventHandler(this.mbTexbox1__TextChanged_1);
            // 
            // mbButton1
            // 
            this.mbButton1.BackColor = System.Drawing.Color.SeaShell;
            this.mbButton1.BackgroundColor = System.Drawing.Color.SeaShell;
            this.mbButton1.BorderColor = System.Drawing.Color.SeaShell;
            this.mbButton1.BorderRadius = 10;
            this.mbButton1.BorderSize = 1;
            this.mbButton1.FlatAppearance.BorderSize = 0;
            this.mbButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbButton1.ForeColor = System.Drawing.Color.Black;
            this.mbButton1.Location = new System.Drawing.Point(127, -3);
            this.mbButton1.Name = "mbButton1";
            this.mbButton1.Size = new System.Drawing.Size(158, 40);
            this.mbButton1.TabIndex = 0;
            this.mbButton1.Text = "Iniciar sesión";
            this.mbButton1.TextColor = System.Drawing.Color.Black;
            this.mbButton1.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 910);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MBControl.MBTexbox mbTexbox1;
        private MBControl.MBButton mbButton1;
        private MBControl.MBTexbox mbTexbox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MBControl.MBButton mbButton2;
    }
}