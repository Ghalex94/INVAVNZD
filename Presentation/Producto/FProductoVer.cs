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

namespace Presentation.Producto
{
    public partial class FProductoVer : Form
    {
        ProductoModel productoModel = new ProductoModel();
        #region Metodos que se ejecutan al iniciar
        public static FProductoVer f1;
        public FProductoVer()
        {
            FProductoVer.f1= this;
            InitializeComponent();
            cbxfiltro.SelectedIndex = 0;
        }
        public void cargartabla()
        {
            productoModel.MostrarProducto(dgvProducto);
        }

        private void FProductoVer_Load(object sender, EventArgs e)
        {
            cargartabla();

            // Agregar botones editar, eliminar
            DataGridViewButtonColumn btnedit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btneliminar = new DataGridViewButtonColumn();
            btnedit.Name = "Edit";
            btneliminar.Name = "Cambiar";
            dgvProducto.Columns.Add(btnedit);
            dgvProducto.Columns.Add(btneliminar);

            dgvProducto.Columns[0].HeaderText = "ID";
            dgvProducto.Columns[1].HeaderText = "COD. BARRA";
            dgvProducto.Columns[2].HeaderText = "PRODUCTO";
            dgvProducto.Columns[3].HeaderText = "DETALLE";
            dgvProducto.Columns[4].HeaderText = "CANTIDAD";
            dgvProducto.Columns[5].HeaderText = "FECHA VENCIMIENTO";
            dgvProducto.Columns[6].HeaderText = "LOTE";
            dgvProducto.Columns[7].HeaderText = "LABORATORIO";
            dgvProducto.Columns[8].HeaderText = "COMPOSICION";
            dgvProducto.Columns[9].HeaderText = "PRESENTACION Number";
            dgvProducto.Columns[10].HeaderText = "PRESENTACION";
            dgvProducto.Columns[11].HeaderText = "ESTADO Number";
            dgvProducto.Columns[12].HeaderText = "ESTADO";

            DataGridViewColumn Column;
            Column = dgvProducto.Columns[0];
            Column.Visible = false;
            Column = dgvProducto.Columns[9];
            Column.Visible = false;
            Column = dgvProducto.Columns[11];
            Column.Visible = false;
        }
        #endregion
        #region SeleccionarColumna
        public void seleccionarProducto(string presentacion)
        {
            dgvProducto.ClearSelection();
            foreach (DataGridViewRow row in dgvProducto.Rows)
            {
                if (presentacion == row.Cells["producto"].Value.ToString())
                {
                    dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    row.Selected = true;
                }
            }
        }
        #endregion

        private void btnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Metodos de botones Editar y Eliminar
        private void dgvUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvProducto.Columns[e.ColumnIndex].Name == "Edit" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //DataGridViewButtonCell celBoton = this.dgvUsuarios.Rows[e.RowIndex].Cells["Editar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvProducto.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgvProducto.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dgvProducto.Columns[e.ColumnIndex].Name == "Cambiar" && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //DataGridViewButtonCell celBoton = this.dgvUsuarios.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;

                Icon check = new Icon(Environment.CurrentDirectory + @"\\reload.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto                   
                e.Graphics.DrawIcon(check, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dgvProducto.Rows[e.RowIndex].Height = check.Height + 10;
                this.dgvProducto.Columns[e.ColumnIndex].Width = check.Width + 10;
                e.Handled = true;

            }
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string nombre, codigo;
                if (this.dgvProducto.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int id = int.Parse(dgvProducto.CurrentRow.Cells[2].Value.ToString());
                    string cod_barra = dgvProducto.CurrentRow.Cells[3].Value.ToString();
                    string producto = dgvProducto.CurrentRow.Cells[4].Value.ToString();
                    string detalle = dgvProducto.CurrentRow.Cells[5].Value.ToString();
                    double cantidad =double.Parse( dgvProducto.CurrentRow.Cells[6].Value.ToString());
                    DateTime fec_vencimiento =DateTime.Parse(dgvProducto.CurrentRow.Cells[7].Value.ToString());
                    string lote = dgvProducto.CurrentRow.Cells[8].Value.ToString();
                    string laboratorio = dgvProducto.CurrentRow.Cells[9].Value.ToString();
                    string composicion = dgvProducto.CurrentRow.Cells[10].Value.ToString();
                    int id_presentacion=int.Parse(dgvProducto.CurrentRow.Cells[11].Value.ToString());
                    //MessageBox.Show(nombre + usuario + pass + tipo + permisos);

                    Form actualizar = new FProductoActualizar(cod_barra, producto, detalle, cantidad, fec_vencimiento, lote, laboratorio, composicion, id_presentacion, id);
                    actualizar.ShowDialog();


                    //actualizar.FormClosed += cargartable;
                    //nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();   
                }
                if (this.dgvProducto.Columns[e.ColumnIndex].Name == "Cambiar")
                {
                    if (dgvProducto.SelectedCells[13].Value.ToString() == "0")
                    {
                        //codigo = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                        //nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                        int id = int.Parse(dgvProducto.CurrentRow.Cells[2].Value.ToString());
                        string producto= dgvProducto.CurrentRow.Cells[4].Value.ToString();
                        if (MessageBox.Show("Está seguro de Habilitar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            productoModel.HabilitarProducto(id);
                            cargartabla();
                            FProductoVer.f1.NotarDeshabilitado();                          
                            FProductoVer.f1.seleccionarProducto(producto);
                            //dgvUsuarios.Rows.Remove(dgvUsuarios.CurrentRow);
                        }
                    }
                    else //(dgvUsuarios.SelectedCells[9].Value.ToString() == "1")
                    {
                        //codigo = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                        //nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                        int id = int.Parse(dgvProducto.CurrentRow.Cells[2].Value.ToString());
                        string producto = dgvProducto.CurrentRow.Cells[4].Value.ToString();
                        if (MessageBox.Show("Está seguro de Deshabilitar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            productoModel.DeshabilitarProducto(id);
                            cargartabla();
                            FProductoVer.f1.NotarDeshabilitado();
                            FProductoVer.f1.seleccionarProducto(producto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        public void NotarDeshabilitado()
        {
            foreach (DataGridViewRow row in dgvProducto.Rows)
            {
                if (row.Cells["estado"].Value.ToString() == "0")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(246, 121, 121);
                }
            }
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Form crear = new FProductoCrear();
            crear.ShowDialog();
            crear.FormClosed += cargartable;
        }

        private void cargartable(object sender, FormClosedEventArgs e)
        {
            productoModel.MostrarProducto(dgvProducto);
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
