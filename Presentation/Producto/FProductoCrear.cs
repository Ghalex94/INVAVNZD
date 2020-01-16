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

namespace Presentation.Producto
{
    public partial class FProductoCrear : Form
    {
        PresentacionModel presentacionModel = new PresentacionModel();
        ProductoModel productoModel = new ProductoModel();
        public FProductoCrear()
        {
            InitializeComponent();
        }

        private void FProductoCrear_Load(object sender, EventArgs e)
        {
            presentacionModel.MostrarCombobox(cbxPresentacion);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int id_presentacion = int.Parse(cbxPresentacion.SelectedValue.ToString());
            DateTime vencimiento = DateTime.Parse(dtpVencimiento.Value.ToString());
            double cantidad = double.Parse(txtCantidad.Text);

            if (txtCodBarra.Text.Length == 0 || txtProducto.TextLength == 0)
                MessageBox.Show("Complete información en el campo por favor!");
            else
            {
                productoModel.InsertarProducto(txtCodBarra.Text, txtProducto.Text, txtDetalle.Text, cantidad, vencimiento, txtLote.Text, txtLaboratorio.Text, txtComposicion.Text, id_presentacion, 1);
                FProductoVer.f1.cargartabla();
                FProductoVer.f1.NotarDeshabilitado();
                FProductoVer.f1.seleccionarProducto(txtProducto.Text);
                MessageBox.Show("Producto Ingresado con Exito");
            }
        }
    }
}
