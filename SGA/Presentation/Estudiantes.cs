using SGA.MBControl;
using SGA.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA
{
    public partial class Estudiantes : Form
    {
        List<Clases.ClassGetEstudiantes> estudiantes = new List<Clases.ClassGetEstudiantes>();

        private Timer typingTimer;

        PrintDocument printDocument;
        Panel panelToPrint;

        private readonly int marginX = 1;
        private readonly int marginY = 1;

        public Estudiantes()
        {
            InitializeComponent();
            customizarDiseno();

            flowLayoutPanel1.Visible = false;
            MostrarEstudiantes();

            typingTimer = new Timer();
            typingTimer.Interval = 2000;
            typingTimer.Tick += TypingTimer_Tick;

            txtBuscarEstudiantes._TextChanged += new EventHandler(this.txtBuscarEstudiantes_TextChanged);

            // Crear el documento de impresion
            printDocument = new PrintDocument();

            // Asignar el evento de impresion
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);

            // Configurar la impresión en orientación horizontal
            //printDocument.DefaultPageSettings.Landscape = true;

            panelToPrint = pnlTraslado;
        }

        private void PrintDocument1_PrintPage(Object sender, PrintPageEventArgs e)
        {
            int captureWidth = panelToPrint.Width - 2 * marginX;
            int captureHeight = panelToPrint.Height - marginY;

            // Capturar el contenido del panel en una imagen
            Bitmap bitmap = new Bitmap(captureWidth, captureHeight);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(panelToPrint.PointToScreen(new Point(marginX, 10)), new Point(0, 0), bitmap.Size);
            }

            // Ajustar la imagen al tamaño de la página manteniendo la relación de aspecto
            float panelAspectRatio = (float)bitmap.Width / bitmap.Height;
            float pageAspectRatio = (float)e.PageBounds.Width / e.PageBounds.Height;

            float scaleWidth, scaleHeight;

            if (panelAspectRatio > pageAspectRatio)
            {
                scaleWidth = e.PageBounds.Width;
                scaleHeight = e.PageBounds.Width / panelAspectRatio;
            }
            else
            {
                scaleWidth = e.PageBounds.Height * panelAspectRatio;
                scaleHeight = e.PageBounds.Height;
            }

            // Centrar la imagen en la página
            float offsetX = (e.PageBounds.Width - scaleWidth) / 2;
            float offsetY = (e.PageBounds.Height - scaleHeight) / 2;

            // Dibujar la imagen en el documento de impresión
            e.Graphics.DrawImage(bitmap, offsetX, offsetY, scaleWidth, scaleHeight);
        }
        private void mbButton1_Click(object sender, EventArgs e)
        {
            // Mostrar el diálogo de impresión
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        public void txtBuscarEstudiantes_TextChanged(object sender, EventArgs e)
        {
            typingTimer.Stop();
            typingTimer.Start();
        }

        public void TypingTimer_Tick(object sender, EventArgs e)
        {
            typingTimer.Stop();

            BuscarEstudiantes(txtBuscarEstudiantes.Text);
        }

        public void BuscarEstudiantes(string texto)
        {
            flowLayoutPanel1.Controls.Clear();

            if(texto == "")
            {
                MostrarEstudiantes();
                return;
            }

            estudiantes = new Controllers.ControllerDatosAcademicos().BuscarEstudiantesIndex(texto);

            if(estudiantes.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados");
                return;
            }

            flowLayoutPanel1.Visible = false;


            foreach (Clases.ITEstudiantes estudiante in estudiantes)
            {
                Panel Card = CrearCard(estudiante);
                flowLayoutPanel1.Controls.Add(Card);
            }

            flowLayoutPanel1.Visible = true;
        }
        public void MostrarEstudiantes()
        {
            estudiantes = new Controllers.ControllerEstudiante().ObtenerEstudiantes();

            flowLayoutPanel1.Visible = false;
            flowLayoutPanel1.Visible = false;

            foreach(Clases.ITEstudiantes estudiante in estudiantes)
            {
                Panel Card = CrearCard(estudiante);
                flowLayoutPanel1.Controls.Add(Card);
            }

            flowLayoutPanel1.Visible = true;
        }
        public Panel CrearCard(Clases.ITEstudiantes estudiante)
        {
            Panel panel = new Panel()
            {
                Width = 1000,
                Height = 600,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(300, 50, 10, 10),
                BackColor = Color.FromArgb(235, 239, 242),
                Location = new Point(500, 50)   
            };

            Panel panelBorde4 = new Panel
            {
                Width = 975,
                Height = 10,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(26, 25, 62),
                Location = new Point(10, 580)
            };
            Panel panelBorder3 = new Panel
            {
                Width = 975,
                Height = 10,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(26, 25, 62),
                Location = new Point(10, 10)
            };
            Panel panelBorde2 = new Panel
            {
                Width = 10,
                Height = 580,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(26, 25, 62),
                Location = new Point(975, 10)
            };
            Panel panelBorde = new Panel
            {
                Width = 10,
                Height = 580,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(26, 25, 62),
                Location = new Point(10, 10)
            };

            panel.Controls.Add(panelBorde);
            panel.Controls.Add(panelBorde2);
            panel.Controls.Add(panelBorder3);
            panel.Controls.Add(panelBorde4);

            PanelHelper.SetRoundPanel(panel, 10);

            estudiante.FechaNacimiento = ConvertirFecha(estudiante.FechaNacimiento);
            string PartidaNacimiento = (estudiante.PartidaNacimiento == true) ? "Si" : "No";
            string repite = (estudiante.Repitente == false) ? "No" : "Si";

            // Agregar las etiquetas al panel
            panel.Controls.Add(CrearRichLabel(100, 60, "Nombre", estudiante.Nombres));
            panel.Controls.Add(CrearRichLabel(550, 60, "Cedula", estudiante.Cedula));
            panel.Controls.Add(CrearRichLabel(100, 85, "Fecha Nacimiento", estudiante.FechaNacimiento));
            panel.Controls.Add(CrearRichLabel(550, 85, "Direccion", estudiante.Direccion));
            panel.Controls.Add(CrearRichLabel(100, 110, "Telefono", estudiante.Telefono));
            panel.Controls.Add(CrearRichLabel(550, 110, "Partida de Nacimiento", PartidaNacimiento));
            panel.Controls.Add(CrearRichLabel(100, 135, "Fecha de Matricula", ConvertirFecha(estudiante.FechaMatricula)));
            panel.Controls.Add(CrearRichLabel(550, 135, "Barrio", estudiante.Barrio));
            panel.Controls.Add(CrearRichLabel(100, 160, "Peso", estudiante.Peso + "Kg"));
            panel.Controls.Add(CrearRichLabel(550, 160, "Talla", estudiante.Talla + "m"));
            panel.Controls.Add(CrearRichLabel(100, 185, "Territorio Indigena", estudiante.TerritorioIndigena));
            panel.Controls.Add(CrearRichLabel(550, 185, "Comunidad Indigena", estudiante.ComunidadIndigena));
            panel.Controls.Add(CrearRichLabel(100, 210, "Sexo", estudiante.Sexo));
            panel.Controls.Add(CrearRichLabel(550, 210, "Pais", estudiante.Pais));
            panel.Controls.Add(CrearRichLabel(100, 235, "Departamento", estudiante.Departamento));
            panel.Controls.Add(CrearRichLabel(550, 235, "Municipio", estudiante.Municipio));
            panel.Controls.Add(CrearRichLabel(100, 260, "Nacionalidad", estudiante.Nacionalidad));
            panel.Controls.Add(CrearRichLabel(550, 260, "Etnia", estudiante.Etnia));
            panel.Controls.Add(CrearRichLabel(100, 285, "Lengua Materna", estudiante.LenguaMaterna));
            panel.Controls.Add(CrearRichLabel(550, 285, "Discapacidad", estudiante.Discapacidad));
            panel.Controls.Add(CrearRichLabel(100, 310, "Tutor", estudiante.NombresTutor));
            panel.Controls.Add(CrearRichLabel(550, 310, "Cedula Tutor", estudiante.CedulaTutor));
            panel.Controls.Add(CrearRichLabel(100, 335, "Telefono Tutor", estudiante.TelefonoTutor));
            panel.Controls.Add(CrearRichLabel(550, 335, "Codigo Estudiante", estudiante.CodigoEstudiante));
            panel.Controls.Add(CrearRichLabel(100, 360, "Fecha Matricula Academica", ConvertirFecha(estudiante.FechaMatriculaAcademica)));
            panel.Controls.Add(CrearRichLabel(550, 360, "Nivel Educativo", estudiante.NivelEducativo));
            panel.Controls.Add(CrearRichLabel(100, 385, "Repitente", repite));
            panel.Controls.Add(CrearRichLabel(550, 385, "Modalidad", estudiante.Modalidad));
            panel.Controls.Add(CrearRichLabel(100, 410, "Grado", estudiante.Grado));
            panel.Controls.Add(CrearRichLabel(550, 410, "Seccion", estudiante.Seccion));
            panel.Controls.Add(CrearRichLabel(100, 435, "Turno", estudiante.Turno));
            panel.Controls.Add(CrearRichLabel(100, 465, "Centro Educativo", estudiante.CentroEducativo));

            
            PictureBox btnEditar = new PictureBox
            {
                Image = Properties.Resources.avatar_de_usuario, 
                Size = new Size(35, 35),
                Location = new Point(860, 25),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand
            };


            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnEditar, "Editar estudiante");
            toolTip1.ReshowDelay = 0;

            PictureBox btneliminar = new PictureBox
            {
                Image = Properties.Resources.eliminar_amigo, 
                Size = new Size(30, 30),
                Location = new Point(910, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand
            };

            ToolTip toolTip2 = new ToolTip();
            toolTip2.SetToolTip(btneliminar, "Eliminar estudiante");
            toolTip2.ReshowDelay = 0;

            PictureBox btntraslado = new PictureBox
            {
                Image = Properties.Resources.traslados, 
                Size = new Size(35, 35),
                Location = new Point(810, 25),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand
            };

            ToolTip toolTip3 = new ToolTip();
            toolTip3.SetToolTip(btntraslado, "Trasladar estudiante");
            toolTip3.ReshowDelay = 0;

            btntraslado.Click += (sender, e) =>
            {
                bool response = MessageBox.Show($"¿Deseas realizar el traslado?", "Trasladar estudiante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

                if (response)
                {
                    txtBuscarEstudiantes.Visible = false;
                    flowLayoutPanel1.Controls.Clear();
                    showSubMenu(pnlTraslado);
                    LlenarHojaTraslado(estudiante);
                }

            };

            btneliminar.Click += (sender, e) =>
            {
                string nombre = estudiante.Nombres.Split(' ')[0];
                bool response = MessageBox.Show($"¿Deseas eliminar a {nombre}", "Eliminar estudiante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

                if (response)
                {
                    new Controllers.ControllerTraslados().BorrarTraslado(estudiante.CodigoEstudiante);
                    new Controllers.ControllerDatosAcademicos().BorrarDatos(estudiante.CodigoEstudiante);
                    new Controllers.ControllerEstudiante().BorrarEstudiante(estudiante.Id);

                    
                    flowLayoutPanel1.Controls.Clear();
                    if (txtBuscarEstudiantes.Text.Length > 0)
                    {
                        BuscarEstudiantes(txtBuscarEstudiantes.Text);
                    } else
                    {
                        MostrarEstudiantes();
                    }
                }
            };

            btnEditar.Click += (sender, e) =>
            {
                string nombre = estudiante.Nombres.Split(' ')[0];
                bool response = MessageBox.Show($"¿Deseas editar a {estudiante.Nombres.Split(' ')[0]}?", "Editar estudiante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                
                if (response)
                {
                    //txtBuscarEstudiantes.Visible = false;
                    //showSubMenu(pnlEditar);

                    new Editar_Estudiante(estudiante).ShowDialog();
                }
            };

            panel.Controls.Add(btnEditar);
            panel.Controls.Add(btneliminar);
            panel.Controls.Add(btntraslado);

            return panel;
        }

       public void LlenarHojaTraslado(Clases.ITEstudiantes estudiante)
       {

            DateTime fecha = DateTime.Now;
            txtFechaComprobante.Text = fecha.ToString("dd-MM-yyyy");

            cbPeriodoTraslado.Texts = null;
            txtMotivoComprobante.Text = "";
            LlenarPeriodosTraslado();
            txtCodigoComprobante.Enabled = false;
            txtCedulaComprobante.Enabled = false;
            txt1NombreComprobante.Enabled = false;
            txt2NombreComprobante.Enabled = false;
            txt1ApellidoComprobante.Enabled = false;
            txt2ApellidoComprobante.Enabled = false;
            txtFechaNacimientoComprobante.Enabled = false;
            txtDireccionComprobante.Enabled = false;
            txtDepartamentoComprobante.Enabled = false;
            txtMunicipioComprobante.Enabled = false;
            txtNivelEducativoComprobante.Enabled = false;
            txtModalidadComprobante.Enabled = false;
            txtGradoComprobante.Enabled = false;

            txtNombreCentroComprobante.Enabled = false;

            txtCodigoComprobante.Text = estudiante.CodigoEstudiante;
            txtCedulaComprobante.Text = estudiante.Cedula;
            txt1NombreComprobante.Text = estudiante.Nombres.Split(' ')[0];
            txt2NombreComprobante.Text = estudiante.Nombres.Split(' ')[1];
            txt1ApellidoComprobante.Text = estudiante.Nombres.Split(' ')[2];
            txt2ApellidoComprobante.Text = estudiante.Nombres.Split(' ')[3];
            txtFechaNacimientoComprobante.Text = ConvertirFecha(estudiante.FechaNacimiento);
            txtDireccionComprobante.Text = estudiante.Direccion;
            txtDepartamentoComprobante.Text = estudiante.Departamento;
            txtMunicipioComprobante.Text = estudiante.Municipio;
            txtNivelEducativoComprobante.Text = estudiante.NivelEducativo;
            txtModalidadComprobante.Text = estudiante.Modalidad;
            txtGradoComprobante.Text = estudiante.Grado;

            txtNombreCentroComprobante.Text = estudiante.CentroEducativo;

       }

        public void LlenarPeriodosTraslado()
        {
            string[] periodos = new Controllers.ControllerPeriodos().ObtenerPeriodos();

            foreach (string periodo in periodos)
            {
                cbPeriodoTraslado.Items.Add(periodo);
            }
        }

        public RichTextBox CrearRichLabel(int x, int y, string nombre, string texto)
        {
            RichTextBox rtb = new RichTextBox
            {
                Location = new Point(x, y),
                Size = new Size(450, 20),
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(235, 239, 242),
                ReadOnly = true
            };

            // Agregar el texto en negrita
            rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
            rtb.AppendText($"{nombre}:");

            // Agregar el texto normal
            rtb.SelectionFont = new Font(rtb.Font, FontStyle.Regular);
            rtb.AppendText($" {texto}");

            return rtb;
        }

        public string ConvertirFecha(string fecha)
        {
            string[] fechaArray = fecha.Split(' ');

            return fechaArray[0];
        }
        private void customizarDiseno()
        {
            pnlTraslado.Visible = false;
            //pnlEditar.Visible = false;
            
        }
        private void hideSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == true)
                subMenu.Visible = false;
        }
        
       

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                //hideSubMenu(subMenu);        

                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
       

        private void Estudiantes_Load(object sender, EventArgs e)
        {

        }

        private void mbComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void mbComboBox1_OnSelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void mbTexbox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBuscarEstudiantes__TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbButton2_Click(object sender, EventArgs e)
        {
            hideSubMenu(pnlTraslado);
            txtBuscarEstudiantes.Visible = true;

            if(txtBuscarEstudiantes.Text == "")
            {
                MostrarEstudiantes();
            } else
            {
                BuscarEstudiantes(txtBuscarEstudiantes.Text);
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void mbButton3_Click(object sender, EventArgs e)
        {
           //hideSubMenu(pnlEditar);
            txtBuscarEstudiantes.Visible = true;
        }

    }
}
