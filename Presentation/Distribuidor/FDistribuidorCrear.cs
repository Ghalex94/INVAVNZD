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

namespace Presentation.Distribuidor
{
    public partial class FDistribuidorCrear : Form
    {
        DistribuidorModel distribuidorModel = new DistribuidorModel();
        public FDistribuidorCrear()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int espera = int.Parse(txtEspera.Text);
            if (txtDistribuidor.Text.Length==0 || txtRUC.Text.Length==0 || txtDir1.Text.Length == 0 || txtTelf1.Text.Length == 0)
            {
                MessageBox.Show("Complete información en el campo por favor!");
            }
            else
            {
                distribuidorModel.InsertarDistribuidor(txtDistribuidor.Text, txtRUC.Text, espera, txtDir1.Text, txtDir2.Text, txtTelf1.Text, txtTelf2.Text, txtContacto.Text, txtTelfContc.Text, 1);
                FDistribuidorVer.f1.CargarTabla();
                FDistribuidorVer.f1.NotarDeshabilitado();
                FDistribuidorVer.f1.seleccionarDistribuidor(txtDistribuidor.Text);
                MessageBox.Show("Distribuidor Ingresado con Exito");
                Limpiartexto();

            }
        }
        private void Limpiartexto()
        {
            txtDistribuidor.Text = "";
            txtRUC.Text = "";
            txtEspera.Text = "";
            txtDir1.Text = "";
            txtDir2.Text = "";
            txtTelf1.Text = "";
            txtTelf2.Text = "";
            txtContacto.Text = "";
            txtTelfContc.Text = "";
        }
    }
}
