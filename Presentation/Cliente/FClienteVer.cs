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
    public partial class FClienteVer : Form
    {
        ClienteModel clienteModel = new ClienteModel();
        public static FClienteVer f1;
        public FClienteVer()
        {
            FClienteVer.f1 = this;
            InitializeComponent();
        }
        public void CargarTabla()
        {
            clienteModel.MostrarTabla(dgvCLiente);
        }

        private void FClienteVer_Load(object sender, EventArgs e)
        {
            CargarTabla();
            // Agregar botones editar, eliminar
            DataGridViewButtonColumn btnedit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btneliminar = new DataGridViewButtonColumn();
            btnedit.Name = "Edit";
            btneliminar.Name = "Cambiar";
            dgvCLiente.Columns.Add(btnedit);
            dgvCLiente.Columns.Add(btneliminar);

            dgvCLiente.Columns[0].HeaderText = "ID";
            dgvCLiente.Columns[1].HeaderText = "DNI";
            dgvCLiente.Columns[2].HeaderText = "Nom. Clte.";
            dgvCLiente.Columns[3].HeaderText = "Ape. Clte.";
            dgvCLiente.Columns[4].HeaderText = "RUC";
            dgvCLiente.Columns[5].HeaderText = "Razon Soc.";
            dgvCLiente.Columns[6].HeaderText = "Dir. Clte";
            dgvCLiente.Columns[7].HeaderText = "Telefono";
            dgvCLiente.Columns[8].HeaderText = "Nacimiento";
            dgvCLiente.Columns[9].HeaderText = "Email";
            dgvCLiente.Columns[10].HeaderText = "Tipo";
            dgvCLiente.Columns[11].HeaderText = "Tipo";
            dgvCLiente.Columns[12].HeaderText = "Estado";
            dgvCLiente.Columns[13].HeaderText = "Estado";

            DataGridViewColumn Column;
            Column = dgvCLiente.Columns[0];
            Column.Visible = false;
            Column = dgvCLiente.Columns[10];
            Column.Visible = false;
            Column = dgvCLiente.Columns[12];
            Column.Visible = false;
            Column = dgvCLiente.Columns[13];
            Column.Visible = false;
        }
        public void seleccionarCLiente(string cliente)
        {
            dgvCLiente.ClearSelection();
            foreach (DataGridViewRow row in dgvCLiente.Rows)
            {
                if (cliente == row.Cells["nom_cli"].Value.ToString())
                {
                    dgvCLiente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    row.Selected = true;
                }
            }
        }
        private void btnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
