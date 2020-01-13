using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Presentation
{
    public partial class FUsuarioActualizar : Form
    {
        int codi;
        public FUsuarioActualizar(string nombre,string usuario,string pass,int tipo, string permisos, int id)
        {
            InitializeComponent();
            Llenar_formulario(nombre, usuario, pass, tipo, permisos);
            codi = id;
        }

        public void Llenar_formulario(string nombre, string usuario, string pass, int tipo, string permisos)
        {
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtPass.Text = pass;
            cbTipoUsuario.SelectedIndex = tipo;
            string cadena = permisos;
            String[] permisoseparados;
            permisoseparados = cadena.Split(',');
            foreach (string i in permisoseparados)
            {
                switch (i)
                {
                    case "1":
                        chBoxVentas.Checked = true;
                        break;
                    case "2":
                        chBoxCompras.Checked = true;
                        break;
                    case "3":
                        chBoxCaja.Checked = true;
                        break;
                    case "4":
                        chBoxInventario.Checked = true;
                        break;
                    case "5":
                        chBoxEntidades.Checked = true;
                        break;
                    case "6":
                        chBoxReportes.Checked = true;
                        break;
                    case "7":
                        chBoxConfiguraciones.Checked = true;
                        break;
                }
            }
        }
        private string AsignarChecks()
        {
            string permisos = "";

            if (chBoxVentas.Checked == true)
                permisos = permisos + "1,";
            if (chBoxCompras.Checked == true)
                permisos = permisos + "2,";
            if (chBoxCaja.Checked == true)
                permisos = permisos + "3,";
            if (chBoxInventario.Checked == true)
                permisos = permisos + "4,";
            if (chBoxEntidades.Checked == true)
                permisos = permisos + "5,";
            if (chBoxReportes.Checked == true)
                permisos = permisos + "6,";
            if (chBoxConfiguraciones.Checked == true)
                permisos = permisos + "7,";

            return permisos;
        }

        public void btnActualizar_Click(object sender, EventArgs e)
        {                 
            UserModel user = new UserModel();
            user.ActualizarUsuario(txtNombre.Text, txtUsuario.Text, txtPass.Text, cbTipoUsuario.SelectedIndex, AsignarChecks(),codi);
            FUsuariosVer.f1.CargarTabla();
            FUsuariosVer.f1.NotarDeshabilitado();
            FUsuariosVer.f1.seleccionarUsuario(txtUsuario.Text);
            this.Close();
        }
    }
}
