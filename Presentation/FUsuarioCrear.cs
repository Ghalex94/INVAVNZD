using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Domain;

namespace Presentation
{
    public partial class FUsuarioCrear : Form
    {
        public FUsuarioCrear()
        {
            InitializeComponent();          
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            UserModel user = new UserModel();
            user.InsertarUsuario(txtNombre.Text,txtUsuario.Text,txtPass.Text,cbTipoUsuario.SelectedIndex,Asignarcheck(),1);
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

        private void deshabilitarPermisos()
        {
            //cbTipoUsuario.SelectedIndex = 1;
            if (cbTipoUsuario.SelectedIndex == 0)
            {
                checkSeleccionados();
                checkDeshabilitado();
                MessageBox.Show("Super");
            }else if (cbTipoUsuario.SelectedIndex == 1)
            {
                checkHabilitado();
                checkDeseleccionados();
                MessageBox.Show("Admin");
            }
            else if (cbTipoUsuario.SelectedIndex == 2)
            {
                checkDeshabilitado();
                checkDeseleccionados();
                MessageBox.Show("Vendeor");
            }
        }
        private void FUsuarioCrear_Load(object sender, EventArgs e)
        {
            
        }
        private void checkHabilitado()
        {
            chBoxClientes.Enabled = true;
            chBoxCompras.Enabled = true;
            chBoxConfiguraciones.Enabled = true;
            chBoxReportes.Enabled = true;
            chBoxUsuarios.Enabled = true;
            chBoxVentas.Enabled = true;
        }
        private void checkDeshabilitado()
        {
            chBoxClientes.Enabled = false;
            chBoxCompras.Enabled = false;
            chBoxConfiguraciones.Enabled = false;
            chBoxReportes.Enabled = false;
            chBoxUsuarios.Enabled = false;
            chBoxVentas.Enabled = false;
        }
        private void checkSeleccionados()
        {
            chBoxClientes.Checked = true;
            chBoxCompras.Checked = true;
            chBoxConfiguraciones.Checked = true;
            chBoxReportes.Checked = true;
            chBoxUsuarios.Checked = true;
            chBoxVentas.Checked = true;
        }
        private void checkDeseleccionados()
        {
            chBoxClientes.Checked = false;
            chBoxCompras.Checked = false;
            chBoxConfiguraciones.Checked = false;
            chBoxReportes.Checked = false;
            chBoxUsuarios.Checked = false;
            chBoxVentas.Checked = false;
        }

        private void cbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            deshabilitarPermisos();
        }
    }
}
