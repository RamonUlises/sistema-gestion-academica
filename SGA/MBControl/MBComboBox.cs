using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace SGA.MBControl
{
    [DefaultEvent("OnSelectedIndexChanged")]
    class MBComboBox : UserControl
    {
        //fields
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 255);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;

        //items
        private ComboBox cmblist;
        private Label lblText;
        private Button btnIcon;

        //properties

        [Category("MB code - Appearance")]
        public  new Color BackColor
        {
            get
            {
                   return backColor;
            }
            set
            {     
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }

        }
        [Category("MB code - Appearance")]
        public Color IconColor
        {
            get
            {
                   return iconColor;
            }
            set
            {
                   iconColor = value;
                btnIcon.Invalidate();
            }
        }
        [Category("MB code - Appearance")]
        public Color ListBackColor
        {
            get
            {
                return listBackColor;
            }
            set
            {
                listBackColor = value;
                cmblist.BackColor = listBackColor;
            }
        }
        [Category("MB code - Appearance")]
        public Color ListTextColor
        {
            get
            {
                return listTextColor;
            }
            set
            {
                listTextColor = value;
                cmblist.ForeColor = listTextColor;
            }
        }

        [Category("MB code - Appearance")]
        public Color BorderColor 
        { 
            get
            {
                   return borderColor;
            }
            set
            {
                borderColor = value;
                base.BackColor = borderColor;
            }
        }

        [Category("MB code - Appearance")]
        public int BorderSize 
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize);
                AdjustComboBoxDimensions();
              
            }
        }

        [Category("MB code - Appearance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }

        [Category("MB code - Appearance")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmblist.Font = value;
            }
        }

        [Category("MB code - Appearance")]
        public string Text
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }
        [Category("MB code - Appearance")]
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return cmblist.DropDownStyle;
            }
            set
            {
                if(cmblist.DropDownStyle != ComboBoxStyle.Simple) 
                cmblist.DropDownStyle = value;
                
            }
        }
        //data
        [Category("MB code - data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return cmblist.Items;
            }
        }

        [Category("MB code - data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
 
        public object DataSource
        {
            get
            {
                return cmblist.DataSource;
            }
            set
            {
                cmblist.DataSource = value;
            }
        }


        [Category("MB code - data")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
      public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return cmblist.AutoCompleteCustomSource;
            }
            set
            {
                cmblist.AutoCompleteCustomSource = value;
            }
        }


        [Category("MB code - data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return cmblist.AutoCompleteSource;
            }
            set
            {
                cmblist.AutoCompleteSource = value;
            }
        }



        [Category("MB code - data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return cmblist.AutoCompleteMode;
            }
            set
            {
                cmblist.AutoCompleteMode = value;
            }
        }


        [Category("MB code - data")]
        [Browsable (true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get
            {
                return cmblist.SelectedItem;
            }
            set
            {
                cmblist.SelectedItem = value;
            }
        }


        [Category("MB code - data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                return cmblist.SelectedIndex;
            }
            set
            {
                cmblist.SelectedIndex = value;
            }
        }

       

        //events
        public event EventHandler OnSelectedIndexChanged;
        
        //constructor
        public MBComboBox()
        {
            cmblist = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();

            //ComboBox: Drpdown list
            cmblist.BackColor = listBackColor;
            cmblist.Font = new  Font(this.Font.Name,10F);
            cmblist.ForeColor = listTextColor;
            cmblist.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            cmblist.TextChanged += new EventHandler(ComboBox_TextChanged);

            //Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);

            //Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;     
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 10F);
            lblText.Click += new EventHandler(Label_Click);

            //UserControl
            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmblist);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);
            base.BackColor = borderColor;
            this.ResumeLayout();
            AdjustComboBoxDimensions();

        }


        //private methods
        private void AdjustComboBoxDimensions()
        {
        
            cmblist.Width = lblText.Width;
            cmblist.Location = new Point()
            {
                X = this.Width =this.Padding.Right - cmblist.Width,
                Y = lblText.Bottom - cmblist.Height
            };
        }


        //evrnt methods
        private void Label_Click(object sender, EventArgs e)
        {
            //select the combobox
            cmblist.Select();
            if (cmblist.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                cmblist.DroppedDown = true;
            }
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            //fields
            int iconWidth = 14;
            int iconHeight = 6;
            var recction = new Rectangle((btnIcon.Width = iconWidth)  / 2,(btnIcon.Height = iconHeight) / 2, iconWidth, iconHeight);
            Graphics graph = e.Graphics;

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(recction.X, recction.Y, recction.X + (iconWidth/2), recction.Bottom);
                path.AddLine(recction.X + (iconWidth / 2), recction.Bottom, recction.Right, recction.Y);
                graph.DrawPath(pen, path);

            }

        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmblist.Select();
            cmblist.DroppedDown = true; ;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmblist.Text;
         
      
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if(OnSelectedIndexChanged != null)
            {
                OnSelectedIndexChanged.Invoke(sender, e);   
                lblText.Text = cmblist.Text;

            }
        }
    }
}
