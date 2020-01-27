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
            cbxfiltro.SelectedIndex = 2;
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

        private void dgvCLiente_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvCLiente.Columns[e.ColumnIndex].Name == "Edit" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvCLiente.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgvCLiente.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dgvCLiente.Columns[e.ColumnIndex].Name == "Cambiar" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);


                Icon check = new Icon(Environment.CurrentDirectory + @"\\reload.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto                   
                e.Graphics.DrawIcon(check, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvCLiente.Rows[e.RowIndex].Height = check.Height + 10;
                this.dgvCLiente.Columns[e.ColumnIndex].Width = check.Width + 10;

                e.Handled = true;
            }
        }

        private void dgvCLiente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvCLiente.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int id = int.Parse(dgvCLiente.CurrentRow.Cells[2].Value.ToString());
                    string dni = dgvCLiente.CurrentRow.Cells[3].Value.ToString();
                    string nombre= dgvCLiente.CurrentRow.Cells[4].Value.ToString();
                    string apellido = dgvCLiente.CurrentRow.Cells[5].Value.ToString();
                    string ruc = dgvCLiente.CurrentRow.Cells[6].Value.ToString();
                    string razonsocial = dgvCLiente.CurrentRow.Cells[7].Value.ToString();
                    string direccion = dgvCLiente.CurrentRow.Cells[8].Value.ToString();
                    string telefono = dgvCLiente.CurrentRow.Cells[9].Value.ToString();
                    DateTime fec_nacimiento = DateTime.Parse(dgvCLiente.CurrentRow.Cells[10].Value.ToString());
                    string correo = dgvCLiente.CurrentRow.Cells[11].Value.ToString();
                    int tipo = int.Parse(dgvCLiente.CurrentRow.Cells[12].Value.ToString());
                    int estado = int.Parse(dgvCLiente.CurrentRow.Cells[14].Value.ToString());

                    Form actualizar = new FClienteActualizar(dni, nombre, apellido, ruc, razonsocial, direccion, telefono, fec_nacimiento, correo,tipo,estado,id);
                    actualizar.ShowDialog();

                }
                if (this.dgvCLiente.Columns[e.ColumnIndex].Name == "Cambiar")
                {
                    if (dgvCLiente.SelectedCells[14].Value.ToString() == "0")
                    {
                        int id = int.Parse(dgvCLiente.CurrentRow.Cells[2].Value.ToString());
                        string nombre = dgvCLiente.CurrentRow.Cells[4].Value.ToString();
                        if (MessageBox.Show("Está seguro de Habilitar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            clienteModel.HabilitarCliente(id);
                            CargarTabla();
                            FClienteVer.f1.NotarDeshabilitado();
                            FClienteVer.f1.seleccionarCLiente(nombre);
                        }
                    }
                    else 
                    {
                        int id = int.Parse(dgvCLiente.CurrentRow.Cells[2].Value.ToString());
                        string nombre = dgvCLiente.CurrentRow.Cells[4].Value.ToString();
                        if (MessageBox.Show("Está seguro de Deshabilitar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            clienteModel.DeshabilitarCliente(id);
                            CargarTabla();
                            FClienteVer.f1.NotarDeshabilitado();
                            FClienteVer.f1.seleccionarCLiente(nombre);
                        }
                    }
                }
            }
            catch {}
        }
        public void NotarDeshabilitado()
        {
            foreach (DataGridViewRow row in dgvCLiente.Rows)
            {
                if (row.Cells["estado"].Value.ToString() == "0")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(246, 121, 121);
                }
            }
        }
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Form crear = new FClienteCrear();
            crear.ShowDialog();
            crear.FormClosed += cargartable;
        }
        private void cargartable(object sender, FormClosedEventArgs e)
        {
            clienteModel.MostrarTabla(dgvCLiente);
        }
        private void dgvCLiente_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            NotarDeshabilitado();
        }
        private void dgvCLiente_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {
            NotarDeshabilitado();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbxfiltro.SelectedIndex == 0)
            {
                clienteModel.FiltrarDNI(txtBuscar.Text, dgvCLiente);
                NotarDeshabilitado();
            }
            if (cbxfiltro.SelectedIndex == 1)
            {
                clienteModel.FiltrarRUC(txtBuscar.Text, dgvCLiente);
                NotarDeshabilitado();
            }
            if (cbxfiltro.SelectedIndex == 2)
            {
                clienteModel.FiltrarCliente(txtBuscar.Text, dgvCLiente);
                NotarDeshabilitado();
            }
            if (cbxfiltro.SelectedIndex == 3)
            {
                clienteModel.FiltrarRazonSocial(txtBuscar.Text, dgvCLiente);
                NotarDeshabilitado();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                CargarTabla();
            }
            else
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    e.Handled = true;
                }

            }
        }
    }
}
