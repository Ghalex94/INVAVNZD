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

namespace Presentation.Cliente
{
    public partial class FClienteActualizar : Form
    {
        ClienteModel clienteModel = new ClienteModel();

        int codi;
        public FClienteActualizar(string dni_cli, string nom_cli, string ape_cli, string ruc_cli, string raz_soc, string dir_cli, string telf_cel, DateTime fec_nac, string correo, int tipo, int estado, int id)
        {
            InitializeComponent();
            llenar_formulario(dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli, telf_cel, fec_nac, correo, tipo, estado);
            codi = id;
        }


        public void llenar_formulario(string dni_cli, string nom_cli, string ape_cli, string ruc_cli, string raz_soc, string dir_cli, string telf_cel, DateTime fec_nac, string correo, int tipo, int estado)
        {
            txtDNI.Text = dni_cli;
            txtNombre.Text = nom_cli;
            txtApellido.Text = ape_cli;
            txtRUC.Text = ruc_cli;
            txtRazSoc.Text = raz_soc;
            txtDireccion.Text = dir_cli;
            txtTelefono.Text = telf_cel;
            dtpNacimiento.Value = fec_nac;
            txtCorreo.Text = correo;
            cbxTipo.SelectedIndex = tipo;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime nacimiento = DateTime.Parse(dtpNacimiento.Value.ToString());
            clienteModel.ActualizarCliente(txtDNI.Text,txtNombre.Text,txtApellido.Text,txtRUC.Text,txtRazSoc.Text,txtDireccion.Text,txtTelefono.Text,nacimiento,txtCorreo.Text,cbxTipo.SelectedIndex,1,codi);
            FClienteVer.f1.CargarTabla();
            FClienteVer.f1.NotarDeshabilitado();
            FClienteVer.f1.seleccionarCLiente(txtNombre.Text);
            this.Close();
        }

    }
}
