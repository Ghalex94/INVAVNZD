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
    public partial class FDistribuidorVer : Form
    {
        DistribuidorModel distribuidorModel = new DistribuidorModel();
        public static FDistribuidorVer f1;
        public FDistribuidorVer()
        {
            FDistribuidorVer.f1 = this;
            InitializeComponent();
        }
        public void CargarTabla()
        {
            distribuidorModel.MostrarTabla(dgvDistribuidor);
        }
        private void FDistribuidorVer_Load(object sender, EventArgs e)
        {
            CargarTabla();
            DataGridViewButtonColumn btnedit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btneliminar = new DataGridViewButtonColumn();
            btnedit.Name = "Edit";
            btneliminar.Name = "Cambiar";
            dgvDistribuidor.Columns.Add(btnedit);
            dgvDistribuidor.Columns.Add(btneliminar);

            dgvDistribuidor.Columns[0].HeaderText = "ID";
            dgvDistribuidor.Columns[1].HeaderText = "Distribuidor";
            dgvDistribuidor.Columns[2].HeaderText = "RUC";
            dgvDistribuidor.Columns[3].HeaderText = "Espera";
            dgvDistribuidor.Columns[4].HeaderText = "Dir 1";
            dgvDistribuidor.Columns[5].HeaderText = "Dir 2";
            dgvDistribuidor.Columns[6].HeaderText = "Tel 1";
            dgvDistribuidor.Columns[7].HeaderText = "Tel 2";
            dgvDistribuidor.Columns[8].HeaderText = "Contacto";
            dgvDistribuidor.Columns[9].HeaderText = "Tel Ctos";
            dgvDistribuidor.Columns[10].HeaderText = "Estado";
            dgvDistribuidor.Columns[11].HeaderText = "Estado";

            DataGridViewColumn Column; 
            Column = dgvDistribuidor.Columns[0];
            Column.Visible = false;
            Column = dgvDistribuidor.Columns[10];
            Column.Visible = false;
            Column = dgvDistribuidor.Columns[11];
            Column.Visible = false;
        }

        public void seleccionarDistribuidor(string distribuidor)
        {
            dgvDistribuidor.ClearSelection();
            foreach (DataGridViewRow row in dgvDistribuidor.Rows)
            {
                if (distribuidor == row.Cells["nom_distri"].Value.ToString())
                {
                    dgvDistribuidor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    row.Selected = true;
                }
            }
        }        

        private void btnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDistribuidor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvDistribuidor.Columns[e.ColumnIndex].Name == "Edit" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //DataGridViewButtonCell celBoton = this.dgvUsuarios.Rows[e.RowIndex].Cells["Editar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvDistribuidor.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgvDistribuidor.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dgvDistribuidor.Columns[e.ColumnIndex].Name == "Cambiar" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //DataGridViewButtonCell celBoton = this.dgvUsuarios.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;

                Icon check = new Icon(Environment.CurrentDirectory + @"\\reload.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto                   
                e.Graphics.DrawIcon(check, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dgvDistribuidor.Rows[e.RowIndex].Height = check.Height + 10;
                this.dgvDistribuidor.Columns[e.ColumnIndex].Width = check.Width + 10;
                e.Handled = true;

            }
        }

        private void dgvDistribuidor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvDistribuidor.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int id = int.Parse(dgvDistribuidor.CurrentRow.Cells[2].Value.ToString());
                    string nom_distri = dgvDistribuidor.CurrentRow.Cells[3].Value.ToString();
                    string ruc_distri = dgvDistribuidor.CurrentRow.Cells[4].Value.ToString();
                    int tiempo_espera = int.Parse(dgvDistribuidor.CurrentRow.Cells[5].Value.ToString());
                    string direccion1 = dgvDistribuidor.CurrentRow.Cells[6].Value.ToString();
                    string direccion2 = dgvDistribuidor.CurrentRow.Cells[7].Value.ToString();
                    string telef1 = dgvDistribuidor.CurrentRow.Cells[8].Value.ToString();
                    string telef2 = dgvDistribuidor.CurrentRow.Cells[9].Value.ToString();
                    string contacto = dgvDistribuidor.CurrentRow.Cells[10].Value.ToString();
                    string telef_contacto = dgvDistribuidor.CurrentRow.Cells[11].Value.ToString();

                    Form actualizar = new FDistribuidorActualizar(nom_distri, ruc_distri, tiempo_espera, direccion1, direccion2, telef1, telef2, contacto, telef_contacto, id);
                    actualizar.ShowDialog();
                }
                if (this.dgvDistribuidor.Columns[e.ColumnIndex].Name == "Cambiar")
                {
                    if (dgvDistribuidor.SelectedCells[12].Value.ToString() == "0")
                    {
                        int id = int.Parse(dgvDistribuidor.CurrentRow.Cells[2].Value.ToString());
                        string nom_distri = dgvDistribuidor.CurrentRow.Cells[3].Value.ToString();
                        if (MessageBox.Show("Está seguro de Habilitar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            distribuidorModel.HabilitarDistribuidor(id);
                            CargarTabla();
                            FDistribuidorVer.f1.NotarDeshabilitado();
                            FDistribuidorVer.f1.seleccionarDistribuidor(nom_distri);
                        }
                    }
                    else //(dgvUsuarios.SelectedCells[9].Value.ToString() == "1")
                    {
                        int id = int.Parse(dgvDistribuidor.CurrentRow.Cells[2].Value.ToString());
                        string nom_distri = dgvDistribuidor.CurrentRow.Cells[3].Value.ToString();
                        if (MessageBox.Show("Está seguro de Deshabilitar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            distribuidorModel.DeshabilitarDistribuidor(id);
                            CargarTabla();
                            FDistribuidorVer.f1.NotarDeshabilitado();
                            FDistribuidorVer.f1.seleccionarDistribuidor(nom_distri);
                        }
                    }
                }
            }
            catch // (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        public void NotarDeshabilitado()
        {
            foreach (DataGridViewRow row in dgvDistribuidor.Rows)
            {
                if (row.Cells["estado"].Value.ToString() == "0")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(246, 121, 121);
                }
            }
        }
        private void btnAgregarDistribuidor_Click(object sender, EventArgs e)
        {
            Form crear = new FDistribuidorCrear();
            crear.ShowDialog();
            crear.FormClosed += cargartable;
        }

        private void cargartable(object sender, FormClosedEventArgs e)
        {
            distribuidorModel.MostrarTabla(dgvDistribuidor);
        }

        private void dgvPresentacion_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            NotarDeshabilitado();
        }

        private void dgvPresentacion_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {
            NotarDeshabilitado();
        }
    }
}
