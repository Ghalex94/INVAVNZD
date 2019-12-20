using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Common.Cache;

namespace Presentation
{
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
            permisos();
            CustomizeDesign();
            
            
        }

        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // para minimizar a restaurar ventana desde icno de barra de estado
                cp.Style |= WS_MINIMIZEBOX;// 
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }


        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Animacion del boton Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(15, 15, 15);
        }

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }
        #endregion

        #region Animcacion del boton Minimizar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimizar_MouseDown(object sender, MouseEventArgs e)
        {
            btnMinimizar.BackColor = Color.Green;
        }

        private void btnMinimizar_MouseHover(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.Green;
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(15, 15, 15);
        }
        #endregion

        #region Redimensionar Panel
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelcontenedor.Region = region;
            this.Invalidate();
        }

        #endregion

        #region Cerrar Sesion
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de Cerrar Sesion", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Esconder paneles de los Botones Padres
        private void CustomizeDesign()
        {
            panelVentas.Visible = false;
            panelClientes.Visible = false;
            panelCompras.Visible = false;
            panelUsuario.Visible = false;
            panelReportes.Visible = false;
            panelConfiguraciones.Visible = false;
        }
        #endregion

        #region Para mostrar y esconder los botones hijos del contenedor
        private void hideSubMenu()
        {
            if (panelVentas.Visible == true)
                panelVentas.Visible = false;
            if (panelClientes.Visible == true)
                panelClientes.Visible = false;
            if (panelCompras.Visible == true)
                panelCompras.Visible = false;
            if (panelUsuario.Visible == true)
                panelUsuario.Visible = false;
            if (panelReportes.Visible == true)
                panelReportes.Visible = false;
            if (panelConfiguraciones.Visible == true)
                panelConfiguraciones.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        #endregion

        #region Agregamos a los botones padre la funcion de esconder los paneles hijos
        private void btnVentas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVentas);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCompras);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReportes);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelClientes);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            showSubMenu(panelUsuario);
        }

        private void btnConfiguraciones_Click(object sender, EventArgs e)
        {
            showSubMenu(panelConfiguraciones);
        }
        #endregion

        #region Permisos Para los botones Padres
        public void permisos()
        {
            //btnVentas.Enabled = false;
            //btnCompras.Enabled = false;
            //btnReportes.Enabled = false;
            //btnClientes.Enabled = false;
            //btnUsuarios.Enabled = false;
            //btnConfiguraciones.Enabled = false;

            string cadena = UserCache.permisosUsuario;
            String[] separadas;
            separadas = cadena.Split(',');
            foreach(string i in separadas)
            {
                switch (i)
                {
                    case "1":
                        btnVentas.Enabled = true;
                        btnVentas.Visible = true;
                        break;
                    case "2":
                        btnCompras.Enabled = true;
                        btnCompras.Visible = true;
                        break;
                    case "3":
                        btnReportes.Enabled = true;
                        btnReportes.Visible = true;
                        break;
                    case "4":
                        btnClientes.Enabled = true;
                        btnClientes.Visible = true;
                        break;
                    case "5":
                        btnUsuarios.Enabled = true;
                        btnUsuarios.Visible = true;
                        break;
                    case "6":
                        btnConfiguraciones.Enabled = true;
                        btnConfiguraciones.Visible = true;
                        break;
                }
                
            }
        }

        #endregion


        private void AbrirFOrmulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormulario.Controls.OfType<MiForm>().FirstOrDefault(); // Busca en la coleccion el formulario
            // Si el formulario no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormulario.Controls.Add(formulario);
                panelFormulario.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FVerUsuario"] == null)
            {
                btnVerUsuarios.BackColor = Color.White;
            }
            //if (Application.OpenForms["Form2"] == null)
            //{

            //    sub2Button1.BackColor = Color.White;
            //}
            //if (Application.OpenForms["Form3"] == null)
            //{
            //    sub3Button1.BackColor = Color.White;
            //}
        }

        private void button16_Click(object sender, EventArgs e)
        {
            AbrirFOrmulario<FUsuariosVer>();
            btnVerUsuarios.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void FMenu_Load(object sender, EventArgs e)
        {
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bool testBool = false;

            int testInt = testBool ? 1 : 0;

            MessageBox.Show("" + testInt);
        }
    }
}
