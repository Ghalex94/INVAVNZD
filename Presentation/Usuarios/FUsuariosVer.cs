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

namespace Presentation
{
    public partial class FUsuariosVer : Form
    {
        #region Metodos que se ejecutan al iniciar
        public static FUsuariosVer f1;     
        public FUsuariosVer()
        {
            InitializeComponent();
            FUsuariosVer.f1 = this;
            UserModel user = new UserModel();
            user.MostrarUSuarios(dgvUsuarios);
        }
        private void FUsuariosVer_Load(object sender, EventArgs e)
        {
            // Agregar botones editar, eliminar
            DataGridViewButtonColumn btnedit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btneliminar = new DataGridViewButtonColumn();
            btnedit.Name = "Editar";
            btneliminar.Name = "Eliminar";
            dgvUsuarios.Columns.Add(btnedit);
            dgvUsuarios.Columns.Add(btneliminar);

            // ASIGNACION DE NOMBRES A COLUMNAS
            dgvUsuarios.Columns[0].HeaderText = "ID";
            dgvUsuarios.Columns[1].HeaderText = "NOMBRE";
            dgvUsuarios.Columns[2].HeaderText = "USUARIO";
            dgvUsuarios.Columns[3].HeaderText = "CONTRASEÑA";
            dgvUsuarios.Columns[4].HeaderText = "TIPO";
            dgvUsuarios.Columns[5].HeaderText = "TIPO";
            dgvUsuarios.Columns[6].HeaderText = "PERMISOS";
            dgvUsuarios.Columns[7].HeaderText = "ESTADO";

            // Ocultar columnas
            DataGridViewColumn Column;
            Column = dgvUsuarios.Columns[0];
            Column.Visible = false;
            Column = dgvUsuarios.Columns[3];
            Column.Visible = false;
            Column = dgvUsuarios.Columns[4];
            Column.Visible = false;
            Column = dgvUsuarios.Columns[7];
            Column.Visible = false;

        }
        #endregion

        public void seleccionarUsuario(string usuario)
        {
            //MessageBox.Show(usuario);
            for (int fila = 0; fila < dgvUsuarios.Rows.Count - 1; fila++)
            {
                if (usuario == dgvUsuarios.Rows[fila].Cells[2].Value.ToString())
                {
                    dgvUsuarios.Rows[fila].Selected = true;
                    fila = dgvUsuarios.Rows.Count;
                }


                //for (int col = 0; col < dgvUsuarios.Rows[fila].Cells.Count; col++)
                //{
                //    //string usuariodata = dgvUsuarios.CurrentRow.Cells[4].Value.ToString();

                //    if (usuario == dgvUsuarios.Rows[fila].Cells[2].Value.ToString())
                //    {
                //        dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //        dgvUsuarios.Rows[fila].Selected = true;
                //        MessageBox.Show(fila+"");
                //    }
                //}
            }
        }

        #region Metodos de botones Editar y Eliminar
        private void dgvUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvUsuarios.Columns[e.ColumnIndex].Name == "Editar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvUsuarios.Rows[e.RowIndex].Cells["Editar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\edit.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvUsuarios.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvUsuarios.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dgvUsuarios.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvUsuarios.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\delete.ico");/////Recuerden colocar su icono en la carpeta debug de su proyecto
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvUsuarios.Rows[e.RowIndex].Height = icoAtomico.Height + 8;
                this.dgvUsuarios.Columns[e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;
            }
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string nombre, codigo;
                if (this.dgvUsuarios.Columns[e.ColumnIndex].Name == "Editar")
                {
                    int id = int.Parse(dgvUsuarios.CurrentRow.Cells[0].Value.ToString());
                    string nombre = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                    string usuario = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                    string pass = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
                    int tipo = int.Parse(dgvUsuarios.CurrentRow.Cells[4].Value.ToString());
                    string permisos = dgvUsuarios.CurrentRow.Cells[6].Value.ToString();
                    //MessageBox.Show(nombre + usuario + pass + tipo + permisos);

                    Form actualizar = new FUsuarioActualizar(nombre, usuario, pass, tipo, permisos, id);
                    actualizar.Show();
                    //nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();             
                }
                if (this.dgvUsuarios.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    //codigo = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                    //nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                    int id = int.Parse(dgvUsuarios.CurrentRow.Cells[0].Value.ToString());
                    UserModel user = new UserModel();
                    if (MessageBox.Show("Está seguro de Deshabilitar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        user.DeshabilitarUsuario(id);
                        dgvUsuarios.Rows.Remove(dgvUsuarios.CurrentRow);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Botones
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Form crear = new FUsuarioCrear();
            crear.ShowDialog();
            crear.FormClosed += cargartable;
        }
        private void cargartable(object sender, FormClosedEventArgs e)
        {
            UserModel user = new UserModel();
            user.MostrarUSuarios(dgvUsuarios);
        }
        private void btnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
