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
    public partial class FClienteCrear : Form
    {
        ClienteModel clienteModel = new ClienteModel();
        public FClienteCrear()
        {
            InitializeComponent();
            cbxTipo.SelectedIndex = 0;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime nacimiento = DateTime.Parse(dtpNacimiento.Value.ToString());
            int tipo = cbxTipo.SelectedIndex;

            clienteModel.InsertarCliente(txtDNI.Text, txtNombre.Text, txtApellido.Text, txtRUC.Text, txtRazSoc.Text, txtDireccion.Text, txtTelefono.Text, nacimiento, txtCorreo.Text, tipo, 1);
            FClienteVer.f1.CargarTabla();
            FClienteVer.f1.NotarDeshabilitado();
            FClienteVer.f1.seleccionarCLiente(txtNombre.Text);
            MessageBox.Show("Producto Ingresado con Exito");

            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtRUC.Text = "";
            txtRazSoc.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            dtpNacimiento.Value = DateTime.Now;
            txtCorreo.Text = "";
        }
    }
}
