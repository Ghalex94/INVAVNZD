using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Common.Cache;

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
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
    }
}
