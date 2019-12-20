using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Common.Cache;
using System.Windows.Forms;

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
                    command.CommandText = "select * from tb_usuario where usu = @user and  contra = @pass";
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
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM tb_usuario where estado = 1";
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

                        MessageBox.Show("Registro Ingresado con Exito");
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
