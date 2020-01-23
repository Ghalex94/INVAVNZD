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
    public partial class FAlmacenVer : Form
    {
        AlmacenModel almacenModel = new AlmacenModel();
        public static FAlmacenVer f1;
        public FAlmacenVer()
        {
            FAlmacenVer.f1 = this;
            InitializeComponent();
        }
        public void CargarTabla()
        {
            almacenModel.MostrarTabla(dgvAlmacen);
        }
        private void FAlmacenVer_Load(object sender, EventArgs e)
        {
            CargarTabla();
            DataGridViewButtonColumn btnedit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btneliminar = new DataGridViewButtonColumn();
            btnedit.Name = "Edit";
            btneliminar.Name = "Cambiar";
            dgvAlmacen.Columns.Add(btnedit);
            dgvAlmacen.Columns.Add(btneliminar);

            dgvAlmacen.Columns[0].HeaderText = "ID";
            dgvAlmacen.Columns[1].HeaderText = "ALMACEN";
            dgvAlmacen.Columns[2].HeaderText = "ESTADO";
            dgvAlmacen.Columns[3].HeaderText = "ESTADO";

            DataGridViewColumn Column;
            Column = dgvAlmacen.Columns[0];
            Column.Visible = false;
            Column = dgvAlmacen.Columns[2];
            Column.Visible = false;
            Column = dgvAlmacen.Columns[3];
            Column.Visible = false;
        }
        #region SeleccionarColumna
        public void seleccionarAlmacen(string almacen)
        {
            dgvAlmacen.ClearSelection();
            foreach (DataGridViewRow row in dgvAlmacen.Rows)
            {
                if (almacen == row.Cells["nombre"].Value.ToString())
                {
                    dgvAlmacen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    row.Selected = true;
                }
            }
        }
        #endregion
        private void btnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvAlmacen_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvAlmacen.Columns[e.ColumnIndex].Name == "Edit" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvAlmacen.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgvAlmacen.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dgvAlmacen.Columns[e.ColumnIndex].Name == "Cambiar" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Icon check = new Icon(Environment.CurrentDirectory + @"\\reload.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto                   
                e.Graphics.DrawIcon(check, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dgvAlmacen.Rows[e.RowIndex].Height = check.Height + 10;
                this.dgvAlmacen.Columns[e.ColumnIndex].Width = check.Width + 10;
                e.Handled = true;
            }
        }
        private void dgvAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string nombre, codigo;
                if (this.dgvAlmacen.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int id = int.Parse(dgvAlmacen.CurrentRow.Cells[2].Value.ToString());
                    string almacen = dgvAlmacen.CurrentRow.Cells[3].Value.ToString();

                    Form actualizar = new FAlmacenActualizar(almacen, id);
                    actualizar.ShowDialog();
                }
                if (this.dgvAlmacen.Columns[e.ColumnIndex].Name == "Cambiar")
                {
                    if (dgvAlmacen.SelectedCells[4].Value.ToString() == "0")
                    {
                        int id = int.Parse(dgvAlmacen.CurrentRow.Cells[2].Value.ToString());
                        string almacen = dgvAlmacen.CurrentRow.Cells[3].Value.ToString();

                        if (MessageBox.Show("Está seguro de Habilitar este Almacen?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            almacenModel.HabilitarAlmacen(id);
                            CargarTabla();
                            FAlmacenVer.f1.NotarDeshabilitado();
                            FAlmacenVer.f1.seleccionarAlmacen(almacen);
                        }
                    }
                    else
                    {
                        int id = int.Parse(dgvAlmacen.CurrentRow.Cells[2].Value.ToString());
                        string presentacion = dgvAlmacen.CurrentRow.Cells[3].Value.ToString();

                        if (MessageBox.Show("Está seguro de Deshabilitar este Almacen?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            almacenModel.DeshabilitarAlmacen(id);
                            CargarTabla();
                            FAlmacenVer.f1.NotarDeshabilitado();
                            FAlmacenVer.f1.seleccionarAlmacen(presentacion);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public void NotarDeshabilitado()
        {
            foreach (DataGridViewRow row in dgvAlmacen.Rows)
            {
                if (row.Cells["estado"].Value.ToString() == "0")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(246, 121, 121);
                }
            }
        }
        private void btnAgregarAlmacen_Click(object sender, EventArgs e)
        {
            Form crear = new FAlmacenCrear();
            crear.ShowDialog();
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
