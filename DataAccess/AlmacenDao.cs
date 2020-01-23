using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DataAccess
{
    public class AlmacenDao:ConnectionToMySql
    {
        public void mostrarTabla(DataGridView dgv)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT distinct id_almacen,nombre, estado, case when estado = 0 then 'Deshabilitado' when estado = 1 then 'Habilitado' end as estado2 from tb_almacen order by estado desc";
                        command.CommandType = System.Data.CommandType.Text;

                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = command;
                        System.Data.DataTable dt = new System.Data.DataTable();

                        adapter.Fill(dt);
                        dgv.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
        public void mostrarCombobox(ComboBox cbx)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT distinct id_almacen,nombre, estado from tb_presentacion where estado=1 order by estado desc";
                        command.CommandType = System.Data.CommandType.Text;

                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = command;
                        System.Data.DataTable dt = new System.Data.DataTable();

                        adapter.Fill(dt);

                        cbx.ValueMember = "id_almacen";
                        cbx.DisplayMember = "nombre";
                        cbx.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
        public void insertarAlmacen(string nombre, int estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into tb_almacen(nombre,estado)values(@nombre,@estado)";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@estado", estado);
                        command.ExecuteNonQuery();

                        //MessageBox.Show("Registro Ingresado con Exito");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void actualizarAlmacen(string nombre, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_almacen SET nombre = @nombre WHERE id_almacen = @id";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Almacen Actualizado con Exito");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void deshabilitarAlmacen(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_almacen SET estado = 0 WHERE id_almacen = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Almacen Deshabilitado");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void habilitarAlmacen(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_almacen SET estado = 1 WHERE id_almacen = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Almacen Habilitado");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }

    }
}
