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
            this.mbButton2 = new SGA.MBControl.MBButton();
            this.mbButton1 = new SGA.MBControl.MBButton();
            this.SuspendLayout();
            // 
            // mbButton2
            // 
            this.mbButton2.BackColor = System.Drawing.Color.White;
            this.mbButton2.BackgroundColor = System.Drawing.Color.White;
            this.mbButton2.BorderColor = System.Drawing.Color.Purple;
            this.mbButton2.BorderRadius = 20;
            this.mbButton2.BorderSize = 1;
            this.mbButton2.FlatAppearance.BorderSize = 0;
            this.mbButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.mbButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.mbButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbButton2.ForeColor = System.Drawing.Color.Purple;
            this.mbButton2.Location = new System.Drawing.Point(355, 314);
            this.mbButton2.Name = "mbButton2";
            this.mbButton2.Size = new System.Drawing.Size(150, 40);
            this.mbButton2.TabIndex = 1;
            this.mbButton2.Text = "mbButton2";
            this.mbButton2.TextColor = System.Drawing.Color.Purple;
            this.mbButton2.UseVisualStyleBackColor = false;
            // 
            // mbButton1
            // 
            this.mbButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.mbButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.mbButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.mbButton1.BorderRadius = 40;
            this.mbButton1.BorderSize = 0;
            this.mbButton1.FlatAppearance.BorderSize = 0;
            this.mbButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbButton1.ForeColor = System.Drawing.Color.White;
            this.mbButton1.Location = new System.Drawing.Point(439, 189);
            this.mbButton1.Name = "mbButton1";
            this.mbButton1.Size = new System.Drawing.Size(150, 40);
            this.mbButton1.TabIndex = 0;
            this.mbButton1.Text = "mbButton1";
            this.mbButton1.TextColor = System.Drawing.Color.White;
            this.mbButton1.UseVisualStyleBackColor = false;
            this.mbButton1.Click += new System.EventHandler(this.mbButton1_Click);
            // 
            // Estudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 657);
            this.Controls.Add(this.mbButton2);
            this.Controls.Add(this.mbButton1);
            this.Name = "Estudiantes";
            this.Text = "Estudiantes";
            this.Load += new System.EventHandler(this.Estudiantes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MBControl.MBButton mbButton1;
        private MBControl.MBButton mbButton2;
    }
}