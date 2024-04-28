using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.MBControl
{
    [DefaultEvent("_TextChanged")]
    public partial class MBTexbox : UserControl
    {

        //fields
        private  Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlineStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;
        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceHolder = false;
        private bool isPasswordChar = false;
        public MBTexbox()
        {
            InitializeComponent();
        }
        //events
        public event EventHandler _TextChanged;

       

        //properties

        [Category("MB Code Advance")]
        public Color BorderColor
      {
            get { return borderColor; }
            set { borderColor = value; 
                this.Invalidate(); 
            }
       }

        [Category("MB Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value;
                this.Invalidate(); 
            }
        }

        [Category("MB Code Advance")]
        public bool UnderlineStyle
        {
            get { return underlineStyle; }
            set { underlineStyle = value;
                this.Invalidate(); 
            }
        }
        [Category("MB Code Advance")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set {
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value; }
        }
        [Category("MB Code Advance")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }
        [Category("MB Code Advance")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        [Category("MB Code Advance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }
        [Category("MB Code Advance")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if(this.DesignMode)
                UpdateControlHeight();
            }
        }
        [Category("MB Code Advance")]
      public string Text
        {
            get
            {
                if (isPlaceHolder)
                    return "";
                else
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceHolder();
            }
        }
        [Category("MB Code Advance")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }
        [Category("MB Code Advance")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }
        [Category("MB Code Advance")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set {
                placeholderColor = value;
                if(isPlaceHolder)
                    textBox1.ForeColor = value;
                          
                       }
        }
        [Category("MB Code Advance")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set { placeholderText = value;
                textBox1.Text = "";
                SetPlaceHolder();
                           
                       }
        }

        private void SetPlaceHolder()
        {
           if(string.IsNullOrEmpty(textBox1.Text) && placeholderText != "")
            {
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                isPlaceHolder = true;
                if(isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = false;
                }
            }
            
        }
        private void RemovePlaceHolder()
        {
            if(isPlaceHolder && placeholderText != "")
            {
                isPlaceHolder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
               
                if (isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = true;
                }
            }
        }



        //oveerride methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            if (borderRadius > 1)
            {
                var rectborderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectborderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize - 1 : 0;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectborderSmooth, borderRadius))
                    using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                    using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                        this.Region = new Region(pathBorderSmooth);
                    if (borderRadius > 15) SetTexboxRoundedRegion();
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;



                    if (underlineStyle)
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                    graphics.SmoothingMode = SmoothingMode.None;
                        
                        graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graphics.DrawPath(penBorder, pathBorder);
    
                    }
                        
                        
                    }
                   

            }
            else
            {  using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                    this.Region = new Region(this.ClientRectangle);
               penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (isFocused)
                
                if (underlineStyle)//line style
                    graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                else//normal style
                    graphics.DrawRectangle(penBorder, 0, 0, this.Width -0.5F, this.Height -0.5F);
                 
                //else
                
                //    penBorder.Color = borderFocusColor;
                //    if (underlineStyle)//line style
                //    graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                //else//normal style
                //    graphics.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                
            }

            }
           //draw border
         
        }

        private void SetTexboxRoundedRegion()
        {

            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle,  borderSize*2);
                textBox1.Region = new Region(pathTxt);

            }
        }

        private GraphicsPath GetFigurePath(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode)
          UpdateControlHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }


        //private methods
        private void UpdateControlHeight()
        {
           if(textBox1.Multiline == false)
            {   int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;
                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);

        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceHolder();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            isFocused = false;
            this.Invalidate();
            SetPlaceHolder();
        }
    }
}
