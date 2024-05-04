namespace SGA.PRESENTACION
{
    partial class comprobante
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
            this.mbButton1 = new SGA.MBControl.MBButton();
            this.SuspendLayout();
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
            this.mbButton1.Location = new System.Drawing.Point(12, 12);
            this.mbButton1.Name = "mbButton1";
            this.mbButton1.Size = new System.Drawing.Size(45, 40);
            this.mbButton1.TabIndex = 0;
            this.mbButton1.Text = "mbButton1";
            this.mbButton1.TextColor = System.Drawing.Color.White;
            this.mbButton1.UseVisualStyleBackColor = false;
            this.mbButton1.Click += new System.EventHandler(this.mbButton1_Click);
            // 
            // comprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 742);
            this.Controls.Add(this.mbButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "comprobante";
            this.Text = "comprobante";
            this.Load += new System.EventHandler(this.comprobante_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MBControl.MBButton mbButton1;
    }
}