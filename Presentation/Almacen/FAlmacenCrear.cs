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

namespace Presentation.Almacen
{
    public partial class FAlmacenCrear : Form
    {
        AlmacenModel almacenModel = new AlmacenModel();

        public FAlmacenCrear()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtAlmacen.TextLength == 0)
            {
                MessageBox.Show("Complete información en el campo por favor!");
            }
            else
            {
                almacenModel.InsertarAlmacen(txtAlmacen.Text, 1);
                FAlmacenVer.f1.CargarTabla();
                FAlmacenVer.f1.NotarDeshabilitado();
                FAlmacenVer.f1.seleccionarAlmacen(txtAlmacen.Text);
                txtAlmacen.Clear();
                MessageBox.Show("Almacen Ingresado con Exito");
            }
        }
    }
}
