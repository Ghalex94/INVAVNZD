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
    public partial class FDistribuidorActualizar : Form
    {
        DistribuidorModel distribuidorModel = new DistribuidorModel();
        int codi;
        public FDistribuidorActualizar(string nom_distri, string ruc_distri, int tiempo_espera, string direccion1, string direccion2, string telef1, string telef2, string contacto, string telef_contacto, int id_dist)
        {
            InitializeComponent();
            llenar_formulario(nom_distri, ruc_distri, tiempo_espera, direccion1, direccion2,telef1,telef2,contacto,telef_contacto);
            codi = id_dist;
        }

        private void llenar_formulario(string nom_distri, string ruc_distri, int tiempo_espera, string direccion1, string direccion2, string telef1, string telef2, string contacto, string telef_contacto)
        {
            txtDistribuidor.Text = nom_distri;
            txtRUC.Text = ruc_distri;
            txtEspera.Text = tiempo_espera.ToString();
            txtDir1.Text = direccion1;
            txtDir2.Text = direccion2;
            txtTelf1.Text = telef1;
            txtTelf2.Text = telef2;
            txtContacto.Text = contacto;
            txtTelfContc.Text = telef_contacto;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int espera = int.Parse(txtEspera.Text);
            distribuidorModel.ActualizarDistrbuidorr(txtDistribuidor.Text,txtRUC.Text,espera,txtDir1.Text,txtDir2.Text,txtTelf1.Text,txtTelf2.Text,txtContacto.Text,txtTelfContc.Text,1,codi);
            FDistribuidorVer.f1.CargarTabla();
            FDistribuidorVer.f1.NotarDeshabilitado();
            FDistribuidorVer.f1.seleccionarDistribuidor(txtDistribuidor.Text);
            this.Close();
        }
    }
}
