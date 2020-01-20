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
    public partial class FProductoActualizar : Form
    {
        PresentacionModel presentacionModel = new PresentacionModel();
        ProductoModel productoModel = new ProductoModel();

        int codi;
        public FProductoActualizar(string cod_bar, string producto, string det_prod, double cant_total, DateTime fecha_vencimiento, string lote, string laboratorio, string composicion, int id_presentacion, int id)
        {
            InitializeComponent();
            llenar_formulario(cod_bar, producto, det_prod, cant_total, fecha_vencimiento, lote, laboratorio, composicion, id_presentacion);
            codi = id;
        }
        private void llenar_formulario(string cod_bar, string producto, string det_prod, double cant_total, DateTime fecha_vencimiento, string lote, string laboratorio, string composicion, int id_presentacion)
        {
            presentacionModel.MostrarCombobox(cbxPresentacion);

            txtCodBarra.Text = cod_bar;
            txtProducto.Text = producto;
            txtDetalle.Text = det_prod;
            txtCantidad.Text = cant_total.ToString();
            dtpVencimiento.Value = fecha_vencimiento;
            txtLote.Text = lote;
            txtLaboratorio.Text = laboratorio;
            txtComposicion.Text = composicion;
            cbxPresentacion.SelectedValue = id_presentacion;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbxPresentacion.SelectedIndex != -1)
            {
                double cant_total = double.Parse(txtCantidad.Text);
                DateTime vencimineto = DateTime.Parse(dtpVencimiento.Value.ToString());
                int id_presentacion = int.Parse(cbxPresentacion.SelectedValue.ToString());
                productoModel.ActualizarProducto(txtCodBarra.Text, txtProducto.Text, txtDetalle.Text, cant_total, vencimineto, txtLote.Text, txtLaboratorio.Text, txtComposicion.Text, id_presentacion, 1, codi);
                FProductoVer.f1.cargartabla();
                FProductoVer.f1.NotarDeshabilitado();
                FProductoVer.f1.seleccionarProducto(txtProducto.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una presentacion");
            }
        }
    }
}
