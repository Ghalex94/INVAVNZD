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
    public partial class FPresentacionVer : Form
    {
        PresentacionModel presentacionModel = new PresentacionModel();
        public static FPresentacionVer f1;
        public FPresentacionVer()
        {
            FPresentacionVer.f1 = this;
            InitializeComponent();
            
        }
        public void CargarTabla()
        {
            presentacionModel.MostrarPresentacion(dgvPresentacion);
        }
        private void FPresentacionVer_Load(object sender, EventArgs e)
        {
            CargarTabla();
            DataGridViewButtonColumn btnedit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btneliminar = new DataGridViewButtonColumn();
            btnedit.Name = "Edit";
            btneliminar.Name = "Cambiar";
            dgvPresentacion.Columns.Add(btnedit);
            dgvPresentacion.Columns.Add(btneliminar);

            dgvPresentacion.Columns[0].HeaderText = "ID";
            dgvPresentacion.Columns[1].HeaderText = "PRESENTACION";
            dgvPresentacion.Columns[2].HeaderText = "ESTADO";
            dgvPresentacion.Columns[3].HeaderText = "ESTADO";

            DataGridViewColumn Column;
            Column = dgvPresentacion.Columns[0];
            Column.Visible = false;
            Column = dgvPresentacion.Columns[2];
            Column.Visible = false;
        }
        #region SeleccionarColumna
        public void seleccionarPresentacion(string presentacion)
        {
            dgvPresentacion.ClearSelection();
            foreach (DataGridViewRow row in dgvPresentacion.Rows)
            {
                if (presentacion == row.Cells["presentacion"].Value.ToString())
                {
                    dgvPresentacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    row.Selected = true;
                }
            }
        }
        #endregion

        private void btnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPresentacion_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvPresentacion.Columns[e.ColumnIndex].Name == "Edit" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //DataGridViewButtonCell celBoton = this.dgvUsuarios.Rows[e.RowIndex].Cells["Editar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvPresentacion.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgvPresentacion.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dgvPresentacion.Columns[e.ColumnIndex].Name == "Cambiar" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //DataGridViewButtonCell celBoton = this.dgvUsuarios.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;

                Icon check = new Icon(Environment.CurrentDirectory + @"\\reload.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto                   
                e.Graphics.DrawIcon(check, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dgvPresentacion.Rows[e.RowIndex].Height = check.Height + 10;
                this.dgvPresentacion.Columns[e.ColumnIndex].Width = check.Width + 10;
                e.Handled = true;
            }
        }

        private void dgvPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string nombre, codigo;
                if (this.dgvPresentacion.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int id = int.Parse(dgvPresentacion.CurrentRow.Cells[2].Value.ToString());
                    string presentacion = dgvPresentacion.CurrentRow.Cells[3].Value.ToString();
                    //MessageBox.Show(nombre + usuario + pass + tipo + permisos);

                    Form actualizar = new FPresentacionActualizar(presentacion, id);
                    actualizar.ShowDialog();
                    //actualizar.FormClosed += cargartable;
                    //nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();   
                }
                if (this.dgvPresentacion.Columns[e.ColumnIndex].Name == "Cambiar")
                {
                    if (dgvPresentacion.SelectedCells[4].Value.ToString() == "0")
                    {
                        //codigo = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                        //nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                        int id = int.Parse(dgvPresentacion.CurrentRow.Cells[2].Value.ToString());
                        string presentacion = dgvPresentacion.CurrentRow.Cells[3].Value.ToString();

                        if (MessageBox.Show("Está seguro de Habilitar esta Presentacion?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            presentacionModel.HabilitarPresentacion(id);
                            CargarTabla();
                            FPresentacionVer.f1.NotarDeshabilitado();
                            //MessageBox.Show(usuario);
                            FPresentacionVer.f1.seleccionarPresentacion(presentacion);
                            //dgvUsuarios.Rows.Remove(dgvUsuarios.CurrentRow);
                        }
                    }
                    else //(dgvUsuarios.SelectedCells[9].Value.ToString() == "1")
                    {
                        //codigo = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                        //nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                        int id = int.Parse(dgvPresentacion.CurrentRow.Cells[2].Value.ToString());
                        string presentacion = dgvPresentacion.CurrentRow.Cells[3].Value.ToString();
                        
                        if (MessageBox.Show("Está seguro de Deshabilitar esta Presentacion?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            presentacionModel.DeshabilitarPresentacion(id);
                            CargarTabla();
                            FPresentacionVer.f1.NotarDeshabilitado();
                            FPresentacionVer.f1.seleccionarPresentacion(presentacion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }


        public void NotarDeshabilitado()
        {
            foreach (DataGridViewRow row in dgvPresentacion.Rows)
            {
                if (row.Cells["estado"].Value.ToString() == "0")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(246, 121, 121);
                }
            }
        }

        private void btnAgregarPresentacion_Click(object sender, EventArgs e)
        {
            Form crear = new FPresentacionCrear();
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
