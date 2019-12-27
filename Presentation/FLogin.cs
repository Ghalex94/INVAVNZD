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
                txtuser.ForeColor = Color.DimGray;
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
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false; 
            }
        }
        #endregion

        #region Animacion del boton Cerrar (cambio de color)
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }
        #endregion

        #region Animacion del boton Minimizar (cambio de color)
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimizar_MouseDown(object sender, MouseEventArgs e)
        {
            btnMinimizar.BackColor = Color.Green;
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnMinimizar_MouseHover(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.Green;
        }


        #endregion

        #region Login de un Usuario

        #region Boton de Logeo
        private void btnlogin_Click(object sender, EventArgs e)
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
                        msgError("Usuario y/o Contraseña incorrectas. \nPor favor intente nuevamente.");
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
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "USUARIO";            
            lblError.Visible = false;
            this.Show();
            //txtpass.Focus();
        }
        #endregion

        #endregion
    }
}
