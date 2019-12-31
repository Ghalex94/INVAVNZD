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
using Domain;

namespace Presentation
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Permitir maximizar y minimizar desde la barra de tareas
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
        #endregion

        #region Animacion similar de placeholder (texto oculto en textbox)
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.White;
            }
        }
        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DarkGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if(txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.White;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DarkGray;
                txtpass.UseSystemPasswordChar = false; 
            }
        }
        #endregion
        
        #region Acciones de minimizar, salir
        private void btnMinimizarr_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rpt;
            rpt = MessageBox.Show("¿Salir del Sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //rpt = MessageBox.Show("¿Salir del Sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpt == DialogResult.Yes)
                Application.Exit();
        }
        #endregion
               
        #region LOGIN

        #region Boton de Logeo
        private void btnlogin_Click(object sender, EventArgs e)
        {
            VerificarLogin();
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                VerificarLogin();
                e.Handled = true; // HACE QUE NO SE REPRODUZCA SONIDO AL DAR EN ENTER
            }
        }
        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter)) 
            { 
                VerificarLogin();
                e.Handled = true; // HACE QUE NO SE REPRODUZCA SONIDO AL DAR EN ENTER
            }
        }

        private void VerificarLogin() 
        {
            if (txtuser.Text != "USUARIO")
            {
                if (txtpass.Text != "CONTRASEÑA")
                {
                    UserModel user = new UserModel();
                    var validLogig = user.LoginUser(txtuser.Text, txtpass.Text);
                    if (validLogig)
                    {
                        FMenu mainmenu = new FMenu();
                        mainmenu.Show();
                        mainmenu.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario y/o Contraseña incorrectas. \nPor favor intente nuevamente.\nNota*: PUEDE QUE SU CUENTA ESTE DESHABILITADA");
                        txtuser.Focus();
                        //tuser.Clear();
                        //txtpass.UseSystemPasswordChar = false;
                        //txtpass.Text = "CONTRASEÑA";
                        //txtpass.ForeColor = Color.DimGray;
                        //txtpass.UseSystemPasswordChar = true;
                    }
                }
                else msgError("Por favor, ingrese la contraseña.");
            }
            else msgError("Por favor, ingrese el usuario.");
        }

        #endregion

        #region Muestra el error del Logeo
        private void msgError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }
        #endregion

        #region Cierre de Sesion
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "CONTRASEÑA";
            txtpass.ForeColor = Color.DimGray;
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "USUARIO";
            txtuser.ForeColor = Color.DimGray;
            lblError.Visible = false;
            this.Show();
            txtuser.Focus();
            //txtpass.Focus();
        }
        #endregion

        #endregion

    }
}
