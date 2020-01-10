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
    public partial class FProductosCrear : Form
    {
        public FProductosCrear()
        {
            InitializeComponent();
            
            
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.TextLength == 0 || txtUsuario.TextLength == 0 || txtPass.TextLength == 0 || txtPass2.TextLength == 0 || cbTipoUsuario.SelectedIndex == -1)
                MessageBox.Show("Complete información en todos lo campos por favor!");
            else
            {
                if (txtPass.Text != txtPass2.Text)
                    MessageBox.Show("ingresó contraseñas distintas, vuelva a intentarlo por favor");
                else
                {
                    UserModel user = new UserModel();
                    user.InsertarUsuario(txtNombre.Text, txtUsuario.Text, txtPass.Text, cbTipoUsuario.SelectedIndex, AsignarChecks(), 1);
                    FProductosVer.f1.CargarTabla();       
                    //FUsuariosVer.f1.Close();
                    //FMenu.fmenu.AbrirFormulario<FUsuariosVer>();
                    FProductosVer.f1.seleccionarUsuario(txtUsuario.Text);
                    //FUsuariosVer.f1.Show();
                    this.Close();
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
        private void ConfigurarPermisos()
        {
            int eleccion = cbTipoUsuario.SelectedIndex;

            switch(eleccion)
            {
                case 0:
                    HabilitarChecks();
                    DeseleccionarChecks();
                    SeleccionarChecks();
                    break;
                case 1:
                    HabilitarChecks();
                    DeseleccionarChecks();
                    SeleccionarChecks();
                    chBoxConfiguraciones.Checked = false;
                    break;
                case 2:
                    HabilitarChecks();
                    DeseleccionarChecks();
                    chBoxVentas.Checked = true;
                    chBoxCompras.Checked = true;
                    chBoxCaja.Checked = true;
                    chBoxInventario.Checked = true;
                    break;
                default:
                    break;
            }
        }
        private void DeseleccionarChecks()
        {
            chBoxVentas.Checked = false;
            chBoxCompras.Checked = false;
            chBoxCaja.Checked = false;
            chBoxInventario.Checked = false;
            chBoxEntidades.Checked = false;
            chBoxReportes.Checked = false;
            chBoxConfiguraciones.Checked = false;
        }
        private void SeleccionarChecks()
        {
            chBoxVentas.Checked = true;
            chBoxCompras.Checked = true;
            chBoxCaja.Checked = true;
            chBoxInventario.Checked = true;
            chBoxEntidades.Checked = true;
            chBoxReportes.Checked = true;
            chBoxConfiguraciones.Checked = true;
        }
        private void HabilitarChecks()
        {
            chBoxVentas.Enabled = true;
            chBoxCompras.Enabled = true;
            chBoxCaja.Enabled = true;
            chBoxInventario.Enabled = true;
            chBoxEntidades.Enabled = true;
            chBoxReportes.Enabled = true;
            chBoxConfiguraciones.Enabled = true;
        }
        private void cbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarPermisos();
        }
    }
}
