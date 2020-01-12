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
                        chBoxReportes.Checked = true;
                        break;
                    case "4":
                        chBoxClientes.Checked = true;
                        break;
                    case "5":
                        chBoxUsuarios.Checked = true;
                        break;
                    case "6":
                        chBoxConfiguraciones.Checked = true;
                        break;
                }
            }
        }
        private string Asignarcheck()
        {
            string ventastr, comprastr, reportestr, clientestr, usuariostr, configuracionstr;
            bool ventas = chBoxVentas.Checked;
            bool compras = chBoxCompras.Checked;
            bool reportes = chBoxReportes.Checked;
            bool clientes = chBoxClientes.Checked;
            bool usuarios = chBoxUsuarios.Checked;
            bool configuraciones = chBoxConfiguraciones.Checked;
            if (ventas == true)
            {
                ventastr = "1";
            }
            else
            {
                ventastr = "";
            }
            if (compras == true)
            {
                comprastr = "2";
            }
            else
            {
                comprastr = "";
            }
            if (reportes == true)
            {
                reportestr = "3";
            }
            else
            {
                reportestr = "";
            }
            if (clientes == true)
            {
                clientestr = "4";
            }
            else
            {
                clientestr = "";
            }
            if (usuarios == true)
            {
                usuariostr = "5";
            }
            else
            {
                usuariostr = "";
            }
            if (configuraciones == true)
            {
                configuracionstr = "6";
            }
            else
            {
                configuracionstr = "";
            }
            return (ventastr + "," + comprastr + "," + reportestr + "," + clientestr + "," + usuariostr + "," + configuracionstr);
        }

        public void btnActualizar_Click(object sender, EventArgs e)
        {                 
            UserModel user = new UserModel();
            user.ActualizarUsuario(txtNombre.Text, txtUsuario.Text, txtPass.Text, cbTipoUsuario.SelectedIndex, Asignarcheck(),codi);
            FUsuariosVer.f1.CargarTabla();
            FUsuariosVer.f1.NotarDeshabilitado();
            FUsuariosVer.f1.seleccionarUsuario(txtUsuario.Text);
            this.Close();
        }
    }
}
