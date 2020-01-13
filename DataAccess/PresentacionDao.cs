using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace DataAccess
{
    public class PresentacionDao:ConnectionToMySql
    {
        public void mostrarTabla(DataGridView dgv)
        {
            #region METODO PARA LLENAR UN DATAGRID DE MANERA MANUAL Y UNO POR UNO, PARA PONER CONDICIONES QUE UNO VEA NECESARIO
            //try
            //{
            //    using (var connection = GetConnection())
            //    {
            //        connection.Open();
            //        using (var command = new MySqlCommand())
            //        {
            //            System.Data.DataTable dt = new System.Data.DataTable();
            //            dt.Columns.Add("NOMBRE");
            //            dt.Columns.Add("USUARIO");
            //            dt.Columns.Add("TIPO");
            //            dt.Columns.Add("PERMISOS");

            //            command.Connection = connection;
            //            command.CommandText = "SELECT * FROM tb_usuario where estado = 1";
            //            command.CommandType = System.Data.CommandType.Text;

            //            MySqlDataReader registro = command.ExecuteReader();
            //            while (registro.Read())
            //            {
            //                int id = registro.GetInt32(0);
            //                string nombre_usu = registro.GetString(1);
            //                string usu = registro.GetString(2);
            //                string contra = registro.GetString(3);
            //                int tipo = registro.GetInt16(4);
            //                string permisos = registro.GetString(5);
            //                int estado = registro.GetInt16(6);

            //                DataRow row = dt.NewRow();
            //                row["NOMBRE"] = nombre_usu;
            //                row["USUARIO"] = usu;
            //                row["TIPO"] = tipo;
            //                row["PERMISOS"] = permisos;
            //                dt.Rows.Add(row);
            //                //MessageBox.Show(registro.GetString(1));
            //            }
            //            dgv.DataSource = dt;
            //            /*MySqlDataAdapter adapter = new MySqlDataAdapter();
            //            adapter.SelectCommand = command;
            //            System.Data.DataTable dt = new System.Data.DataTable();
            //            adapter.Fill(dt);
            //            dgv.DataSource = dt;*/
            //        }
            //    }
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show("Error: " + error);
            //}
            #endregion

            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT distinct id_presentacion,presentacion, estado, case when estado = 0 then 'Deshabilitado' when estado = 1 then 'Habilitado' end as estado2 from tb_presentacion order by estado desc";
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
        public void insertarPresentacion(string presentacion, int estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into tb_presentacion(presentacion,estado)values(@presentacion,@estado)";
                        command.Parameters.AddWithValue("@presentacion", presentacion);
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
        public void actualizarPresentacion(string presentacion, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_presentacion SET presentacion = @presentacion WHERE id_presentacion = @id";
                        command.Parameters.AddWithValue("@presentacion", presentacion);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Registro Actualizado con Exito");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void deshabilitarPresentacion(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_presentacion SET estado = 0 WHERE id_presentacion = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Presentacion Deshabilitado");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void habilitarPresentacion(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_presentacion SET estado = 1 WHERE id_presentacion = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Presentacion Habilitado");
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
