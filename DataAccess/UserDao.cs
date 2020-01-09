using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Common.Cache;
using System.Windows.Forms;
using System.Data;

namespace DataAccess
{
    public class UserDao : ConnectionToMySql
    {
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from tb_usuario where usu = @user and  contra = @pass and estado = 1";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = System.Data.CommandType.Text;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.idUsuario = reader.GetInt32(0);
                            UserCache.nombreUsuario = reader.GetString(1);
                            UserCache.usuario = reader.GetString(2);
                            UserCache.passUsuario = reader.GetString(3);
                            UserCache.tipoUsuario = reader.GetByte(4);
                            UserCache.permisosUsuario = reader.GetString(5);
                            UserCache.estado = reader.GetByte(6);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

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
                        command.CommandText = "SELECT distinct id_usu, nombre_usu, usu, contra, tipo, case when tipo = 0 then 'Super Administrador' when tipo = 1 then 'Administrador' when tipo = 2 then 'Vendedor' end as tipo2, permisos, estado from tb_usuario where estado = 1 order by nombre_usu";
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
        public void insertarUsuario(string nombre, string usu, string pass, int tipo, string permisos, int estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into tb_usuario(nombre_usu,usu,contra,tipo,permisos,estado)values(@nombre,@usu,@pass,@tipo,@permisos,@estado)";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@usu", usu);
                        command.Parameters.AddWithValue("@pass", pass);
                        command.Parameters.AddWithValue("@tipo", tipo);
                        command.Parameters.AddWithValue("@permisos", permisos);
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

        public void actualizarUsuario(string nombre, string usu, string pass, int tipo, string permisos,int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_usuario SET nombre_usu = @nombre,usu = @usu,contra = @pass,tipo = @tipo,permisos = @permisos WHERE id_usu = @id";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@usu", usu);
                        command.Parameters.AddWithValue("@pass", pass);
                        command.Parameters.AddWithValue("@tipo", tipo);
                        command.Parameters.AddWithValue("@permisos", permisos);                       
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

        public void deshabilitarUsuario(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_usuario SET estado = 0 WHERE id_usu = @id";                      
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Usuario Deshabilitado");
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
