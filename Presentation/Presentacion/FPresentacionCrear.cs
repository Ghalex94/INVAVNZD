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

namespace Presentation.Presentacion
{
    public partial class FPresentacionCrear : Form
    {
        PresentacionModel presentacion = new PresentacionModel();
        public FPresentacionCrear()
        {
            InitializeComponent();
        }
        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if (txtPresentacion.TextLength == 0 )
                MessageBox.Show("Complete información en el campo por favor!");
            else
            {              
                presentacion.InsertarPresentacion(txtPresentacion.Text, 1);
                FPresentacionVer.f1.CargarTabla();
                FPresentacionVer.f1.NotarDeshabilitado();
                FPresentacionVer.f1.seleccionarPresentacion(txtPresentacion.Text);
                txtPresentacion.Clear();
                MessageBox.Show("Presentacion Ingresado con Exito");
            }
        }
    }
}
