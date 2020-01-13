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
    public partial class FPresentacionActualizar : Form
    {
        int codi;
        PresentacionModel presentacion = new PresentacionModel();
        public FPresentacionActualizar(string presentacion, int id)
        {
            InitializeComponent();
            Llenar_formulario(presentacion);
            codi = id;
        }

        public void Llenar_formulario(string presentacion)
        {
            txtPresentacion.Text = presentacion;          
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            presentacion.ActualizarPresentacion(txtPresentacion.Text, codi);
            FPresentacionVer.f1.CargarTabla();
            FPresentacionVer.f1.NotarDeshabilitado();
            FPresentacionVer.f1.seleccionarPresentacion(txtPresentacion.Text);
            this.Close();
        }
    }
}
