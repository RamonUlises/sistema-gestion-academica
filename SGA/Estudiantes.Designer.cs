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
            this.mbTexbox1 = new SGA.MBControl.MBTexbox();
            this.mbButton2 = new SGA.MBControl.MBButton();
            this.mbButton1 = new SGA.MBControl.MBButton();
            this.mbComboBox1 = new SGA.MBControl.MBComboBox();
            this.SuspendLayout();
            // 
            // mbTexbox1
            // 
            this.mbTexbox1.BackColor = System.Drawing.SystemColors.Window;
            this.mbTexbox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.mbTexbox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mbTexbox1.BorderRadius = 20;
            this.mbTexbox1.BorderSize = 1;
            this.mbTexbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mbTexbox1.ForeColor = System.Drawing.Color.DimGray;
            this.mbTexbox1.Location = new System.Drawing.Point(439, 88);
            this.mbTexbox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mbTexbox1.Multiline = false;
            this.mbTexbox1.Name = "mbTexbox1";
            this.mbTexbox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.mbTexbox1.PasswordChar = false;
            this.mbTexbox1.PlaceholderColor = System.Drawing.Color.Black;
            this.mbTexbox1.PlaceholderText = "paswoord";
            this.mbTexbox1.Size = new System.Drawing.Size(250, 35);
            this.mbTexbox1.TabIndex = 2;
            this.mbTexbox1.UnderlineStyle = false;
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
            // mbComboBox1
            // 
            this.mbComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.mbComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.mbComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mbComboBox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.mbComboBox1.BorderSize = 2;
            this.mbComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.mbComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.mbComboBox1.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.mbComboBox1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(255)))));
            this.mbComboBox1.ListTextColor = System.Drawing.Color.DimGray;
            this.mbComboBox1.Location = new System.Drawing.Point(407, 381);
            this.mbComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.mbComboBox1.Name = "mbComboBox1";
            this.mbComboBox1.Padding = new System.Windows.Forms.Padding(2);
            this.mbComboBox1.Size = new System.Drawing.Size(200, 30);
            this.mbComboBox1.TabIndex = 3;
            this.mbComboBox1.OnSelectedIndexChanged += new System.EventHandler(this.mbComboBox1_OnSelectedIndexChanged_1);
            // 
            // Estudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 657);
            this.Controls.Add(this.mbComboBox1);
            this.Controls.Add(this.mbTexbox1);
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
        private MBControl.MBTexbox mbTexbox1;
        private MBControl.MBComboBox mbComboBox1;
    }
}