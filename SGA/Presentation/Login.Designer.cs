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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcontrasenaLogin = new SGA.MBControl.MBTexbox();
            this.txtUsuarioLogin = new SGA.MBControl.MBTexbox();
            this.btnIniciar = new SGA.MBControl.MBButton();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 723);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(592, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 61);
            this.label1.TabIndex = 1;
            this.label1.Text = "SCM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(514, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(514, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(524, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sistema Control de Matrícula";
            // 
            // txtcontrasenaLogin
            // 
            this.txtcontrasenaLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.txtcontrasenaLogin.BorderColor = System.Drawing.Color.Black;
            this.txtcontrasenaLogin.BorderFocusColor = System.Drawing.Color.Black;
            this.txtcontrasenaLogin.BorderRadius = 15;
            this.txtcontrasenaLogin.BorderSize = 2;
            this.txtcontrasenaLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontrasenaLogin.ForeColor = System.Drawing.Color.DimGray;
            this.txtcontrasenaLogin.Location = new System.Drawing.Point(508, 366);
            this.txtcontrasenaLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcontrasenaLogin.Multiline = false;
            this.txtcontrasenaLogin.Name = "txtcontrasenaLogin";
            this.txtcontrasenaLogin.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtcontrasenaLogin.PasswordChar = true;
            this.txtcontrasenaLogin.PlaceholderColor = System.Drawing.Color.Black;
            this.txtcontrasenaLogin.PlaceholderText = "";
            this.txtcontrasenaLogin.Size = new System.Drawing.Size(250, 35);
            this.txtcontrasenaLogin.TabIndex = 4;
            this.txtcontrasenaLogin.UnderlineStyle = true;
            // 
            // txtUsuarioLogin
            // 
            this.txtUsuarioLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.txtUsuarioLogin.BorderColor = System.Drawing.Color.Black;
            this.txtUsuarioLogin.BorderFocusColor = System.Drawing.Color.Black;
            this.txtUsuarioLogin.BorderRadius = 15;
            this.txtUsuarioLogin.BorderSize = 2;
            this.txtUsuarioLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioLogin.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuarioLogin.Location = new System.Drawing.Point(508, 285);
            this.txtUsuarioLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsuarioLogin.Multiline = false;
            this.txtUsuarioLogin.Name = "txtUsuarioLogin";
            this.txtUsuarioLogin.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsuarioLogin.PasswordChar = false;
            this.txtUsuarioLogin.PlaceholderColor = System.Drawing.Color.Black;
            this.txtUsuarioLogin.PlaceholderText = "";
            this.txtUsuarioLogin.Size = new System.Drawing.Size(250, 35);
            this.txtUsuarioLogin.TabIndex = 3;
            this.txtUsuarioLogin.UnderlineStyle = true;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Ivory;
            this.btnIniciar.BackgroundColor = System.Drawing.Color.Ivory;
            this.btnIniciar.BorderColor = System.Drawing.Color.Transparent;
            this.btnIniciar.BorderRadius = 15;
            this.btnIniciar.BorderSize = 0;
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.ForeColor = System.Drawing.Color.Black;
            this.btnIniciar.Location = new System.Drawing.Point(561, 482);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(150, 40);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar sesión";
            this.btnIniciar.TextColor = System.Drawing.Color.Black;
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.mbButton1_Click_1);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(186)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(887, 723);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcontrasenaLogin);
            this.Controls.Add(this.txtUsuarioLogin);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private MBControl.MBButton btnIniciar;
        private MBControl.MBTexbox txtUsuarioLogin;
        private MBControl.MBTexbox txtcontrasenaLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}