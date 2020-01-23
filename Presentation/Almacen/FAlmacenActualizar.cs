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
    public partial class FAlmacenActualizar : Form
    {
        int codi;
        AlmacenModel almacenModel = new AlmacenModel();
        public FAlmacenActualizar(string almacen,int id)
        {
            InitializeComponent();
            Llenar_formulario(almacen);
            codi = id;
        }
        public void Llenar_formulario(string almacen)
        {
            txtAlmacen.Text = almacen;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            almacenModel.ActualizarAlmacen(txtAlmacen.Text, codi);
            FAlmacenVer.f1.CargarTabla();
            FAlmacenVer.f1.NotarDeshabilitado();
            FAlmacenVer.f1.seleccionarAlmacen(txtAlmacen.Text);
            this.Close();
        }
    }
}
